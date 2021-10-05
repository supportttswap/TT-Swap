var registerController = function () {
    this.initialize = function () {
        registerEvents();
    }

    var registerEvents = function () {

        $('#btnRegister').on('click', function (e) {
            e.preventDefault();
            validateRegisterInfo();
        });

        formatInput();

    }

    function formatInput() {

        $('#txtEmail').on('change', function () {

            var input = $('#txtEmail').val();

            $('#txtEmail').val(input.trim());

        });

    }

    //function validatePhone(phone) {

    //    var filterPhone = /^[0-9-+]+$/;

    //    var result = filterPhone.test(phone);

    //    return result;
    //}

    function validateEmail(email) {

        var filterEmail = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

        var result = filterEmail.test(email);

        return result;
    }

    function validateRegisterInfo() {
        var captcharesponse = grecaptcha.getResponse();

        var data = {
            BNBBEP20PublishKey: $('#txtBNBBEP20PublishKey').val(),
            Password: $('#txtPassword').val(),
            ConfirmPassword: $('#txtConfirmPassword').val(),
            Email: $('#txtEmail').val(),
            Sponsor: $('#txtSponsor').val(),
        };

        var isValid = true;

        if (!data.Sponsor) {
            isValid = be.notify('Sponsor is required!!!', 'error');
        }

        if (!data.Password) {
            isValid = be.notify('Password is required!!!', 'error');
        }

        if (data.Password != data.ConfirmPassword) {
            isValid = be.notify('Password did not match!!!', 'error');
        }

        if (!data.Email) {
            isValid = be.notify('Email is required!!!', 'error');
        }
        else {
            data.Email = String(data.Email).toLowerCase();
            if (!validateEmail(data.Email)) {
                isValid = be.notify('Email incorrect format!!!', 'error');
            }
        }

        if (isValid) {

            $.ajax({
                type: 'POST',
                data: { registerVm: data, "g-recaptcha-response": captcharesponse  },
                url: '/admin/account/register',
                dataType: 'json',
                beforeSend: function () {
                    be.startLoading();
                },
                success: function (response) {

                    if (response.Success) {
                        be.success('Register is success', response.Message, function () {
                            window.location.href = '/login';
                        });
                    }
                    else {
                        be.error('Register is failed', response.Message);
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