



/*------------------------------------------------------Email------------------------------------------------*/


$(function () {
    $("#NameDropdown").on("change", function () {
         
        var RegistrationID = $(this).val();


        $("#EmailDropdown").empty();
        $("#EmailDropdown").append(`<option selected disable>----Select Your Email----</option>`);

        $.ajax(
            {
                url: `/api/TeacherDetail/GetEmailDropdown?RegistrationID=${RegistrationID}`
            }).done(function (data) {
                $.each(data, function (i, item) {
                    $("#EmailDropdown").append(`<option value = ${item.iD}>${item.emailDropdown}</option>`);
                });
            }).fail(function (jqXHR, textStatus, error) {
                console.error(error);
            });


    });
})







