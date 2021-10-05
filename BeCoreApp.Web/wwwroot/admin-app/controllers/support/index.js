var SupportController = function () {
    this.initialize = function () {

        be.startLoading();
        loadData();
        be.stopLoading();

        registerEvents();
        registerControls();
    }
    var dataSupport = null;
    function validateData() {

        dataSupport = {
            Id: +($('#hidId').val()),
            Name: $('#txtName').val(),
            RequestContent: $('#txtRequestContent').val()
        }

        var isValid = true;
        if (!dataSupport.Name)
            isValid = be.notify('Title is required', 'error');

        if (!dataSupport.RequestContent)
            isValid = be.notify('Content is required', 'error');

        return isValid;
    }

    function registerControls() {
    }

    function registerEvents() {
        $('body').on('click', '.btn-view', function (e) {
            loadDetails(e, $(this).data('id'))
        });

        $('body').on('click', '#btnSave', function (e) {
            saveSupport(e)
        });
    }


    function saveSupport(e) {
        e.preventDefault();

        if (validateData()) {
            $.ajax({
                type: "POST",
                url: "/Admin/Support/SaveEntity",
                data: { supportVm: dataSupport },
                dataType: "json",
                beforeSend: function () {
                    be.startLoading();
                },
                success: function (response) {
                    if (response.Success) {
                        be.success('Add new ticket', response.Message, function () {
                            window.location.href = '/admin/support/index';
                        });
                    }
                    else {
                        be.error('Add new ticket', response.Message);
                    }

                    be.stopLoading();
                },
                error: function (message) {
                    be.notify(`${message.responseText}`, 'error');
                    be.stopLoading();
                }
            });
        }
    }

    function loadDetails(e, id) {
        e.preventDefault();

        $.ajax({
            type: "GET",
            url: "/Admin/Support/GetById",
            data: { id: id },
            dataType: "json",
            beforeSend: function () {
                be.startLoading();
            },
            success: function (response) {
                $('#txtNameView').val(response.Name);
                $('#txtRequestContentView').html(response.RequestContent);
                $('#txtResponseContentView').html(response.ResponseContent);
                $('#badgeType').html(be.getSupportType(response.Type));

                be.stopLoading();

                $('#modal-view').modal('show');
            },
            error: function (message) {
                be.notify(`${message.responseText}`, 'error');
                be.stopLoading();
            }
        });
    }


    function loadData(isPageChanged) {

        $.ajax({
            type: 'GET',
            data: {
                page: be.configs.pageIndex,
                pageSize: be.configs.pageSize
            },
            url: '/admin/Support/GetAllPaging',
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
                        RequestContent: item.RequestContent,
                        ResponseContent: item.ResponseContent,
                        Type: be.getSupportType(item.Type)
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