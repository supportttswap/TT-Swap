var LoginController = function () {
    this.initialize = function () {
        registerEvents();
    }

    var registerEvents = function () {

        $('#btnLogin').on('click', function (e) {
            e.preventDefault();
            validateLoginInfo();
        });
    }

    function validateLoginInfo() {

        var data = {
            Email: $('#txtEmail').val(),
            Password: $('#txtPassword').val(),
        };

        var isValid = true;

        if (!data.Email) {
            isValid = be.notify('Please enter your email!!!', 'error');
        }

        if (!data.Password) {
            isValid = be.notify('Please enter a password!!!', 'error');
        }

        if (isValid) {

            $.ajax({
                type: 'POST',
                data: { loginVm: data },
                dataType: 'json',
                beforeSend: function () {
                    be.startLoading();
                },
                url: '/admin/account/login',
                success: function (response) {

                    if (response.Success) {
                        be.notify('Login is success', 'success');
                        window.location.href = '/admin/home/index';
                    }
                    else {
                        be.notify(response.Message, 'error');
                    }

                    be.stopLoading();
                },
                error: function (message) {
                    be.notify(`${message.responseText}`, 'error');
                    be.stopLoading();
                },
            });
        }
    }
}