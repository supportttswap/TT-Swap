var MetaMaskHelper = {
    initialize: function () {
        if (!window.Web3Instant) {
            window.Web3Instant = new Web3(Web3.givenProvider);
        }
        if (!(ethereum && ethereum.isMetaMask)) {
            //show popup with link to metamask extension install
            window.location.replace('https://metamask.io/');
        }
    },

    MetaMask: function () {
        this.currentAccount = {}

        this.init = async function fn() {

            if (IsMetaMaskNotInstalled()) {
                ShowConnectButton();
                $('.metamask_form').hide();
                return;
            }

            registerEvents()

            SwitchEthereumChain()

            var result = await checkValidMetamask()
            if (!result) return

            requestAccounts();
        }

        async function checkValidMetamask() {
            
            var accounts = await getAccounts();
            if (accounts.length == 0) {
                ShowConnectButton();
                $('.metamask_form').hide();
                return false;
            }
            ShowSendButton()
            return true;
        }

        function registerEvents() {
            ethereum.on('accountsChanged', handleAccountsChanged);

            $('.metamask_amount').on('focusout', async function () {
                be.startLoading()

                let value = $('.metamask_amount').val();

                var response = await GetAsync('/MetaMask/GetAmountTTSPerBNB/' + value)
                                        .catch(error => {
                                            
                                        })

                $('.metamask_TTS-amount').val(response.Data);

                be.stopLoading()
            })
        }
        function ShowConnectButton() {
            $('.metamask_button').off('click')

            $('.metamask_button').attr('data-type', 'connect').html('Connect Wallet');

            $('.metamask_button[data-type="connect"]').on('click', async function () {

                if (IsMetaMaskNotInstalled()) {
                    be.confirm('TT-SWAP notification', 'You have not installed MetaMask, please install MetaMask', function () {
                        window.location.replace('https://metamask.io/');
                    });

                    return;
                }

                await requestConnectAccounts();
                await requestAccounts();
            });
        }

        async function confirmProgressTransaction() {
          
            //switch net
            var isSwitchSucess = await SwitchEthereumChain()

            if (!isSwitchSucess) {
                be.error('TT-SWAP Notification', 'Can not switch net.')
                return;
            }

            //process buy TTS
            be.startLoading();

            InitializeTransactionMetaMask().then(async res => {

                if (!res.Success) {
                    be.error(res.Message)
                    be.stopLoading()
                    return
                }
                    
                var amountConverted = Web3.utils.toWei(res.Data.Value.toString());
                var hexAmount = Web3.utils.numberToHex(amountConverted, 'ether');

                let data = {
                    from: res.Data.From,
                    to: res.Data.To,
                    value: hexAmount,
                    gasPrice: res.Data.GasPrice,
                    gas: res.Data.Gas,
                    data: res.Data.TransactionHex
                }

                let transactionHash = await sendTransaction(data)
                    .then(txh => txh)
                    .catch(error => {

                        UpdateErrorMetaMask(data.data, error.code);

                        if (error.code === 4001)
                            be.error('Transaction was Rejected')
                        else {
                            be.error('Something went wrong! Please contact administrator for support. Code: ' + error.code)
                        }
                        be.stopLoading();
                    })

                if (!transactionHash) {
                    be.error('Something went wrong! Please contact administrator for support.')
                    return;
                }

                be.stopLoading();
                be.startLoading('<b>We are processing your transaction.</b></br> <b>Kindly wait for a moment ultil the process completed...</b>');

                VerifyMetaMaskRequest(transactionHash).then(res => {
                    be.stopLoading();

                    if (!res.Success) {
                        be.error('TT-SWAP Notification', res.Message)
                        return
                    }
                    be.success('TT-SWAP Notification', res.Message)

                    $('.metamask_amount').val(0)
                    $('.metamask_TTS-amount').val(0)
                });
            })
            .catch(error => {
                be.error('TT-SWAP Notification', 'Something went wrong! please, contact administrator.')
                be.stopLoading();
            })
        }

        function ShowSendButton() {
            $('.metamask_button').off('click')

            $('.metamask_button').attr('data-type', 'send').html('Buy')

            $('.metamask_button[data-type="send"]').on('click', async function () {

                await confirmProgressTransaction()
            });
        }
        function IsMetaMaskNotInstalled() {

            try {
                return !ethereum && !ethereum.isMetaMask
            } catch (e) {
                return true;
            }

        }

        async function SwitchEthereumChain() {
            try {
                await ethereum.request({
                    method: 'wallet_switchEthereumChain',
                    params: [{ chainId: '0x61' }],
                });

                return true;
            } catch (switchError) {
                // This error code indicates that the chain has not been added to MetaMask.
                if (switchError.code === 4902) {
                    try {
                        await ethereum.request({
                            method: 'wallet_addEthereumChain',
                            params: [{
                                chainId: '0x61',
                                chainName: 'BNB Test Net',
                                rpcUrls: ['https://data-seed-prebsc-1-s1.binance.org:8545'],
                                nativeCurrency: {
                                    name: "BNB",
                                    symbol: "BNB",
                                    decimals: 18
                                },
                            }],
                        });
                    } catch (addError) {
                        // handle "add" error
                    }
                }

                return false;
            }
        }

        //request to metamask if not connected, will not show a prompt from metamask
        async function getAccounts() {
            return await ethereum.request({ method: 'eth_accounts' });
        }

        //request to metamask if not connected, will show a prompt from metamask
        async function requestAccounts() {
            let accounts = await ethereum.request({ method: 'eth_requestAccounts' });

            $('.metamask_address').val(accounts[0]);

            return accounts;
        }

        async function requestConnectAccounts() {
            return await ethereum.request({
                method: "wallet_requestPermissions",
                params: [
                    {
                        eth_accounts: {}
                    }
                ]
            });
        }

        async function sendTransaction(data) {
            return await ethereum.request({
                method: 'eth_sendTransaction',
                params: [
                    data,
                ]
            });
        }

        

        function handleAccountsChanged(accounts) {
            if (accounts.length === 0) {
                // MetaMask is locked or the user has not connected any accounts
                ShowConnectButton()
                $('.metamask_form').hide();
            } else if (accounts[0]) {
                // Do any other work!
                $('.metamask_address').val(accounts[0])
                ShowSendButton()
                $('.metamask_form').show();
            }
        }

        function InitializeTransactionMetaMask() {

            let data = {
                BNBAmount: $('.metamask_amount').val(),
                Address: $('.metamask_address').val()
            }

            return PostAsync('/MetaMask/InitializeTransactionMetaMask', data);
        }

        function VerifyMetaMaskRequest(transactionHash) {
            return PostAsync('/MetaMask/VerifyMetaMaskRequest', transactionHash)
        }

        function UpdateErrorMetaMask(transactionHex, errorCode) {
            let data = {
                transactionHex: transactionHex,
                errorCode: errorCode
            }
            return PostAsync('/MetaMask/UpdateErrorMetaMask', data);
        }


        async function PostAsync(url = '', data = {}) {
            var token = $('input[name="__RequestVerificationToken"]').val();

            return await fetch(url, {
                method: 'POST',
                dataType: 'json',
                headers: {
                    "RequestVerificationToken": token,
                    'Content-Type': 'application/json; charset=utf-8'
                    // 'Content-Type': 'application/x-www-form-urlencoded',
                },
                body: JSON.stringify(data)
            }).then(response => response.json())
        }

        async function GetAsync(url = '') {
            return await fetch(url, {
                method: 'GET',
                dataType: 'json',
                headers: {
                    'Content-Type': 'application/json; charset=utf-8'
                    // 'Content-Type': 'application/x-www-form-urlencoded',
                },
            }).then(response => response.json())
        }

    }
}
