var BlogController = function () {
    this.initialize = function () {
        initTreeDdlBlogCategory('#ddlSearchBlogCategoryId');

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
            deleteBlog(e, this)
        });
    }

    function deleteBlog(e, element) {
        e.preventDefault();
        be.confirm('Delete blog', 'Are you sure to delete?', function () {
            $.ajax({
                type: "POST",
                url: "/Admin/Blog/Delete",
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

    function initTreeDdlBlogCategory(selector, selectedId) {
        $.ajax({
            url: "/Admin/Blog/GetAllBlogCategory",
            type: 'GET',
            dataType: 'json',
            async: false,
            success: function (response) {

                response.sort(function (a, b) {
                    return a.data.sortOrder - b.data.sortOrder;
                });

                if (selector == "#ddlBlogCategoryId") {
                    $(selector).combotree({
                        data: response
                    });
                }
                else {
                    $(selector).combotree({
                        data: response,
                        onSelect: function ($node) {
                            nodeBlogCategoryId = $node.id;
                            loadData(true);
                        }
                    });
                }

                if (selectedId != undefined)
                    $(selector).combotree('setValue', selectedId);
            },
            error: function (message) {
                be.notify(`${message.responseText}`, 'error');
            }
        });
    }

    var nodeBlogCategoryId = 0;
    function loadData(isPageChanged) {

        $.ajax({
            type: 'GET',
            data: {
                blogCategoryId: nodeBlogCategoryId,
                keyword: $('#txt-search-keyword').val(),
                page: be.configs.pageIndex,
                pageSize: be.configs.pageSize
            },
            url: '/admin/Blog/GetAllPaging',
            dataType: 'json',
            beforeSend: function () {
            },
            success: function (response) {
                var template = $('#table-template').html();
                var render = "";
                $.each(response.Results, function (i, item) {
                    let listTags = "";
                    $.each(item.BlogTags, function () {
                        listTags += '<span class="badge badge-light-primary fw-bolder m-1 px-4 py-3">' + this.TagId + '</span>'
                    })
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Name: item.Name,
                        Tags: listTags,
                        BlogCategoryName: item.BlogCategoryName,
                        Image: item.Image == null ? '<img src="/admin-side/images/user.png" width=100' : '<img src="' + item.Image + '" width=100 />',
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