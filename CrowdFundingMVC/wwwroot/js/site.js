// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function submitProjectToServer() {
    actionMethod = "POST"
    actionUrl = "/Project/CreateProject"

    sendData = {
        "ProjectTitle": $('#ProjectTitle').val(),
        "ProjectDescription": $('#ProjectDescription').val(),
        "ProjectTargetAmount": parseFloat($('#ProjectTargetAmount').val()),
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

            ProjectId = data["id"]
            alert('You have successfully added a project')
            window.open("/Project/SearchProject?id=" + ProjectId, "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}

function submitFundToServer() {
    let projectId = $('.js-project-id').val();
    actionMethod = "POST"
    actionUrl = "/Project/SingleProjectView/${projectId}"
    sendData = {
        "FundAmount": parseFloat($('#FundAmount').val())
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