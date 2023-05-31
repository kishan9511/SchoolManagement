/*--------------For Check Result----------------------------------------NameDropdown------------------------------------------------*/



$(function () {
    $("#USNDropdown").on("change", function () {

        var LeaveID = $(this).val();


        $("#NameDropdown").empty();

        $.ajax(
            {
                url: `/api/LeaveStatus/GetNameDropdown?LeaveID=${LeaveID}`
            }).done(function (data) {
                console.log(data);
                $("#lblStudentNameId").text(data.studentName);
                $("#lblReasonId").text(data.reason);
                $("#lblApprovedId").text(data.status);


            }).fail(function (jqXHR, textStatus, error) {
                console.error(error);
            });


    });
})