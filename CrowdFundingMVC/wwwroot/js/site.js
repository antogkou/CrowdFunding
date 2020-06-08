// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function submitProjectToServer() {
    let form = $('.js-project-add-form');

    if (!form.valid()) {
        return;
    }
    actionMethod = "POST"
    actionUrl = "/Project/CreateProject"
    var formData = new FormData();
    for (var i = 0; i < $('#MultimediaURL').length; i++) {
        formData.append("MultimediaURL", $('#MultimediaURL')[0].files[i]);
    }
    formData.append("ProjectTitle", $('#ProjectTitle').val());
    formData.append("ProjectDescription", $('#ProjectDescription').val());
    formData.append("ProjectTargetAmount", $('#ProjectTargetAmount').val());
    formData.append("ProjectCategory", $('#ProjectCategory').val());
    formData.append("ProjectEndingDate", $('#ProjectEndingDate').val());

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: formData,
        contentType: false,  // important when sending formData
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
    let form = $('.js-pledge-add-form');

    if (!form.valid()) {
        return;
    }

    actionMethod = "POST"
    actionUrl = "/Pledge/CreatePledges/"
    sendData = {
        "ProjectId": projectId,
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
            alert('You have successfully payed for this project!')
            location.reload();
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}

function submitFundToServer(projectId) {
    actionMethod = "POST"
    actionUrl = "/Fund/AddFund/"
    sendData = {
        "ProjectId": projectId,
        "FundAmount": parseFloat($('#FundAmount').val())
    }

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            alert('You have successfully payed for this project!')
            location.reload();
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
    let form = $('.js-project-edit-form');

    if (!form.valid()) {
        return;
    }
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
    let form = $('.js-pledge-edit-form');

    if (!form.valid()) {
        return;
    }
    actionMethod = "PUT"
    actionUrl = "/Pledge/updatepledge"
    sendData = {
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


$('#dropdownList').on('change', function (event) {
    var form = $(event.target).parents('form');

    form.submit();
});

var slideIndex = 1;
showDivs(slideIndex);

function plusDivs(n) {
  showDivs(slideIndex += n);
}

function showDivs(n) {
  var i;
  var x = document.getElementsByClassName("mySlides");
  if (n > x.length) {slideIndex = 1}
  if (n < 1) {slideIndex = x.length}
  for (i = 0; i < x.length; i++) {
     x[i].style.display = "none";  
  }
  x[slideIndex-1].style.display = "block";  
}

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imgpreview').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$("#MultimediaURL").change(function () {
    readURL(this);
});

// Select your input element.
var number = document.getElementById('FundAmount');

// Listen for input event on numInput.
number.onkeydown = function(e) {
    if(!((e.keyCode > 95 && e.keyCode < 106)
      || (e.keyCode > 47 && e.keyCode < 58) 
      || e.keyCode == 8)) {
        return false;
    }
}

var coll = document.getElementsByClassName("collapsible");
var i;

for (i = 0; i < coll.length; i++) {
    coll[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var content = this.nextElementSibling;
        if (content.style.display === "block") {
            content.style.display = "none";
        } else {
            content.style.display = "block";
        }
    });
}
