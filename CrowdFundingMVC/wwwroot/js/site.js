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
        "ProjectEndingDate": $('#ProjectEndingDate').val(),
        "MultimediaURL": $('#MultimediaURL').val(),
        "MultimediaTypes": $('#MultimediaTypes').val(),
        "ProjectPhotoProfile": $('#ProjectPhotoProfile').val()

    }



    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {

            alert('You have successfully added a project')
            window.open("/Project/GetMyProjects/", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}

function submitPledgeToServer(projectId) {

    actionMethod = "POST"
    actionUrl = "/Pledge/CreatePledges/"
    sendData = {
        "ProjectId": projectId,
        "PledgeTitle": $('#PledgeTitle').val(),
        "PledgeDescription": $('#PledgeDescription').val(),
        "PledgePrice": parseFloat($('#PledgePrice').val()),
        "PledgeReward": $('#PledgeReward').val()
    }

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            $('#responseDiv').html(JSON.stringify(data));

            alert('You have successfully added a pledge!')
            window.open("/Project/SingleProject?id=" + projectId, "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}

function submitPostToServer(projectId) {
    actionMethod = "POST"
    actionUrl = "/Post/CreatePost"
    sendData = {
        "ProjectId": projectId,
        "PostDescription": $('#PostDescription').val()
    }

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            location.reload();
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}

function submitBuyPledgeToServer(projectId, pledgeId) {
    actionMethod = "POST"
    actionUrl = "/Pledge/AddPledge/"
    sendData = {
        "PledgeId": pledgeId,
        "ProjectId": projectId
    }

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            alert('You have successfully payed for this!')
            //window.open("/Project/SingleProject?id=" + projectId, "_self")
            location.reload();
            //$('#responseDiv').html(JSON.stringify(data));
            //refresh page after the post is added 

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}

function editProject(projectId) {
    window.open("/Project/" + projectId + "/Edit/", "_self");

}

function doUpdateProject(projectId) {
    actionMethod = "PUT"
    actionUrl = "/Project/UpdateProject/"
    sendData = {
        "ProjectId": projectId,
        "ProjectTitle": $('#ProjectTitle').val(),
        "ProjectDescription": $('#ProjectDescription').val(),
        "ProjectTargetAmount": parseFloat($('#ProjectTargetAmount').val()),
        "IsActive": $('#IsActive').is(":checked") ? "true" : "false",
        "IsComplete": $('#IsComplete').is(":checked"),
        "ProjectEndingDate": $('#ProjectEndingDate').val(),
        "ProjectCategory": $('#ProjectCategory').val()
    }

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            alert("The project has been successfully updated!");
            window.open("/Project/SingleProject/" + projectId, "_self")

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });


}

function addPledge(projectId) {
    window.open("/Project/SingleProject/" + projectId + "/AddPledge/", "_self");
}

function editPledge(projectId, pledgeId) {
    window.open("/Project/SingleProject/" + projectId + "/EditPledge/" + pledgeId, "_self");
}

function doUpdatePledge(pledgeId, projectId) {
    actionMethod = "PUT"
    actionUrl = "/Pledge/updatepledge"
    sendData = {
        "PledgeTitle": $('#PledgeTitle').val(),
        "PledgeDescription": $('#PledgeDescription').val(),
        "PledgePrice": parseFloat($('#PledgePrice').val()),
        "PledgeReward": $('#PledgeReward').val(),
        "PledgeId": pledgeId
    }

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            alert("The pledge has been successfully updated!");
            window.open("/Project/SingleProject/" + projectId, "_self")

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}

function editPost(projectId, pledgeId) {
    window.open("/Project/SingleProject/" + projectId + "/EditPost/" + pledgeId, "_self");
}

function doUpdatePost(postId, projectId) {
    actionMethod = "PUT"
    actionUrl = "/Post/updatepost"
    sendData = {
        "PostDescription": $('#PostDescription').val(),
        "PostId": postId
    }

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            alert("The post has been successfully updated!");
            window.open("/Project/SingleProject/" + projectId, "_self")

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}


function deletePost(postId) {
    if (confirm("Are you sure you want to delete this post?")) {
        actionMethod = "DELETE"
        actionUrl = "/post/DeletePost"
        sendData = { "PostId": postId }
        $.ajax({
            url: actionUrl,
            dataType: 'html',
            type: actionMethod,
            data: JSON.stringify(sendData),

            contentType: 'application/json',
            processData: false,
            success: function (data, textStatus, jQxhr) {
                location.reload();

            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        });
    }
    else {
        return false;
    }

}

function deletePledge(pledgeId) {

    if (confirm("Are you sure you want to delete this pledge?")) {
        actionMethod = "DELETE"
        actionUrl = "/pledge/DeletePledge"
        sendData = { "PledgeId": pledgeId }
        $.ajax({
            url: actionUrl,
            dataType: 'html',
            type: actionMethod,
            data: JSON.stringify(sendData),
            contentType: 'application/json',
            processData: false,
            success: function (data, textStatus, jQxhr) {
                location.reload();
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        });
    }
    else {
        return false;
    }
}

function passFunction() {
    var x = document.getElementById("myPass");
    var y = document.getElementById("myPass2");
    if (x.type === "password") {
        x.type = "text";
        y.type = "text";
    } else {
        x.type = "password";
        y.type = "password";
    }

}