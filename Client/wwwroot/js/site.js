new DataTable('#data-table');


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
                document.location.href = `Login`;
            }
            else {
                $("#error-list").html("Account Not Found")
            }
            $("#login-btn").html(login_text)
        },
        error: function (xhr, status, error) {

            console.log("xhr", xhr.responseJSON.code);
            let error_item = "";
            $("#error-list").html("")

            if (xhr.responseJSON.code == 404) {
                $("#error-list").html("No Account Found")
            }

            var errorResponse = xhr.responseJSON;

            if (errorResponse && errorResponse.errors) {
                

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
$('#forgot-btn').click(function (e) {
    console.log($("#email-reset").val())
    e.preventDefault();
    let btn_text = $("#forgot-btn").html();
    $('#forgot-btn').html(`<div class="spinner-border text-light" role="status"><span class="sr-only">Loading...</span></div>`)

    var data = {
        email: $('#email-reset').val()
    };

    $.ajax({
        method: 'POST',
        url: 'https://localhost:7249/api/auths/forgot-password?email=' + data.email,
        //data: JSON.stringify(data),
        contentType: 'application/json',
        success: function (response) {
            console.log(response);
            $("#error-list").html("")

            if (response.code == 200) {
                document.location.href = "ConfirmEmail?email=" + data.email;
            }
            $("#forgot-btn").html(btn_text)
        },
        error: function (xhr, status, error) {
            let error_item = "";
            $("#error-list").html("")

            var errorResponse = xhr.responseJSON;

            if (errorResponse && errorResponse.errors) {
                console.log("xhr", xhr.responseJSON.errors);

                var emailErrors = errorResponse.errors.email;


                if (emailErrors) {
                    error_item += "<br/>";
                    error_item += emailErrors.join('<br/>');
                }
            }


            $("#error-list").append(error_item)
            $("#forgot-btn").html(btn_text)
        }
    });
})

$('#reset-btn').click(function (e) {
    const url = window.location.href;
    function getQueryParam(url, param) {
        const searchParams = new URL(url).searchParams;
        return searchParams.get(param);
    }

    const email = getQueryParam(url, 'email');
    e.preventDefault();
    let btn_text = $("#reset-btn").html();
    $('#reset-btn').html(`<div class="spinner-border text-light" role="status"><span class="sr-only">Loading...</span></div>`)

    var data = {
        email: email,
        token: $("#token").val(),
        NewPassword: $("#new-password").val(),
        ConfirmPassword: $("#confirm-password").val()
    };

    $.ajax({
        method: 'PUT',
        url: 'https://localhost:7249/api/auths/change-password',
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: function (response) {
            console.log("res", response);
            $("#error-list").html("")

            if (response.code == 200) {
                alert("Password Changed successfully")
                document.location.href = "Login";
            }
            else {
                $("#error-list").html("Oops Something went wrong!")
            }
            $("#reset-btn").html(btn_text)
        },
        error: function (xhr, status, error) {
            let error_item = "";
            $("#error-list").html("")

            var errorResponse = xhr.responseJSON;

            if (errorResponse && errorResponse.errors) {
                console.log("xhr", xhr.responseJSON.errors);
                console.log("status", status)
                console.log("error", error)

                var confirmPasswordErrors = errorResponse.errors.ConfirmPassword;
                var emailErrors = errorResponse.errors.Email;
                var passwordErrors = errorResponse.errors.NewPassword;
                var DtoError = errorResponse.errors.changePasswordDto;

                if (confirmPasswordErrors) {
                    error_item += "<br/>";
                    error_item += confirmPasswordErrors.join('<br/>');
                }

                if (emailErrors) {
                    error_item += "<br/>";
                    error_item += emailErrors.join('<br/>');
                }

                if (passwordErrors) {
                    error_item += "<br/>";
                    error_item += passwordErrors.join('<br/>');
                }

                if (DtoError) {
                    error_item += "<br/>";
                    error_item += DtoError.join('<br/>');
                }
            }


            $("#error-list").append(error_item)
            $("#reset-btn").html(btn_text)
        }
    });
})

/*var table = $('#events-table').DataTable({
    "dom": "<'row'<'col'l><'col text-center'B><'col'f>>" +
        "<'row'<'col-sm-12'tr>>" +
        "<'row'<'col-sm-5'i><'col-sm-7'p>>",
    buttons: [
        {
            extend: 'colvis',
            text: 'Filter Columns',
            className: 'btn btn-info'
        },
        {
            extend: 'copy',
            text: '<i class="bi bi-files"></i>',
            className: 'btn btn-info'
        },
        {
            extend: 'collection',
            text: '<i class="bi bi-save"></i> Export',
            className: 'btn btn-primary',
            buttons: [
                {
                    extend: 'csv',
                    text: '<i class="bi bi-file-earmark-spreadsheet"></i> Export to CSV'
                },
                {
                    extend: 'excel',
                    text: '<i class="bi bi-file-earmark-excel"></i> Export to Excel'
                },
                {
                    extend: 'pdf',
                    text: '<i class="bi bi-file-pdf"></i> Export to PDF'
                }
            ]
        },
        {
            extend: 'print',
            text: '<i class="bi bi-printer"></i> ',
            className: 'btn btn-secondary'
        }
    ],
    "columns": [
        { "data": "name" },
        { "data": "thumbnail" },
        { "data": "description" },
        { "data": "isPublished" },
        { "data": "isPaid" },
        { "data": "price" },
        { "data": "category" },
        { "data": "status" },
        {
            "data": function (row) {
                return moment(row.startDate).format("D MMMM YYYY");
            }
        },
        {
            "data": function (row) {
                return moment(row.endDate).format("D MMMM YYYY");
            }
        },
        { "data": "thumbnail" },
        { "data": "quota" },
        { "data": "place" },
        { "data": "createdBy" },
        {
            "data": null,
            "render": function (data, type, row) {
                return '<button onclick="" class="btn btn-primary btn-sm edit-button" data-bs-toggle="tooltip" data-bs-placement="bottom" title="Edit ' + row.firstName + ' ' + row.lastName + '"><i class="bi bi-pencil"></i></button>' +
                    '<button onclick="" class="btn btn-danger mx-1 btn-sm delete-button" data-bs-toggle="tooltip" data-bs-placement="bottom" title="Delete ' + row.firstName + ' ' + row.lastName + '"><i class="bi bi-trash"></i></button>' +
                    '<button onclick="" class="btn btn-info btn-sm details-button" data-bs-toggle="tooltip" data-bs-placement="bottom" title="See Details for ' + row.firstName + ' ' + row.lastName + '"><i class="bi bi-three-dots"></i></button>';
            }
        }
    ]
});*/