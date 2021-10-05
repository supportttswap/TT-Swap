var ReportController = function () {
    this.initialize = function () {
        loadReportInfo();
        registerEvents();
        registerControl();
    }

    function registerControl() {
        $("#FromDate").flatpickr();
        $("#ToDate").flatpickr();
    }

    function registerEvents() {

        $("#btnSearch").on('click', function (e) {
            loadReportInfo();
        });

        UploadFile();
    };

    function loadReportInfo() {
        var fromDate = $("#FromDate").val();
        var toDate = $("#ToDate").val();
        $.ajax({
            type: "GET",
            url: "/admin/Report/GetReportInfo",
            data: { FromDate: fromDate, ToDate: toDate },
            dataType: "json",
            beforeSend: function () {
            },
            success: function (response) {
                $(".TotalMember").html(response.TotalMember);
                $(".TodayMember").html(response.TodayMember);
                $(".TotalMemberVerifyEmail").html(response.TotalMemberVerifyEmail);
                $(".TotalMemberInVerifyEmail").html(response.TotalMemberInVerifyEmail);

                $(".TotalBNBBEP20Deposit").html(response.TotalBNBBEP20Deposit);
                $(".TotalBNBBEP20Withdraw").html(response.TotalBNBBEP20Withdraw);
                $(".TodayBNBBEP20Deposit").html(response.TodayBNBBEP20Deposit);
                $(".TodayBNBBEP20Withdraw").html(response.TodayBNBBEP20Withdraw);

                $(".TotalBNBAffiliateDeposit").html(response.TotalBNBAffiliateDeposit);
                $(".TotalBNBAffiliateWithdraw").html(response.TotalBNBAffiliateWithdraw);
                $(".TodayBNBAffiliateDeposit").html(response.TodayBNBAffiliateDeposit);
                $(".TodayBNBAffiliateWithdraw").html(response.TodayBNBAffiliateWithdraw);

                $(".TotalInvestDeposit").html(response.TotalInvestDeposit);
                $(".TotalInvestWithdraw").html(response.TotalInvestWithdraw);
                $(".TodayInvestDeposit").html(response.TodayInvestDeposit);
                $(".TodayInvestWithdraw").html(response.TodayInvestWithdraw);

                $(".TotalLockDeposit").html(response.TotalLockDeposit);
                $(".TotalLockWithdraw").html(response.TotalLockWithdraw);
                $(".TodayLockDeposit").html(response.TodayLockDeposit);
                $(".TodayLockWithdraw").html(response.TodayLockWithdraw);
            },
            error: function (message) {
                be.notify(`jqXHR.responseText: ${message.responseText}`, 'error');
            }
        });
    };

    function UploadFile() {
        $('#upload-file').on('click', function () {
            var file = $('#input-file').prop('files')[0];
            var token = $('input[name="__RequestVerificationToken"]').val();

            var formData = new FormData();

            formData.append('FileUpload', file);
            formData.append('__RequestVerificationToken', token);

            var url = '/Uploadfile/UploadMemberBalanceFile';

            be.startLoading();

            fetch(url, {
                method: 'POST',
                dataType: 'json',
                contentType: false,
                processData: false,
                body: formData
            })
                .then(response => {

                    return response.blob();
                })
                .then(blob => {
                    var url = window.URL.createObjectURL(blob);
                    var a = document.createElement('a');
                    a.href = url;
                    a.download = "notFoundMembers.csv";
                    document.body.appendChild(a); // we need to append the element to the dom -> otherwise it will not work in firefox
                    a.click();
                    a.remove();

                    be.stopLoading();
                    be.notify(`Imported Successful`, 'success');
                    $('#input-file').val('');
                    location.reload();
                })
                .catch(error => {
                    be.stopLoading();
                    $('#input-file').val('')
                });
        });
    }
}