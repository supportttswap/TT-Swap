var be = {

    configs: {
        pageSize: 10,
        pageUserSize: 150,
        pageIndex: 1
    },

    notify: function (message, type) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        if (type.search("success") >= 0) {
            toastr.success(message);
            return true;
        }
        else {
            toastr.error(message);
            return false;
        }
    },

    confirm: function (title, message, okCallback) {
        Swal.fire({
            title: title,
            text: message,
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: "Yes, do it",
            cancelButtonText: 'No, cancel',
        }).then((result) => {
            if (result.isConfirmed) {
                okCallback();
            }
        })
    },

    error: function (title, message) {
        Swal.fire({
            title: title,
            text: message,
            icon: "error",
            buttonsStyling: !1,
            confirmButtonText: "Ok, got it!",
            customClass: {
                confirmButton: "btn btn-primary"
            }
        })
    },

    success: function (title, message, okCallback) {
        Swal.fire({
            title: title,
            text: message,
            icon: "success",
            buttonsStyling: !1,
            confirmButtonText: "Ok, got it!",
            customClass: {
                confirmButton: "btn btn-primary"
            }
        }).then((result) => {
            debugger;
            if (okCallback) {
                okCallback()
            }
        })
    },

    dateFormatJson: function (datetime) {
        if (datetime == null || datetime == '')
            return '';
        var newdate = new Date(datetime);
        var month = newdate.getMonth() + 1;
        var day = newdate.getDate();
        var year = newdate.getFullYear();
        var hh = newdate.getHours();
        var mm = newdate.getMinutes();
        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        if (hh < 10)
            hh = "0" + hh;
        if (mm < 10)
            mm = "0" + mm;
        return day + "/" + month + "/" + year;
    },

    dateTimeFormatJson: function (datetime) {
        if (datetime == null || datetime == '')
            return '';
        var newdate = new Date(datetime);
        var month = newdate.getMonth() + 1;
        var day = newdate.getDate();
        var year = newdate.getFullYear();
        var hh = newdate.getHours();
        var mm = newdate.getMinutes();
        var ss = newdate.getSeconds();
        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        if (hh < 10)
            hh = "0" + hh;
        if (mm < 10)
            mm = "0" + mm;
        if (ss < 10)
            ss = "0" + ss;
        return day + "/" + month + "/" + year + " " + hh + ":" + mm + ":" + ss;
    },

    startLoading: function (message) {
        blockUI.block();
        if(message)
            $('.blockui-message').html('<span class="spinner-border text-primary"></span> ' + message)
    },

    stopLoading: function () {
        blockUI.release();
    },

    getStatus: function (status) {
        if (status == 1)
            return '<span class="badge badge-light-success fw-bolder px-4 py-3">Yes</span>';
        else
            return '<span class="badge badge-light-danger fw-bolder px-4 py-3">No</span>';
    },

    getEmailConfirmed: function (status) {
        if (status == true)
            return '<span class="badge badge-light-success fw-bolder px-4 py-3">Yes</span>';
        else
            return '<span class="badge badge-light-danger fw-bolder px-4 py-3">No</span>';
    },

    getActivated: function (status) {
        if (status == true)
            return '<span class="badge badge-light-success fw-bolder px-4 py-3">Yes</span>';
        else
            return '<span class="badge badge-light-danger fw-bolder px-4 py-3">No</span>';
    },

    getUpdatedKYC: function (status) {
        if (status == true)
            return '<span class="badge badge-light-success fw-bolder px-4 py-3">Yes</span>';
        else
            return '<span class="badge badge-light-danger fw-bolder px-4 py-3">No</span>';
    },

    getType: function (type) {
        if (type == 1)
            return '<span class="badge badge-light-success fw-bolder px-4 py-3">New</span>';
        else if (type == 2)
            return '<span class="badge badge-light-secondary fw-bolder px-4 py-3">Watched</span>';
        else
            return '<span class="badge badge-light-primary fw-bolder px-4 py-3">Responded</span>';
    },

    getTransactionType: function (type) {
        if (type == 1)
            return '<span class="badge badge-light-success fw-bolder px-4 py-3">New</span>';
        else if (type == 2)
            return '<span class="badge badge-light-primary fw-bolder px-4 py-3">Approve</span>';
        else
            return '<span class="badge badge-light-danger fw-bolder px-4 py-3">Reject</span>';
    },

    getSupportType: function (type) {
        if (type == 1)
            return '<span class="badge badge-light-success fw-bolder px-4 py-3">New</span>';
        else
            return '<span class="badge badge-light-primary fw-bolder px-4 py-3">Responded</span>';
    },

    getKYCType: function (type) {
        if (type == 1)
            return '<span class="badge badge-primary-light">Pending</span>';
        else if (type == 2)
            return '<span class="badge badge-danger-light">Reject</span>';
        else if (type == 3)
            return '<span class="badge badge-success-light">Accept</span>';
        else
            return '<span class="badge badge-secondary-light">Locked</span>';
    },

    getTicketStatus: function (type) {
        if (type == 1)
            return '<span class="badge badge-light-warning">Pending</span>';
        else if (type == 2)
            return '<span class="badge badge-light-danger">Rejected</span>';
        else if (type == 3)
            return '<span class="badge badge-light-success">Approved</span>';
    },

    formatNumber: function (number, precision) {
        if (!isFinite(number)) {
            return number.toString();
        }

        var a = number.toFixed(precision).split('.');
        a[0] = a[0].replace(/\d(?=(\d{3})+$)/g, '$&,');
        return a.join('.');
    },

    formatCurrency: function (num) {
        num = num.toString().replace(/\$|\,/g, '');
        if (isNaN(num))
            num = "0";
        sign = (num == (num = Math.abs(num)));
        num = Math.floor(num * 100 + 0.50000000001);
        cents = num % 100;
        num = Math.floor(num / 100).toString();
        if (cents < 10)
            cents = "0" + cents;
        for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
            num = num.substring(0, num.length - (4 * i + 3)) + ',' +
                num.substring(num.length - (4 * i + 3));
        return (((sign) ? '' : '-') + num + '.' + cents);
    },

    //formatCurrency: function (num) {
    //    num = num.toString().replace(/\$|\,/g, '');
    //    if (isNaN(num))
    //        num = "0";
    //    sign = (num == (num = Math.abs(num)));
    //    num = Math.floor(num * 100 + 0.50000000001);
    //    cents = num % 100;
    //    num = Math.floor(num / 100).toString();
    //    if (cents < 10)
    //        cents = "0" + cents;
    //    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
    //        num = num.substring(0, num.length - (4 * i + 3)) + ',' +
    //            num.substring(num.length - (4 * i + 3));
    //    return (((sign) ? '' : '-') + num + '.' + cents);
    //},

    unflattern: function (arr) {
        var map = {};
        var roots = [];
        for (var i = 0; i < arr.length; i += 1) {
            var node = arr[i];
            node.children = [];
            map[node.id] = i; // use map to look-up the parents
            if (node.parentId !== null) {
                arr[map[node.parentId]].children.push(node);
            } else {
                roots.push(node);
            }
        }
        return roots;
    },

    wrapUserPaging: function (recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / be.configs.pageUserSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: '<<',
            prev: '<',
            next: '>',
            last: '>>',
            onPageClick: function (event, p) {
                //if (be.configs.pageIndex !== p) {
                be.configs.pageIndex = p;
                callBack();
                //}
            }
        });
    },

    wrapPaging: function (recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / be.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: '<<',
            prev: '<',
            next: '>',
            last: '>>',
            onPageClick: function (event, p) {
                //if (be.configs.pageIndex !== p) {
                be.configs.pageIndex = p;
                callBack();
                //}
            }
        });
    },

    verifyCodeAndPassword: function fncp(callBack) {
        Swal.fire({
            title: 'Enter your authenticator code and password',
            html: '<input placeholder="Enter password" type="password" id="swal-password" class="swal2-input">' +
                '<input placeholder="Enter code" id="swal-code" class="swal2-input">',
            confirmButtonText:
                'Confirm',
            showCancelButton: true,
            showLoaderOnConfirm: true,
            preConfirm: () => {

                let password = $('#swal-password').val();
                let code = $('#swal-code').val();

                if (!password || !code) {
                    Swal.showValidationMessage(
                        "Please enter password and authenticator code"
                    );

                    return;
                }

                let url = `/Authentication/VerifyAuthenticatorCode/${code}`;

                return fetch(url, {
                    method: 'POST', // or 'PUT'
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(password)
                })
                .then(response => {
                    $('#be-hidden-password').val(password);
                    $('#be-hidden-2faCode').val(code);
                    return response.json()
                })
                .then(result => {
                    if (!result.Success) throw new Error(result.Message)
                })
                .catch(error => {
                    Swal.showValidationMessage(
                        `${error}`
                    )
                })
            },
            allowOutsideClick: () => !Swal.isLoading()
        }).then((result) => {
            if (result.isConfirmed) {
                if (callBack) {
                    callBack()
                }
            }

            $('#be-hidden-2faCode').val("");
            $('#be-hidden-password').val("");
        })
    },

    VerifyCode: function fn(callBack) {
        Swal.fire({
            title: 'Enter your authenticator code and password',
            input: 'text',
            inputAttributes: {
                autocapitalize: 'off'
            },
            showCancelButton: true,
            confirmButtonText: 'Verify',
            showLoaderOnConfirm: true,
            preConfirm: (value) => {
                return fetch(`/Authentication/VerifyAuthenticatorCode/${value}`)
                    .then(response => {

                        $('#be-hidden-2faCode').val(value);
                        return response.json()
                    })
                    .then(result => {
                        if (!result.Success) throw new Error(result.Message)
                    })
                    .catch(error => {
                        Swal.showValidationMessage(
                            `${error}`
                        )
                    })
            },
            allowOutsideClick: () => !Swal.isLoading()
        }).then((result) => {
            if (result.isConfirmed) {
                if (callBack) {
                    callBack()
                }
            }

            $('#be-hidden-2faCode').val("");
        })
    },
}

var target = document.querySelector("#kt_body");

var blockUI = new KTBlockUI(target, {
    message: '<div class="blockui-message"><span class="spinner-border text-primary"></span> Loading...</div>',
});

$(document).ajaxSend(function (e, xhr, options) {
    if (options.type.toUpperCase() === "POST" || options.type.toUpperCase() === "PUT") {
        var token = $('form').find("input[name='__RequestVerificationToken']").val();
        xhr.setRequestHeader("RequestVerificationToken", token);
    }
});