var CustomerController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {

        $('#txt-search-keyword').keypress(function (e) {
            if (e.which === 13) {
                e.preventDefault();
                loadData(true);
            }
        });

        $("#ddl-show-page").on('change', function () {
            be.configs.pageSize = $(this).val();
            be.configs.pageIndex = 1;
            loadData(true);
        });

        $('body').on('click', '.btn-delete', function (e) {
            deleteCustomer(e, this);
        });
    };

    function deleteCustomer(e, element) {
        e.preventDefault();
        be.confirm('Delete member', 'You want to delete this member?', function () {
            $.ajax({
                type: "POST",
                url: "/Admin/User/DeleteCustomer",
                data: { id: $(element).data('id') },
                beforeSend: function () {
                    be.startLoading();
                },
                success: function (response) {

                    be.stopLoading();

                    if (response.Success) {
                        be.notify(response.Message, 'success');

                        loadData(true);
                    }
                    else {
                        be.notify(response.Message, 'error');
                    }
                },
                error: function (message) {
                    be.notify(`jqXHR.responseText: ${message.responseText}`, 'error');
                    be.stopLoading();
                }
            });
        });
    }

    function loadData(isPageChanged) {
        $.ajax({
            type: "GET",
            url: "/admin/user/GetAllCustomerPaging",
            data: {
                keyword: $('#txt-search-keyword').val(),
                page: be.configs.pageIndex,
                pageSize: be.configs.pageSize
            },
            dataType: "json",
            beforeSend: function () {
                be.startLoading();
            },
            success: function (response) {

                var template = $('#table-template').html();
                var render = "";

                $.each(response.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Email: item.Email,
                        Sponsor: item.Sponsor,
                        MainPublishKey: item.MainPublishKey,
                        BNBBEP20PublishKey: item.BNBBEP20PublishKey,
                        MainBalance: item.MainBalance,
                        BNBAffiliateBalance: item.BNBAffiliateBalance,
                        LockBalance: be.formatCurrency(item.LockBalance),
                        InvestBalance: be.formatCurrency(item.InvestBalance),
                        TTSAffiliateBalance: be.formatCurrency(item.TTSAffiliateBalance),
                        TTSCommissionBalance: be.formatCurrency(item.TTSCommissionBalance),
                        StakingBalance: be.formatCurrency(item.StakingBalance),
                        DateCreated: be.dateTimeFormatJson(item.DateCreated),
                        EmailConfirmed: be.getEmailConfirmed(item.EmailConfirmed)
                    });
                });

                $("#lbl-total-records").text(response.RowCount);

                $('#tbl-content').html(render);

                be.stopLoading();

                if (response.RowCount) {
                    be.wrapPaging(response.RowCount, function () {
                        loadData();
                    }, isPageChanged);
                }
            },
            error: function (message) {
                be.notify(`jqXHR.responseText: ${message.responseText}`, 'error');
                be.stopLoading();
            }
        });
    }
}