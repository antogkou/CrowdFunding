// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Write your JavaScript code.

function submitToServer() {
    actionMethod = "POST"
    actionUrl = "/Project/CreateProject"
    
    sendData = {
        "Name": $('#Name').val(),
        "Description": $('#Description').val(),
        "NeededAmount": parseFloat($('#NeededAmount').val()),
        "ProjectCategory": $('#ProjectCategory').val(),
        "EndingDate": $('#EndingDate').val(),
    }

    alert(JSON.stringify(sendData))

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),
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


//function submitFundToServer() {
//    actionMethod = "POST"
//    actionUrl = "/backer/createfund"
//    sendData = {
//        "Name": $('#Name').val(),
//        "Description": $('#Description').val(),
//        "NeededAmount": parseFloat($('#NeededAmount').val()),
//        "ProjectCategory": $('#ProjectCategory').val(),
//        "EndingDate": $('#EndingDate').val(),

//    }

//    alert(JSON.stringify(sendData))

//    $.ajax({
//        url: actionUrl,
//        dataType: 'json',
//        type: actionMethod,
//        data: JSON.stringify(sendData),

//        contentType: 'application/json',
//        processData: false,
//        success: function (data, textStatus, jQxhr) {
//            $('#responseDiv').html(JSON.stringify(data));
//        },
//        error: function (jqXhr, textStatus, errorThrown) {
//            console.log(errorThrown);
//        }
//    });
//}