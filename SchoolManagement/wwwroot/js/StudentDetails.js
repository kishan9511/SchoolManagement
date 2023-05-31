




///*------------------------------------------------------Email------------------------------------------------*/


//$(function () {
//    $("#NameDropdown").on("change", function () {

//        var StudentRegistrationID = $(this).val();


//        $("#EmailDropdown").empty();
//        $("#EmailDropdown").append(`<option selected disable>----Your Email----</option>`);

//        $.ajax(
//            {
//                url: `/api/StudentDetails/GetEmailDropdown?StudentRegistrationID=${StudentRegistrationID}`
//            }).done(function (data) {
//                $.each(data, function (i, item) {
//                    $("#EmailDropdown").append(`<option value = ${item.iD}>${item.emailDropdown}</option>`);
//                });
//            }).fail(function (jqXHR, textStatus, error) {
//                console.error(error);
//            });


//    });
//})


///*--------------For ResultEntry----------------------------------------NameDropdown------------------------------------------------*/



//$(function () {
//    $("#USNDropdown").on("change", function () {

//        var StudentRegistrationID = $(this).val();


//        $("#NameDropdown").empty();
//        $("#NameDropdown").append(`<option selected disable>----Your Name----</option>`);

//        $.ajax(
//            {
//                url: `/api/StudentDetails/GetNameDropdown?StudentRegistrationID=${StudentRegistrationID}`
//            }).done(function (data) {
//                $.each(data, function (i, item) {
//                    $("#NameDropdown").append(`<option value = ${item.iD}>${item.nameDropdown}</option>`);
//                });
//            }).fail(function (jqXHR, textStatus, error) {
//                console.error(error);
//            });


//    });
//})
