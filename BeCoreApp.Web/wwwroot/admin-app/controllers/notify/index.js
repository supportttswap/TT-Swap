var NotifyController = function () {
    this.initialize = function () {

        be.startLoading();
        loadData();
        be.stopLoading();

        registerEvents();
        registerControls();
    }

    function registerControls() {
    }

    function registerEvents() {
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

        $('body').on('click', '.btn-delete', function (e) {
            deleteNotify(e, this)
        });
    }

    function deleteNotify(e, element) {
        e.preventDefault();
        be.confirm('Delete notify', 'Are you sure to delete?', function () {
            $.ajax({
                type: "POST",
                url: "/Admin/notify/Delete",
                data: { id: $(element).data('id') },
                dataType: "json",
                beforeSend: function () {
                    be.startLoading();
                },
                success: function () {
                    be.notify('Remove news is success', 'success');
                    be.stopLoading();
                    loadData();
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
            url: '/admin/notify/GetAllPaging',
            dataType: 'json',
            beforeSend: function () {
            },
            success: function (response) {
                var template = $('#table-template').html();
                var render = "";
                $.each(response.Results, function (i, item) {

                    render += Mustache.render(template, {
                        Id: item.Id,
                        Name: item.Name,
                        DateCreated: be.dateTimeFormatJson(item.DateCreated),
                        Status: be.getStatus(item.Status)
                    });
                });

                $('#lbl-total-records').text(response.RowCount);

                $('#tbl-content').html(render);

                if (response.RowCount)
                    be.wrapPaging(response.RowCount, function () {
                        loadData()
                    }, isPageChanged);

            },
            error: function (message) {
                be.notify(`${message.responseText}`, 'error');
            }
        });
    }
}