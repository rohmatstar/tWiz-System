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
