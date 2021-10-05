var BlogUpdateController = function () {
    this.initialize = function () {
        registerEvents();
        registerControls();
    }
    var dataBlog = null;
    function validateData() {

        dataBlog = {
            Id: +($('#hidId').val()),
            Name: $('#txtName').val(),
            Image: $('#txtImage').val(),
            Tags: $('#ddlTags').val(),
            Description: $('#txtDescription').val(),
            SeoPageTitle: $('#txtSeoPageTitle').val(),
            SeoKeywords: $('#txtSeoKeywords').val(),
            SeoDescription: $('#txtSeoDescription').val(),
            BlogCategoryId: $('#ddlBlogCategoryId').combotree('getValue'),
            Status: $('#ckStatus').prop('checked') === true ? 1 : 0,
            HotFlag: $('#ckHot').prop('checked'),
            HomeFlag: $('#ckShowHome').prop('checked'),
            MildContent: CKEDITOR.instances.txtContent.getData()
        }

        var isValid = true;
        if (!dataBlog.Name)
            isValid = be.notify('Name is required', 'error');

        if (!dataBlog.Image)
            isValid = be.notify('Image is required', 'error');

        if (!dataBlog.Description)
            isValid = be.notify('Description is required', 'error');

        dataBlog.Tags = dataBlog.Tags.filter(function (x) { return x != "" });
        if (dataBlog.Tags.length == 0)
            isValid = be.notify('Tags is required', 'error');

        if (!dataBlog.MildContent)
            isValid = be.notify('MildContent is required', 'error');

        if (!dataBlog.BlogCategoryId)
            isValid = be.notify('BlogCategory is required', 'error');

        return isValid;
    }

    function registerControls() {
        CKEDITOR.replace('txtContent', {});

        $('#ddlTags').select2({
            placeholder: "Tags...",
            allowClear: true,
            tags: true,
        });

        initTreeDdlBlogCategory();

        GetBlogTags();
    }

    function registerEvents() {


        $('body').on('click', '#btnSelectImg', function () {
            $('#fileInputImage').click();
        });

        $("body").on('change', '#fileInputImage', function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            $.ajax({
                type: "POST",
                url: "/Admin/Upload/UploadImage",
                contentType: false,
                processData: false,
                data: data,
                beforeSend: function () {
                    be.startLoading();
                },
                success: function (path) {
                    $('#txtImage').val(path);
                    be.stopLoading();
                },
                error: function (message) {
                    be.notify(`${message.responseText}`, 'error');
                    be.stopLoading();
                }
            });
        });

        $('body').on('click', '#btnSave', function (e) { saveBlog(e) });
    }

    function saveBlog(e) {
        e.preventDefault();

        if (validateData()) {
            debugger;
            $.ajax({
                type: "POST",
                url: "/Admin/Blog/SaveEntity",
                data: { blogVm: dataBlog },
                dataType: "json",
                beforeSend: function () {
                    be.startLoading();
                },
                success: function (response) {
                    if (response.Success) {
                        be.success('Update blog', response.Message, function () {
                            window.location.href = '/admin/blog/index';
                        });
                    }
                    else {
                        be.error('Update blog', response.Message);
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

    function GetBlogTags() {
        $.ajax({
            type: "GET",
            url: "/Admin/Blog/GetBlogTags",
            data: { id: $('#hidId').val() },
            dataType: "json",
            beforeSend: function () {
            },
            success: function (response) {
                var tagArray = response.BlogTags;
                $('#ddlTags').val(tagArray.map(function (x) {
                    return x.TagId
                })).trigger('change');
            },
            error: function (message) {
                be.notify(`${message.responseText}`, 'error');
            }
        });
    }

    function initTreeDdlBlogCategory(selectedId) {
        $.ajax({
            url: "/Admin/Blog/GetAllBlogCategory",
            type: 'GET',
            dataType: 'json',
            async: false,
            success: function (response) {

                response.sort(function (a, b) {
                    return a.data.sortOrder - b.data.sortOrder;
                });

                $('#ddlBlogCategoryId').combotree({
                    data: response
                });

                if (selectedId != undefined) {
                    $('#ddlBlogCategoryId').combotree('setValue', selectedId);
                }
            },
            error: function (message) {
                be.notify(`${message.responseText}`, 'error');
            }
        });
    }
}