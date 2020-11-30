function reservationDatesUpdate() {
    var arrive = new Date($("#Arrival").val());
    var depart = new Date($("#Departure").val());
    var timeDiff = Math.abs(depart.getTime() - arrive.getTime());
    var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
    $('#TotalNights').val(diffDays);
}

function setMinArrival() {
    $('#Arrival').prop('min', function () {
        return new Date().toJSON().split('T')[0];
    });
}

function setMinDeparture() {
    $('#Departure').prop('min', function () {
        var minToDeparture = new Date($('#Arrival').val());
        minToDeparture.setDate(minToDeparture.getDate() + 1);      
        return minToDeparture.toJSON().split('T')[0];
    });
};

$(document).ready(function () {
    setMinArrival();
    setMinDeparture();
    reservationDatesUpdate();
    rate();
    setRate();

    $("#Arrival").change(function () {
        reservationDatesUpdate(); 
        setMinDeparture();
    });

    $("#Departure").change(function () {
        reservationDatesUpdate(); 
        calculateAmount();
    });
});





