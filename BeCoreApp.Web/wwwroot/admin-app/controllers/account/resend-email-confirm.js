var ResendEmailConfirmController = function () {
    this.initialize = function () {
        registerEvents();
    }

    var registerEvents = function () {

        $('#btnResendEmailConfirm').on('click', function (e) {
            e.preventDefault();
            validateResendEmailConfirm();
        });

        formatInput();
    }

    function formatInput() {
        $('#txtEmail').on('change', function () {

            var input = $('#txtEmail').val();

            $('#txtEmail').val(input.trim());
        });
    }

    function validateEmail(email) {

        var filterEmail = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

        var result = filterEmail.test(email);

        return result;
    }

    function validateResendEmailConfirm() {
        var data = {
            Email: $('#txtEmail').val()
        };

        var isValid = true;

        if (!data.Email) {
            isValid = be.notify('Please enter your Email', 'error');
        }
        else {
            data.Email = String(data.Email).toLowerCase();
            if (!validateEmail(data.Email)) {
                isValid = be.notify('Your Email invalid', 'error');
            }
        }

        if (isValid) {

            $.ajax({
                type: 'POST',
                data: { model: data },
                dataType: 'json',
                beforeSend: function () {
                    be.startLoading();
                },
                url: '/Admin/Account/ResendEmailConfirm',
                success: function (response) {

                    if (response.Success) {
                        be.success('Resend Email Confirm', response.Message, function () {
                            window.location.href = '/login';
                        });
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