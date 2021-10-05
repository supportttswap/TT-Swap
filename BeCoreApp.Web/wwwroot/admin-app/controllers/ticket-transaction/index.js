var TicketTransactionController = function () {
    this.initialize = function () {
        loadData();
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
    }

    var registerEvents = function () {

        $('#txt-search-keyword').keypress(function (e) {
            if (e.which === 13) {
                e.preventDefault();
                loadData(true);
            }
        });

        $('body').on('change', "#ddl-show-page", function () {
            be.configs.pageSize = $(this).val();
            be.configs.pageIndex = 1;
            loadData(true);
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

        $('body').on('click', '.btn-approve', function (e) {
            approveTicket(e, this);
        });

        $('body').on('click', '.btn-reject', function (e) {
            rejectTicket(e, this);
        });

    }

    function approveTicket(e, element) {
        e.preventDefault();

        be.confirm('Approve Ticket', 'Are you sure to Approve?', function () {
            $.ajax({
                type: "POST",
                url: "/Admin/TicketTransaction/ApproveTicket",
                data: { id: $(element).data('id') },
                dataType: "json",
                beforeSend: function () {
                    be.startLoading();
                },
                success: function (response) {
                    be.stopLoading();
                    
                    if (response.Success) {
                        be.success('Approve Ticket', response.Message, function () {
                            loadData();
                        });
                    }
                    else {
                        be.error('Approve Ticket', response.Message);
                    }
                },
                error: function (message) {
                    be.notify(`${message.responseText}`, 'error');
                    be.stopLoading();
                }
            });
        });
    }

    function rejectTicket(e, element) {
        e.preventDefault();

        be.confirm('Reject Ticket', 'Are you sure to Reject?', function () {
            $.ajax({
                type: "POST",
                url: "/Admin/TicketTransaction/RejectTicket",
                data: { id: $(element).data('id') },
                dataType: "json",
                beforeSend: function () {
                    be.startLoading();
                },
                success: function (response) {
                    be.stopLoading();

                    if (response.Success) {
                        be.success('Reject Ticket', response.Message, function () {
                            loadData();
                        });
                    }
                    else {
                        be.error('Reject Ticket', response.Message);
                    }
                },
                error: function (message) {
                    be.notify(`${message.responseText}`, 'error');
                    be.stopLoading();
                }
            });
        });
    }

    function loadData(isPageChanged) {

        $.ajax({
            type: 'GET',
            data: {
                keyword: $('#txt-search-keyword').val(),
                page: be.configs.pageIndex,
                pageSize: be.configs.pageSize
            },
            url: '/admin/TicketTransaction/GetAllPaging',
            dataType: 'json',
            beforeSend: function () {
                be.startLoading();
            },
            success: function (response) {

                var template = $('#table-template').html();
                var render = "";

                $.each(response.Results, function (i, item) {
                    render += Mustache.render(template, {
                        UserName: item.AppUserName,
                        TypeName: item.TypeName,
                        UnitName: item.UnitName,
                        Function: item.Status == 1 ? '<a data-id="' + item.Id + '" class="btn-approve btn-icon btn btn-light-dark btn-sm me-2 mt-3"><i class="fa fa-check text-success"></i></a>'
                            + '<a data-id="' + item.Id + '" class="btn-reject btn-icon btn btn-light-dark btn-sm mt-3"><i class="fa fa-minus-circle text-danger"></i></a>' : "",
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

                be.stopLoading();

                if (response.RowCount)
                    be.wrapPaging(response.RowCount, function () {
                        loadData();
                    }, isPageChanged);
            },
            error: function (message) {
                be.notify(`${message.responseText}`, 'error');
                be.stopLoading();
            }
        });
    }

}