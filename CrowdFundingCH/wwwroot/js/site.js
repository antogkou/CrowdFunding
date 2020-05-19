// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function submitProjectToServer() {
    actionMethod = "POST"
    actionUrl = "/project/createproject"
    sendData = {
        "Name": $('#Name').val(),
        "Description": $('#Description').val(),
        "NeededAmount": parseFloat($('#NeededAmount').val()),
        "ProjectCategory": $('#ProjectCategory').val()
    }
   // data: JSON.stringify({ Price: 5.0 })

    alert(JSON.stringify(sendData))

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData,),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            $('#responseDiv').html(JSON.stringify(data));
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}