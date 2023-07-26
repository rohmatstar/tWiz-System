$('#login-btn').click(function (event) {
    event.preventDefault();
    let login_text = $("#login-btn").html();
    $('#login-btn').html(`<div class="spinner-border text-light" role="status">
  <span class="sr-only">Loading...</span>
</div>`)

    var email = $('#email').val();
    var password = $('#password').val();

    var data = {
        email: email,
        password: password
    };

    $.ajax({
        method: 'POST',
        url: 'https://localhost:7249/api/auths/login',
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: function (response) {
            console.log(response);
            $("#error-list").html("")

            if (response.code == 200) {
                document.location.href = "Index";
            }
            $("#login-btn").html(login_text)
        },
        error: function (xhr, status, error) {
            let error_item = "";
            $("#error-list").html("")

            var errorResponse = xhr.responseJSON;

            if (errorResponse && errorResponse.errors) {
                console.log("xhr", xhr.responseJSON.errors);

                var emailErrors = errorResponse.errors.Email;
                var passwordErrors = errorResponse.errors.Password;

                if (emailErrors) {
                    
                    error_item += emailErrors.join('<br/>');
                }

                if (passwordErrors) {
                    error_item += "<br/>";
                    error_item += passwordErrors.join('<br/>');
                }
            }
            
            
            $("#error-list").append(error_item)
            $("#login-btn").html(login_text)
        }
    });
});

$('#register-btn').click(function (event) {
    event.preventDefault();
    let btn_text = $("#register-btn").html();
    $('#register-btn').html(`<div class="spinner-border text-light" role="status"><span class="sr-only">Loading...</span></div>`)

    var data = {
        name: $('#name').val(),
        email: $('#email').val(),
        phoneNumber: $('#phone-number').val(),
        address: $('#address').val(),
        password: $('#password').val(),
        confirmPassword: $('#confirm-password').val()
    };

    $.ajax({
        method: 'POST',
        url: 'https://localhost:7249/api/auths/register',
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: function (response) {
            console.log(response);
            $("#error-list").html("")

            if (response.code == 200) {
                alert("Successfull Register")
                document.location.href = "Login";
            }
            $("#register-btn").html(btn_text)
        },
        error: function (xhr, status, error) {
            let error_item = "";
            $("#error-list").html("")

            var errorResponse = xhr.responseJSON;

            if (errorResponse && errorResponse.errors) {
                console.log("xhr", xhr.responseJSON.errors);

                var addressErrors = errorResponse.errors.Address;
                var confirmPasswordErrors = errorResponse.errors.ConfirmPassword;
                var emailErrors = errorResponse.errors.Email;
                var nameErrors = errorResponse.errors.Name;
                var passwordErrors = errorResponse.errors.Password;
                var phoneNumberErrors = errorResponse.errors.PhoneNumber;

                if (addressErrors) {
                    error_item += "<br/>";
                    error_item += addressErrors.join('<br/>');
                }

                if (confirmPasswordErrors) {
                    error_item += "<br/>";
                    error_item += confirmPasswordErrors.join('<br/>');
                }

                if (emailErrors) {
                    error_item += "<br/>";
                    error_item += emailErrors.join('<br/>');
                }

                if (nameErrors) {
                    error_item += "<br/>";
                    error_item += nameErrors.join('<br/>');
                }

                if (passwordErrors) {
                    error_item += "<br/>";
                    error_item += passwordErrors.join('<br/>');
                }

                if (phoneNumberErrors) {
                    error_item += "<br/>";
                    error_item += phoneNumberErrors.join('<br/>');
                }
            }


            $("#error-list").append(error_item)
            $("#register-btn").html(btn_text)
        }
    });
})