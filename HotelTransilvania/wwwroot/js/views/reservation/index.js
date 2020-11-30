
function personalizedSearch() {
    var arrive = $("#arrivalSearch").val();
    var depart = $("#departureSearch").val();
    //var pageSize = $("#pageSize").prop("selected", true).val();
    var url = window.location.origin + "/Reservation/Index?arrivalSearch=" + arrive + "&departureSearch=" + depart;// + "&pageSize=" + pageSize;
    window.location = url;
    $("#arrivalSearch").val(arrive);
    $("#departureSearch").val(depart);
};


function setMinArrival() {
    $('#arrivalSearch').prop('min', function () {
        return new Date().toJSON().split('T')[0];
    });
}

function setMinDeparture() {
    $('#departureSearch').prop('min', function () {
        var minToDeparture = new Date($('#arrivalSearch').val());
        minToDeparture.setDate(minToDeparture.getDate() + 1);
        return minToDeparture.toJSON().split('T')[0];
    });
};

function setMaxDeparture() {
    $('#departureSearch').prop('max', function () {
        var maxToDeparture = new Date($('#arrivalSearch').val());
        maxToDeparture.setDate(maxToDeparture.getDate() + 60);
        return maxToDeparture.toJSON().split('T')[0];
    });
};

$("#arrivalSearch").change(function () {
    setMinDeparture();
    setMaxDeparture();
});

