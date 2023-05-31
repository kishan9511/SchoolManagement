/*--------------For Check Result----------------------------------------NameDropdown------------------------------------------------*/



$(function () {
    $("#USNDropdown").on("change", function () {

        var StudentDetailid = $(this).val();


        $("#NameDropdown").empty();

        $.ajax(
            {
                url: `/api/CheckResult/GetNameDropdown?StudentDetailid=${StudentDetailid}`
            }).done(function (data) {

                $("#lblStudentNameId").text(data.studentName);
                $("#lblUNSId").text(data.usn);
                $("#lblMarksId").text(data.marks);
                $("#lblResultId").text(data.result);
                $("#lblSubjectId").text(data.subject);
                $("#lblPhoneId").text(data.phonenumber);
                $("#lblEmailId").text(data.email);
                $("#lblAddressId").text(data.address);
                $("#lblClassId").text(data.class);
                $("#lblTotalMarksId").text(data.totalMarks);
                $("#lblPassingMarksId").text(data.passinMarks);


                //$.each(data, function (i, item) {
                //    $("#NameDropdown").append(`<option value = ${item.iD}>${item.studentName}</option>`);
                //});
            }).fail(function (jqXHR, textStatus, error) {
                console.error(error);
            });


    });
})