$(document).ready(function () {
    $('#ContactPersonFullName').change(function () {
        if ($('#ContactPersonFullName').val() === "")
            $('#ContactPersonId').val("");
    });
    $('#ContactPersonFullName').autocomplete({
        minLenght: 3,
        source: function (request, response) {
            $.ajax({
                url: "/Reservation/SearchClient",
                type: "GET",
                dataType: "json",
                data: { searchLetters: request.term },
                success: function (data) {
                    response(data);                   
                }
            })
        },
        select: function (event, ui) {
            $("#ContactPersonId").val(ui.item.id);
        }
    });
});