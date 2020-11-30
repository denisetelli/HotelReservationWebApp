$(document).ready(function () {
    $('#MainGuestFullName').change(function () {
        if ($('#MainGuestFullName').val() === "")
            $('#MainGuestId').val("");
    });
    $('#MainGuestFullName').autocomplete({
        minLenght: 3,
        source: function (request, response) {
            $.ajax({
                url: "/Reservation/SearchClientOnlyPerson",
                type: "GET",
                dataType: "json",
                data: { searchLetters: request.term },
                success: function (data) {
                    response(data);   
                }
            })
        },
        select: function (event, ui) {
            $("#MainGuestId").val(ui.item.id);
        }
    });
});