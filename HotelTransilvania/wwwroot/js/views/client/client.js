
$(document).ready(function () {
    $('#Cnpj').inputmask('99.999.999/9999-99', { removeMaskOnSubmit: true });
    $("#Cpf").inputmask('999.999.999-99', { removeMaskOnSubmit: true });
    $("#Telephone").inputmask('(99)9999[9]-9999', { removeMaskOnSubmit: true });

    var value = $('#Type').val();
    checkFieldVisibility(value);

    $('#Type').change(function () {
        var value = $(this).val();
        checkFieldVisibility(value);
    });
});


function checkFieldVisibility(value) {
    if (value == 0) {
        $('#Person').show();
        $('#Organization').hide();
    }
    else if (value == 1) {
        $('#Organization').show();
        $('#Person').hide();
    }
}


