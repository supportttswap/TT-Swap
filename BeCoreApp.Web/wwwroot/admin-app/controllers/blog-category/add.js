var BlogCategoryAddController = function () {
    this.initialize = function () {
        registerEvents();
        registerControl();
    }

    function registerControl() {
         CKEDITOR.replace('txtDescription', {});

        //$('#modal-add-edit').on('shown.bs.modal', function () {
        //    $(document).off('focusin.modal');
        //});

        //////Fix: cannot click on element ck in modal
        //$.fn.modal.Constructor.prototype.enforceFocus = function () {
        //    $(document)
        //        .off('focusin.bs.modal') // guard against infinite focus loop
        //        .on('focusin.bs.modal', $.proxy(function (e) {
        //            if (
        //                this.$element[0] !== e.target && !this.$element.has(e.target).length
        //                // CKEditor compatibility fix start.
        //                && !$(e.target).closest('.cke_dialog, .cke').length
        //                // CKEditor compatibility fix end.
        //            ) {
        //                this.$element.trigger('focus');
        //            }
        //        }, this));
        //};

        $('#Type').select2({
            placeholder: "choose type",
            allowClear: true,
        });

        initTreeDdlFunction();
    }

    function registerEvents() {
        $('#btnSave').on('click', function (e) {
            ValidateData();
        });
    };

    function ValidateData() {
        var data = {
            Id: parseInt($('#hideId').val()),
            Name: $('#txtName').val(),
            Description: CKEDITOR.instances.txtDescription.getData(),
            Type: $('#Type').val(),
            ParentId: parseInt($('#txtParentId').val()),
            FunctionId: $('#ddlFunctionId').combotree('getValue'),
            IconCss: $('#txtIconCss').val(),
            Url: $('#txtUrl').val(),
            SortOrder: $("#txtSortOrder").val(),
            SeoPageTitle: $('#txtSeoPageTitle').val(),
            SeoKeywords: $('#txtSeoKeywords').val(),
            SeoDescription: $('#txtSeoDescription').val(),
            IsMain: $('#ckIsMain').prop('checked') == true ? 1 : 0,
            Status: $('#ckStatus').prop('checked') == true ? 1 : 0
        };

        var isValid = true;

        if (!data.Name)
            isValid = be.notify('Title is required!!!', 'error');

        if (!data.Type)
            isValid = be.notify('Type is required!!!', 'error');

        if (!data.FunctionId)
            isValid = be.notify('Function is required!!!', 'error');

        if (isNaN(data.ParentId))
            data.ParentId = null;

        if (!data.Url)
            isValid = be.notify('Url is required!!!', 'error');

        if (isValid)
            createData(data);
    }

    function createData(data) {
        $.ajax({
            type: "POST",
            url: "/Admin/BlogCategory/SaveEntity",
            data: { blogCategoryVm: data },
            dataType: "json",
            beforeSend: function () {
                be.startLoading();
            },
            success: function (response) {
                if (response.Success) {
                    be.success('Add new blog category', response.Message, function () {
                        window.location.href = '/admin/blogcategory/index';
                    });
                }
                else {
                    be.error('Add new blog category', response.Message);
                }

                be.stopLoading();
            },
            error: function (message) {
                be.notify(`${message.responseText}`, 'error');
                be.stopLoading();
            },
        });
    }

    function initTreeDdlFunction(selectedId) {
        $.ajax({
            url: "/Admin/BlogCategory/GetAllFunction",
            type: 'GET',
            dataType: 'json',
            async: false,
            success: function (response) {
                response.sort(function (a, b) {
                    return a.data.sortOrder - b.data.sortOrder;
                });

                $('#ddlFunctionId').combotree({
                    data: response,
                    onSelect: function ($node) {
                        $("#txtUrl").val($node.data.url);
                    }
                });
                if (selectedId != undefined) {
                    $('#ddlFunctionId').combotree('setValue', selectedId);
                }
            },
            error: function (message) {
                be.notify(`${message.responseText}`, 'error');
            }
        });
    }
}