/*--------------For ResultEntry----------------------------------------NameDropdown------------------------------------------------*/



$(function () {
    $("#USNDropdown").on("change", function () {

        var StudentDetailid = $(this).val();


        $("#NameDropdown").empty();

        $.ajax(
            {
                url: `/api/Usn/GetNameDropdown?StudentDetailid=${StudentDetailid}`
            }).done(function (data) {
                $.each(data, function (i, item) {
                    $("#NameDropdown").append(`<option value = ${item.iD}>${item.nameDropdown}</option>`);
                });
            }).fail(function (jqXHR, textStatus, error) {
                console.error(error);
            });


    });
})