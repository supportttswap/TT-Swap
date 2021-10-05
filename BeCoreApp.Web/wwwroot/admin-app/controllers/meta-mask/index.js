
if (typeof window.ethereum !== 'undefined') {
    console.log('MetaMask is installed!');
}

//const ethereumButton = document.querySelector('.enableEthereumButton');
//const showAccount = document.querySelector('.showAccount');
//const sendEthButton = document.querySelector('.sendEthButton');
const addAssetButton = document.querySelector('#addAssetButton');

addAssetButton.addEventListener('click', () => {
    addAsset();
});

async function addAsset() {
    const tokenAddress = '0x0667427e71d38bb32f4e1226c41aa42ac50953c7';
    const tokenSymbol = 'TTS';
    const tokenDecimals = 18;
    const tokenImage = 'https://bscscan.com/token/images/TTSefi_32.png';

    try {
        // wasAdded is a boolean. Like any RPC method, an error may be thrown.
        const wasAdded = await ethereum.request({
            method: 'wallet_watchAsset',
            params: {
                type: 'ERC20', // Initially only supports ERC20, but eventually more!
                options: {
                    address: tokenAddress, // The address that the token is at.
                    symbol: tokenSymbol, // A ticker symbol or shorthand, up to 5 chars.
                    decimals: tokenDecimals, // The number of decimals in the token
                    image: tokenImage, // A string url of the token logo
                },
            },
        });

        if (wasAdded) {
            console.log('Thanks for your interest!');
        } else {
            console.log('Your loss!');
        }
    } catch (error) {
        console.log(error);
    }
}

//let accounts = [];

//sendEthButton.addEventListener('click', () => {
//    ethereum
//        .request({
//            method: 'eth_sendTransaction',
//            params: [
//                {
//                    from: accounts[0],
//                    to: '',
//                    value: '0',
//                },
//            ],
//        })
//        .then((txHash) => console.log(txHash))
//        .catch((error) => console.error);
//});

//ethereumButton.addEventListener('click', () => {
//    getAccount();
//});

//async function getAccount() {
//    accounts = await ethereum.request({ method: 'eth_requestAccounts' });
//    const account = accounts[0];
//    showAccount.innerHTML = account;
//}

//ethereum.on('accountsChanged', function (accounts) {
//    const account = accounts[0];
//    showAccount.innerHTML = account;
//});