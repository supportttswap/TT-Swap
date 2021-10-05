var CustomerTreeController = function () {
    this.initialize = function () {
        loadData();
    }

    function loadData(reload) {
        $.ajax({
            url: '/Admin/User/GetTreeAll',
            dataType: 'json',
            beforeSend: function () {
                be.startLoading();
            },
            success: function (response) {
                be.stopLoading();

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
                be.stopLoading();
            }
        });
    }

    var fillData = function (response) {
        $("div#jstree").jstree({
            plugins: ["state", "types"],
            core: {
                themes: { responsive: false },
                check_callback: true,
                data: response
            },
            //table: {
            //    columns: [
            //        {
            //            header: "",
            //            format: function (v) {
            //                return v
            //            }
            //        },
            //        {
            //            header: "", value: "lockBalance",
            //            format: function (v) {
            //                return v;
            //            }
            //        },
            //        {
            //            header: "/", value: "investBalance",
            //            format: function (v) {
            //                return v;
            //            }
            //        },
            //        {
            //            header: "/", value: "affiliateBalance",
            //            format: function (v) {
            //                return v;
            //            }
            //        },
            //        {
            //            header: "/", value: "stakingBalance",
            //            format: function (v) {
            //                return v;
            //            }
            //        },
            //        {
            //            header: "/", value: "emailConfirmed",
            //            format: function (v) {
            //                if (v)
            //                    return '<span class="badge badge-light-success fw-bolder px-4 py-3">Yes</span>'

            //                return '<span class="badge badge-light-danger fw-bolder px-4 py-3">No</span>'
            //            },
            //            //width: 40
            //        }
            //    ],
            //    resizable: true,
            //    draggable: true,
            //    width: "100%",
            //    height: "100%",
            //},
            types: {
                default: {
                    "icon": "fa fa-users text-primary"
                },
                file: {
                    "icon": "fa fa-user text-danger"
                }
            },
            state: { "key": "demo3" }
        })
    }
}