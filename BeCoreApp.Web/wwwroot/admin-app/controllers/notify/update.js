var NotifyUpdateController = function () {
    this.initialize = function () {
        registerEvents();
        registerControls();
    }
    var dataNotify = null;
    function validateData() {

        dataNotify = {
            Id: +($('#hidId').val()),
            Name: $('#txtName').val(),
            Status: $('#ckStatus').prop('checked') === true ? 1 : 0,
            MildContent: CKEDITOR.instances.txtContent.getData()
        }

        var isValid = true;
        if (!dataNotify.Name)
            isValid = be.notify('Title is required', 'error');

        if (!dataNotify.MildContent)
            isValid = be.notify('Content is required', 'error');

        return isValid;
    }

    function registerControls() {
        CKEDITOR.replace('txtContent', {});
    }

    function registerEvents() {
        $('body').on('click', '#btnSave', function (e) {
            saveNotify(e)
        });
    }

    function saveNotify(e) {
        e.preventDefault();

        if (validateData()) {
            debugger;
            $.ajax({
                type: "POST",
                url: "/Admin/Notify/SaveEntity",
                data: { notifyVm: dataNotify },
                dataType: "json",
                beforeSend: function () {
                    be.startLoading();
                },
                success: function (response) {

                    if (response.Success) {
                        be.success('Update notify', response.Message, function () {
                            window.location.href = '/admin/notify/index';
                        });
                    }
                    else {
                        be.error('Update notify', response.Message);
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
}