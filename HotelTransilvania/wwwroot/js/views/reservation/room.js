
function roomChange(selectedCategory) {   
    var arrive = $("#Arrival").val();
    var depart = $("#Departure").val();
    var url = "/Reservation/GetAvailableRooms?arrival=" + arrive + "&departure=" + depart + "";
    html.url=
    $.getJSON(url, {
        roomCategoryId: $(selectedCategory).val()
    }, function (data, message) {
        $('#roomId').html("");
        if (data.error == "") {
            $('#roomId').append('<option value="0">Selecione</option>');
            $.each(data.rooms, function (i, v) {
                $('#roomId').append('<option value="' + v.value + '">' + v.label + '</option>');
            })
        } else {
            alert(data.error);
        }
    });
    rate();
    maxGuests();
}

function rate() {
    var category = $('#roomCategoryId').val();
    $.ajax({
        url: "/Reservation/GetRate",
        type: "GET",
        data: { roomCategoryId: category },
        success: function getRate(result) {
            $('#integerRate').val(result);
            var r = formatValue(result.toString());
            $('#Rate').val(r);
            calculateAmount();
        }
    });
};

function setRate() {
    var y = formatValue($('#Rate').val());
    $('#Rate').val(y);
    var z = formatValue($('#TotalAmount').val());
    $('#TotalAmount').val(z);

};

function maxGuests() {
    var id = $('#roomId').val();
    $.ajax({
        url: "/Reservation/GetMaxOfGuests",
        type: "GET",
        data: { roomId: id },
        success: function getMax(result) {
            $('#MaxOfGuests').val(result);
        }
    });
};

function calculateAmount() {
    var dailyRate = $('#integerRate').val();
    var nights = $('#TotalNights').val();
    var total = dailyRate * nights;
    $('#integerTotal').val(total);
    var totalString = formatValue(total.toString());
    $('#TotalAmount').val(totalString);   
};

function formatValue(value) {
    var integer = null, decimal = null, c = null, j = null;
    var aux = new Array();
    value = "" + value;
    c = value.indexOf(".", 0);
    if (c > 0) {
        integer = value.substring(0, c);
        decimal = value.substring(c + 1, value.length);
    } else {
        integer = value;
    }
    for (j = integer.length, c = 0; j > 0; j -= 3, c++) {
        aux[c] = integer.substring(j - 3, j);
    }
    integer = "";
    for (c = aux.length - 1; c >= 0; c--) {
        integer += aux[c] + '.';
    }
    integer = integer.substring(0, integer.length - 1);
    decimal = parseInt(decimal);
    if (isNaN(decimal)) {
        decimal = "00";
    } else {
        decimal = "" + decimal;
        if (decimal.length === 1) {
            decimal = "0" + decimal;
        }
    }
    value = integer + "," + decimal;
    return 'R$ ' + value;
}



