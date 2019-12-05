function ProcesarPago() {
    alert("ok");
    $.ajax({
        type: "POST",
        url: "../Procesar_Pago/ProcesarPago",
        data: {
            Id_PeriodoPago: $("#frmProPag #Id_PeriodoPago").val(),
            FechaInicio: $("#frmProPag #FechaInicio").val(),
            FechaFin: $("#frmProPag #FechaFin").val(),
        },
        success: function (response) {
            $("#pcrPago").html(response);
        },
        error: function (data) {
            alert('Se ha producido un error conocido Editar.', 'Mensaje de Error');
        }
    });
};