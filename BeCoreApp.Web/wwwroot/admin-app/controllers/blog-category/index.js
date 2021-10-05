var BlogCategoryController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
        registerControl();
    }

    function registerControl() { }
    function registerEvents() { };

    function removeData(id, text) {
        be.confirm('Remove blog category','Do you want remove ' + text + '?', function () {
            $.ajax({
                type: "POST",
                url: "/Admin/BlogCategory/Delete",
                data: { id: id },
                dataType: "json",
                beforeSend: function () {
                    be.startLoading();
                },
                success: function (response) {
                    be.notify('Remove category is success!!!!', 'success');
                    be.stopLoading();
                    loadData(true);
                },
                error: function (message) {
                    be.notify(`${message.responseText}`, 'error');
                    be.stopLoading();
                },
            });
        });
    }

    function updateParentId(data) {
        $.ajax({
            type: "POST",
            url: "/Admin/BlogCategory/UpdateParentId",
            data: { id: data.node.id, parentId: data.parent == "#" ? null : data.parent },
            dataType: "json",
            beforeSend: function () { },
            success: function (response) {
                be.notify('Update parent id is success!!!!', 'success');

                loadData(true);
            },
            error: function (message) {
                be.notify(`${message.responseText}`, 'error');
            },
        });
    }

    function loadData(reload) {
        $.ajax({
            url: '/Admin/BlogCategory/GetAll',
            dataType: 'json',
            beforeSend: function () {
            },
            success: function (response) {

                response.sort(function (a, b) {
                    return a.data.sortOrder - b.data.sortOrder;
                });

                if (reload) {
                    $('div#jstree').jstree(true).settings.core.data = response;
                    $('div#jstree').jstree(true).refresh();
                }
                else {
                    fillData(response);
                }
            },
            error: function (message) {
                be.notify(`${message.responseText}`, 'error');
            }
        });
    }

    var fillData = function (response) {
        $("div#jstree").jstree({
            plugins: ["table", "contextmenu", "dnd", "state", "types"],
            core: {
                themes: { responsive: false },
                check_callback: true,
                data: response
            },
            table: {
                columns: [
                    {
                        header: "Name",
                        format: function (v) {
                            if (v)
                                return '<span>' + v + '</span >'
                        }
                    },
                    //{
                    //    header: "Description", value: "description",
                    //    format: function (v) {
                    //        if (v)
                    //            return '<span>' + v + '</span >'
                    //    }
                    //},
                    {
                        header: "Url", value: "url",
                        format: function (v) {
                            if (v)
                                return '<span>' + v + '</span >'
                        }
                    },
                    {
                        header: "Type", value: "typeName",
                        format: function (v) {
                            if (v)
                                return '<span>' + v + '</span >'
                        }
                    },
                    {
                        header: "Function", value: "functionName",
                        format: function (v) {
                            if (v)
                                return '<span>' + v + '</span >'
                        }
                    },
                    {
                        header: "Sort Order", value: "sortOrder",
                        format: function (v) {
                            if (v)
                                return '<span class="badge badge-primary-light">' + v + '</span >'
                        }
                    },
                    {
                        header: "Status", value: "status",
                        format: function (v) {
                            if (v)
                                return '<span class="badge badge-success-light">Active</span>'

                            return '<span class="badge badge-secondary-light">InActive</span>'
                        },
                        width: 40
                    }
                ],
                resizable: true,
                draggable: true,
                //contextmenu: true,
                width: "100%",
                height: "100%",
            },
            types: {
                default: { "icon": "fa fa-folder m--font-success" },
                file: { "icon": "fa fa-file  m--font-success" }
            },
            state: { "key": "demo2" },
            contextmenu: {
                items: contextmenuHandle
            }
        })
            .bind("move_node.jstree", (e, data) => {
                if (data.parent === data.old_parent) { }
                else {
                    updateParentId(data);
                }
            })
    }

    var contextmenuHandle = function ($node) {
        return {
            "Rename": {
                "separator_before": false,
                "separator_after": false,
                "label": "Update",
                "action": function (obj) {
                    window.location.href = '/admin/blogcategory/updateentity/' + $node.id;
                }
            },
            "Remove": {
                "separator_before": false,
                "separator_after": false,
                "label": "Remove",
                "action": function (obj) {
                    debugger;
                    removeData($node.id, $node.text);
                }
            }
        };
    }
}