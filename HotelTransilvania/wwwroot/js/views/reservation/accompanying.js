function removeOnEdit(indexEdit) {
    var x = "ReservationClients_" + indexEdit + "__ClientId";
    $("#" + x).parent().parent().remove();
    var rows = $('#reservationClientList tr');
    for (var i = 1; i < rows.length; i++) {
        var inner = rows[i].innerHTML;
        inner = inner.replace(/_\d*__/g, "_" + (i - 1) + "__");
        inner = inner.replace(/\[\d*\]/g, "[" + (i - 1) + "]");
        inner = inner.replace(/\(\d*\)/g, "(" + (i - 1) + ")");
        rows[i].innerHTML = inner;
    }
}

function addAccompanying() {
    $.ajax({
        url: "/Reservation/AccompanyingListPost",
        type: "POST",
        data: $('#createForm').serialize(),
        success: function (result) {
            $('#reservationClientList').html(result);
            $("#searchLetters2").val('');
        }
    });
}

//function add(id) {
//    $.ajax({
//        url: "/Reservation/AddAccompanying",
//        type: "GET",
//        data: { clientId: id },
//        success: function getInfo(result) {
//            var newIndex = $('#reservationClientList tr').length - 1;
//            var reservId = $('#ReservationId').val();
//            $('#reservationClientList tr:last').after('<tr><td> <input type="hidden" data-val="true" data-val-required="The ReservationId field is required."'
//                + ' id="ReservationClients_' + newIndex + '__ReservationId" name="ReservationClients[' + newIndex + '].ReservationId" value="' + reservId + '">'
//                + ' <input type = "hidden" data-val="true" data-val-required="The ClientId field is required." '
//                + ' id="ReservationClients_' + newIndex + '__ClientId" value=' + result.clientId + '  name="ReservationClients[' + newIndex + '].ClientId"> '
//                + ' <input type="hidden" id="ReservationClients_' + newIndex + '__FirstName" value="' + result.firstName + '" name="ReservationClients[' + newIndex + '].FirstName" >' + result.firstName + '</td>'
//                + ' <td><input type="hidden" id="ReservationClients_' + newIndex + '__LastName" value="' + result.lastName + '" name="ReservationClients[' + newIndex + '].LastName">' + result.lastName + '</td>'
//                + ' <td><input type="button" class="btn btn-secondary" onclick="removeOnEdit(' + newIndex + ')" value="Remover"/></td>'
//                + ' </tr>');
//            $("#searchLetters2").val('');
//        }
//    });
//}

$(document).ready(function lookUp() {
    $('#searchLetters2').autocomplete({
        minLenght: 3,
        source: function (request, response) {
            $.ajax({
                url: "/Reservation/SearchClientOnlyPerson",
                type: "GET",
                dataType: "json",
                data: { searchLetters: request.term },
                success: function fillName(data) {
                    response(data);
                }
            })
        },
        select: function addId(event, ui) {
            $("#clientId").val(ui.item.id);
        }
    });
});

function validateAdd(id) {
    var accompMax = $('#MaxOfGuests').val() - 1;
    var accompActual = $('#reservationClientList table tr').length - 1;
    if (accompActual < accompMax) {
        return addAccompanying();
    }
    return alert("Não foi possível adicionar este cliente. Certifique-se que o apartamento está selecionado e respeite o número de acompanhantes.");
};
