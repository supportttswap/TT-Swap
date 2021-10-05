var StatementAllUserController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {

        $('#txt-search-keyword').keypress(function (e) {
            if (e.which === 13) {
                e.preventDefault();
                loadData();
            }
        });

        $("#ddl-type").on('change', function () {
            loadData();
        });
    };

    function loadData() {
        $.ajax({
            type: "GET",
            url: "/admin/user/GetStatementAllUser",
            data: {
                keyword: $('#txt-search-keyword').val(),
                type: $('#ddl-type').val(),
            },
            dataType: "json",
            beforeSend: function () {
                be.startLoading();
            },
            success: function (response) {

                var template = $('#table-template').html();
                var render = "";

                $.each(response.AppUsers, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Email: item.Email,
                        Sponsor: item.Sponsor,
                        MainBalance: item.MainBalance,
                        BNBAffiliateBalance: item.BNBAffiliateBalance,
                        LockBalance: be.formatCurrency(item.LockBalance),
                        InvestBalance: be.formatCurrency(item.InvestBalance),
                        TTSAffiliateBalance: be.formatCurrency(item.TTSAffiliateBalance),
                        TTSCommissionBalance: be.formatCurrency(item.TTSCommissionBalance),
                        StakingBalance: be.formatCurrency(item.StakingBalance),
                        //DateCreated: be.dateTimeFormatJson(item.DateCreated),
                        //EmailConfirmed: be.getEmailConfirmed(item.EmailConfirmed),
                        //MainPublishKey: item.MainPublishKey,
                        //BNBBEP20PublishKey: item.BNBBEP20PublishKey,
                    });
                });

                $('#totalMember').html(response.TotalMember);
                $('#totalMainBalance').html(be.formatCurrency(response.TotalMainBalance));
                $('#totalBNBAffiliateBalance').html(be.formatCurrency(response.TotalBNBAffiliateBalance));
                $('#totalLockBalance').html(be.formatCurrency(response.TotalLockBalance));
                $('#totalInvestBalance').html(be.formatCurrency(response.TotalInvestBalance));
                $('#totalTTSAffiliateBalance').html(be.formatCurrency(response.TotalTTSAffiliateBalance));
                $('#totalTTSCommissionBalance').html(be.formatCurrency(response.TotalTTSCommissionBalance));

                $('#tbl-content').html(render);

                be.stopLoading();
            },
            error: function (message) {
                be.notify(`jqXHR.responseText: ${message.responseText}`, 'error');
                be.stopLoading();
            }
        });
    }
}