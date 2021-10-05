var WalletController = function () {
    this.initialize = function () {
        loadWalletBlance();
        loadTicketTransactionData();
        registerEvents();
        registerControl();
    }

    function registerControl() {
        $(".numberFormat").each(function () {
            var numberValue = parseFloat($(this).html().replace(/,/g, ''));
            if (!numberValue) {
                $(this).html(be.formatCurrency(0));
            }
            else {
                $(this).html(be.formatCurrency(numberValue));
            }
        });

        $(".numberFormat").each(function () {
            var numberValue = parseFloat($(this).html().replace(/,/g, ''));
            if (!numberValue) {
                $(this).val(be.formatCurrency(0));
            }
            else {
                $(this).val(be.formatCurrency(numberValue));
            }
        });

        jQuery('#qrcodeMainPublishKey').qrcode({
            text: $("#txtMainPublishKey").val()
        });

        jQuery('#qrcodeInvestPublishKey').qrcode({
            text: $("#txtInvestPublishKey").val()
        });

    }

    var registerEvents = function () {

        $('body').on('change', "#ddl-show-page", function () {
            be.configs.pageSize = $(this).val();
            be.configs.pageIndex = 1;
            loadTicketTransactionData(true);
        });

        $('body').on('click', '#btnCopyBNBPublishKey', function (e) {
            copyBNBPublishKey();
        });

        $('body').on('click', '#btnCopyInvestPublishKey', function (e) {
            copyInvestPublishKey();
        });

        $('.numberFormat').on("keypress", function (e) {
            var keyCode = e.which ? e.which : e.keyCode;
            var ret = ((keyCode >= 48 && keyCode <= 57) || keyCode == 46);
            if (ret)
                return true;
            else
                return false;
        });

        $(".numberFormat").focusout(function () {
            var numberValue = parseFloat($(this).val().replace(/,/g, ''));
            if (!numberValue) {
                $(this).val(be.formatCurrency(0));
            }
            else {
                $(this).val(be.formatCurrency(numberValue));
            }
        });

        $('body').on('click', '#btnWithdrawBNBBEP20', function (e) {
            if (checkEnabled2FA()) {
                showModalWithdrawBNBBEP20();
            }
        });
        $('body').on('click', '#btnConfirmWithdrawBNBBEP20', function (e) {

            var isValid = validateWithdrawBNBBEP20();

            if (!isValid) return;

            hideModalWithdrawBNBBEP20();

            be.verifyCodeAndPassword(confirmWithdrawBNBBEP20);
        });

        $('body').on('click', '#btnWithdrawInvest', function (e) {
            if (checkEnabled2FA()) {
                showModalWithdrawInvest()
            }
        });
        $('body').on('click', '#btnConfirmWithdrawInvest', function (e) {

            var isValid = validateWithdrawInvest();

            if (!isValid) return;

            hideModalWithdrawInvest();

            be.verifyCodeAndPassword(confirmWithdrawInvest);
        });

        $('body').on('click', '#btnWithdrawBNBAffiliate', function (e) {
            if (checkEnabled2FA()) {
                showModalWithdrawBNBAffiliate();
            }
        });
        $('body').on('click', '#btnConfirmWithdrawBNBAffiliate', function (e) {
            var isValid = validateWithdrawBNBAffiliate();

            if (!isValid) return;

            hideModalWithdrawBNBAffiliate();

            be.verifyCodeAndPassword(confirmWithdrawBNBAffiliate);
        });


        $("#txtBNBBEP20Amount").focusout(function () {

            var mainBalance = parseFloat($('.MainBalance').val().replace(/,/g, ''));

            var amount = parseFloat($(this).val().replace(/,/g, ''));

            var bnbBEP20FeeAmount = amount * 0.01;
            var bnbBEP20AmountReceive = amount - bnbBEP20FeeAmount;

            if (amount > mainBalance) {

                $(".lblBNBBEP20ErrorInsufficient").html("Insufficient account balance");
            }
            else {
                $(".lblBNBBEP20ErrorInsufficient").html("");
            }

            $('#txtBNBBEP20FeeAmount').val(bnbBEP20FeeAmount);
            $('#txtBNBBEP20AmountReceive').val(bnbBEP20AmountReceive);
        });

        $("#txtBNBAffiliateAmount").focusout(function () {

            var bnbAffiliateBalance = parseFloat($('.BNBAffiliateBalance').val().replace(/,/g, ''));

            var amount = parseFloat($(this).val().replace(/,/g, ''));

            var bnbAffiliateFeeAmount = amount * 0.01;
            var bnbAffiliateAmountReceive = amount - bnbAffiliateFeeAmount;

            if (amount > bnbAffiliateBalance) {

                $(".lblBNBAffiliateErrorInsufficient").html("Insufficient account balance");
            }
            else {
                $(".lblBNBAffiliateErrorInsufficient").html("");
            }

            $('#txtBNBAffiliateFeeAmount').val(bnbAffiliateFeeAmount);
            $('#txtBNBAffiliateAmountReceive').val(bnbAffiliateAmountReceive);
        });

        $("#txtInvestAmount").focusout(function () {
            debugger;

            var investBalance = parseFloat($('.InvestBalance').val().replace(/,/g, ''));

            var amount = parseFloat($(this).val().replace(/,/g, ''));

            var investFeeAmount = amount * 0.02;
            var investAmountReceive = amount - investFeeAmount;

            if (amount > investBalance) {

                $(".lblInvestErrorInsufficient").html("Insufficient account balance");
            }
            else {
                $(".lblInvestErrorInsufficient").html("");
            }

            $('#txtInvestFeeAmount').val(investFeeAmount);
            $('#txtInvestAmountReceive').val(investAmountReceive);
        });
    }

    function validateWithdrawBNBBEP20() {
        var WithdrawBNBBEP20VM = {
            Amount: parseFloat($('#txtBNBBEP20Amount').val().replace(/,/g, '')),
            MainBalance: parseFloat($('.MainBalance').val().replace(/,/g, '')),
            AddressTo: $('#txtBNBBEP20AddressTo').val(),
            Password: $('#be-hidden-password').val()
        };

        var isValid = true;

        if (WithdrawBNBBEP20VM.Amount <= 0) {
            isValid = be.notify('Amount is required', 'error');
        }

        if (WithdrawBNBBEP20VM.Amount > WithdrawBNBBEP20VM.MainBalance) {
            isValid = be.notify('Insufficient account balance', 'error');
        }

        if (!WithdrawBNBBEP20VM.AddressTo) {
            isValid = be.notify('Address Receive is required', 'error');
        }

        return isValid;
    }

    function confirmWithdrawBNBBEP20() {
        var WithdrawBNBBEP20VM = {
            Amount: parseFloat($('#txtBNBBEP20Amount').val().replace(/,/g, '')),
            AddressTo: $('#txtBNBBEP20AddressTo').val(),
            Password: $('#be-hidden-password').val()
        };

        var code = $('#be-hidden-2faCode').val();

        var url = '/Admin/Wallet/WithdrawWalletBNBBEP20?authenticatorCode=' + code;

        $.ajax({
            type: "POST",
            url: url,
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(WithdrawBNBBEP20VM),
            beforeSend: function () {
                be.startLoading();
            },
            success: function (response) {
                be.stopLoading();

                if (response.Success) {
                    be.success('Withdraw BNB BEP20', response.Message, function () {
                        window.location.reload();
                    });
                }
                else {
                    be.error('Withdraw BNB BEP20', response.Message);
                }
            },
            error: function (message) {
                be.notify(`${message.responseText}`, 'error');
                be.stopLoading();
            }
        });
    }

    function validateWithdrawInvest() {
        var WithdrawInvestVM = {
            InvestBalance: parseFloat($('.InvestBalance').val().replace(/,/g, '')),
            Amount: parseFloat($('#txtInvestAmount').val().replace(/,/g, '')),
            AddressTo: $('#txtInvestAddressTo').val(),
        };

        var isValid = true;

        if (WithdrawInvestVM.Amount <= 0) {
            isValid = be.notify('Amount is required', 'error');
        }

        if (WithdrawInvestVM.Amount > WithdrawInvestVM.InvestBalance) {
            isValid = be.notify('Insufficient account balance', 'error');
        }

        if (!WithdrawInvestVM.AddressTo) {
            isValid = be.notify('Address Receive is required', 'error');
        }

        return isValid;
    }

    function confirmWithdrawInvest() {
        var WithdrawInvestVM = {
            Amount: parseFloat($('#txtInvestAmount').val().replace(/,/g, '')),
            AddressTo: $('#txtInvestAddressTo').val(),
            Password: $('#be-hidden-password').val()
        };

        var code = $('#be-hidden-2faCode').val();

        var url = '/Admin/Wallet/WithdrawWalletInvest?authenticatorCode=' + code;

        $.ajax({
            type: "POST",
            url: url,
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(WithdrawInvestVM),
            beforeSend: function () {
                be.startLoading();
            },
            success: function (response) {
                be.stopLoading();

                if (response.Success) {
                    be.success('Withdraw Invest', response.Message, function () {
                        window.location.reload();
                    });
                }
                else {
                    be.error('Withdraw Invest', response.Message);
                }
            },
            error: function (message) {
                be.notify(`${message.responseText}`, 'error');
                be.stopLoading();
            }
        });
    }

    function validateWithdrawBNBAffiliate() {

        var WithdrawBNBAffiliateVM = {
            BNBAffiliateBalance: parseFloat($('.BNBAffiliateBalance').val().replace(/,/g, '')),
            Amount: parseFloat($('#txtBNBAffiliateAmount').val().replace(/,/g, '')),
            AddressTo: $('#txtBNBAffiliateAddressTo').val(),
        };

        var isValid = true;

        if (WithdrawBNBAffiliateVM.Amount <= 0) {
            isValid = be.notify('Amount is required', 'error');
        }

        if (WithdrawBNBAffiliateVM.Amount > WithdrawBNBAffiliateVM.BNBAffiliateBalance) {
            isValid = be.notify('Insufficient account balance', 'error');
        }

        if (!WithdrawBNBAffiliateVM.AddressTo) {
            isValid = be.notify('Address Receive is required', 'error');
        }

        return isValid;
    }

    function confirmWithdrawBNBAffiliate() {
        var WithdrawBNBAffiliateVM = {
            Amount: parseFloat($('#txtBNBAffiliateAmount').val().replace(/,/g, '')),
            AddressTo: $('#txtBNBAffiliateAddressTo').val(),
            Password: $('#be-hidden-password').val()
        };

        var code = $('#be-hidden-2faCode').val();

        var url = '/Admin/Wallet/WithdrawWalletBNBAffiliate?authenticatorCode=' + code;

        $.ajax({
            type: "POST",
            url: url,
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(WithdrawBNBAffiliateVM),
            beforeSend: function () {
                be.startLoading();
            },
            success: function (response) {
                be.stopLoading();

                if (response.Success) {
                    be.success('Withdraw BNB Affiliate', response.Message, function () {
                        window.location.reload();
                    });
                }
                else {
                    be.error('Withdraw BNB Affiliate', response.Message);
                }
            },
            error: function (message) {
                be.notify(`${message.responseText}`, 'error');
                be.stopLoading();
            }
        });
    }

    function showModalWithdrawBNBBEP20() {
        $("#ic_modal_withdraw_bnbbep20").modal("show");
    }
    function hideModalWithdrawBNBBEP20() {
        $("#ic_modal_withdraw_bnbbep20").modal("hide");
    }
    function showModalWithdrawInvest() {
        $("#ic_modal_withdraw_invest").modal("show");
    }
    function hideModalWithdrawInvest() {
        $("#ic_modal_withdraw_invest").modal("hide");
    }
    function showModalWithdrawBNBAffiliate() {
        $("#ic_modal_withdraw_bnbaffiliate").modal("show");
    }
    function hideModalWithdrawBNBAffiliate() {
        $("#ic_modal_withdraw_bnbaffiliate").modal("hide");
    }
    function checkEnabled2FA() {
        var isEnabled2FA = $("#Enabled2FA").val();
        if (isEnabled2FA) {
            return true;
        }
        else {
            be.error("Two-factor authentication (2FA)", "Your account has not enabled 2FA, please go to the profile page to enable.");
            return false;
        }
    }

    function copyBNBPublishKey() {
        var copyText = $("#txtMainPublishKey");
        copyText.select();
        document.execCommand("copy");
        be.notify('Copy to clipboard is successful', 'success');
    }
    function copyInvestPublishKey() {
        var copyText = $("#txtInvestPublishKey");
        copyText.select();
        document.execCommand("copy");
        be.notify('Copy to clipboard is successful', 'success');
    }

    function loadTicketTransactionData(isPageChanged) {

        $.ajax({
            type: 'GET',
            data: {
                keyword: $('#txt-search-keyword').val(),
                page: be.configs.pageIndex,
                pageSize: be.configs.pageSize
            },
            url: '/admin/wallet/GetAllTicketTransactionPaging',
            dataType: 'json',
            beforeSend: function () {
            },
            success: function (response) {
                var template = $('#table-template').html();
                var render = "";
                $.each(response.Results, function (i, item) {
                    render += Mustache.render(template, {
                        UserName: item.AppUserName,
                        TypeName: item.TypeName,
                        UnitName: item.UnitName,
                        StatusName: be.getTicketStatus(item.Status),
                        Sponsor: item.Sponsor,
                        AddressFrom: item.AddressFrom,
                        AddressTo: item.AddressTo,
                        Amount: item.Amount,
                        AmountReceive: item.AmountReceive,
                        Fee: (item.Fee * 100),
                        FeeAmount: item.FeeAmount,
                        DateUpdated: be.dateTimeFormatJson(item.DateUpdated),
                        DateCreated: be.dateTimeFormatJson(item.DateCreated),
                    });
                });

                $('#lbl-total-records').text(response.RowCount);

                $('#tbl-content').html(render);


                if (response.RowCount)
                    be.wrapPaging(response.RowCount, function () {
                        loadTicketTransactionData();
                    }, isPageChanged);
            },
            error: function (message) {
                be.notify(`${message.responseText}`, 'error');
            }
        });
    }

    function loadWalletBlance() {
        $.ajax({
            type: 'GET',
            url: '/admin/Wallet/GetWalletBlance',
            dataType: 'json',
            beforeSend: function () {
                be.startLoading();
            },
            success: function (response) {

                be.stopLoading();

                if (response.Success) {
                    $('#LockBalance').html(be.formatCurrency(response.Data.LockBalance));

                    $('#InvestBalance').html(be.formatCurrency(response.Data.InvestBalance));
                    $('.InvestBalance').val(be.formatCurrency(response.Data.InvestBalance));

                    $('#MainBalance').html(response.Data.MainBalance);
                    $('.MainBalance').val(response.Data.MainBalance);

                    $('#BNBAffiliateBalance').html(response.Data.BNBAffiliateBalance);
                    $('.BNBAffiliateBalance').val(response.Data.BNBAffiliateBalance);

                    $('#TTSAffiliateBalance').html(be.formatCurrency(response.Data.TTSAffiliateBalance));
                    $('#TTSCommissionBalance').html(be.formatCurrency(response.Data.TTSCommissionBalance));
                }
                else {
                    be.notify(response.Message, 'error');
                }
            },
            error: function (message) {
                be.notify(`${message.responseText}`, 'error');
                be.stopLoading();
            }
        });
    }
}