// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//function submitToServer() {
//    actionMethod = "POST"
//    actionUrl = "/project/addproject"
//    sendData = {
//        "Name": $('#Name').val(),
//        "Description": $('#Description').val(),
//        "NeededAmount": $('#NeededAmount').val(),
//        "ProjectCategory": $('#ProjectCategory').val()
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

$('.js-submit-project').on('click', () => {

    $('.js-submit-project').attr('disable', true);

    let postFormData = $('form:visible').serializeArray();

    let data = JSON.stringify({
        ProjectTitle: postFormData[0].value,
        ProjectDescription: postFormData[1].value,
        ProjectFinancialGoal: parseFloat(postFormData[2].value),
        ProjectCategory: postFormData[3].value,
        ProjectDateExpiring: postFormData[4].value
    });

    $.ajax({
        url: '/project/AddProject',
        type: 'POST',
        contentType: 'application/json',
        data: data
    }).done((project) => {

        $('.js-project-id').val(project.projectId);

        $('form[data-form="0"]').parent().hide();
        $('form[data-form="1"]').parent().fadeIn(1000);
    }).fail((xhr) => {
        alert(xhr.responseText);

        setTimeout(() => {
            $('.js-submit-project').prop('disabled', false);
        }, 1000);
    });
});