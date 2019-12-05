
function RegistrarContrato() {
    var AsignacionFamiliar;
    if ($("#frmRegCon #AsignacionFamiliar").val() == "SI") AsignacionFamiliar = true;
    else AsignacionFamiliar = false;
    $.ajax({
        type: "POST",
        url: "../Gestionar_Contrato/RegistrarContrato",
        data: {
            FechaInicio: $("#frmRegCon #FechaInicio").val(),
            FechaFin: $("#frmRegCon #FechaFin").val(),
            Id_Cargo: $("#frmRegCon #Id_Cargo").val(),
            Id_AFP: $("#frmRegCon #Id_AFP").val(),
            Id_Empleado: $("#frmRegCon #Id_Empleado").val(),
            AsignacionFamiliar: AsignacionFamiliar,
            HorasContratadas: $("#frmRegCon #HorasContratadas").val(),
            ValorHora: $("#frmRegCon #ValorHora").val()
        },
        success: function (rpta) {
            if (rpta == "OK") {
                alert("Se Guardo el Nuevo Contrato");
                location.href = "../Gestionar_Contrato/Inicio";
            } else if (rpta=="R02") {
                alert("La Fecha Inicio debe ser superior a la fecha fin de asu anterior Contrato");
            }
            else if (rpta == "R03") {
                alert("El periodo de Contrato debe tener 3 meses como minimo y 12 como maximo");
            }
            else if (rpta == "R04") {
                alert("Horas Contratadas deben ser entre 8 y 40");
            }
            else if (rpta == "R05") {
                alert("Verificar que el valor hora corresponda al grado academico")
            }
            else alert("Error al registrar intente de nuevo")
        },
        error: function (data) {
            alert('Se ha producido un error conocido Editar.', 'Mensaje de Error');
        }
    });
};

function ActualizarContrato() {
    var AsignacionFamiliar;
    if ($("#frmActCon #EAsignacionFamiliar").val() == "SI") AsignacionFamiliar = true;
    else AsignacionFamiliar = false;
    $.ajax({
        type: "POST",
        url: "../Gestionar_Contrato/ActualizarContrato",
        data: {
            Id_Empleado: $("#frmActCon #Id_Empleado").val(),
            Id_Contrato: $("#frmActCon #EId_Contrato").val(),
            FechaInicio: $("#frmActCon #EFechaInicio").val(),
            FechaFin: $("#frmActCon #EFechaFin").val(),
            Id_Cargo: $("#frmActCon #EId_Cargo").val(),
            Id_AFP: $("#frmActCon #EId_AFP").val(),
            AsignacionFamiliar: AsignacionFamiliar,
            HorasContratadas: $("#frmActCon #EHorasContratadas").val(),
            ValorHora: $("#frmActCon #EValorHora").val()
        },
        success: function (rpta) {
            if (rpta == "OK") {
                alert("Datos Guardados")
                location.href = "../Gestionar_Contrato/Inicio";
            } else if (rpta == "R02") {
                alert("La Fecha Inicio debe ser superior a la fecha fin de asu anterior Contrato");
            }
            else if (rpta == "R03") {
                alert("El periodo de Contrato debe tener 3 meses como minimo y 12 como maximo");
            }
            else if (rpta == "R04") {
                alert("Horas Contratadas deben ser entre 8 y 40");
            }
            else if (rpta == "R05") {
                alert("Verificar que el valor hora corresponda al grado academico")
            }
            else alert("Error al registrar intente de nuevo")
        },
        error: function (data) {
            alert('Se ha producido un error conocido Editar.', 'Mensaje de Error');
        }
    });
};


function AnularContrato() {
    $.ajax({
        type: "POST",
        url: "../Gestionar_Contrato/AnularContrato",
        data: {
            Id_Contrato: $("#frmAnuCon #AId_Contrato").val(),
        },
        success: function (rpta) {
            if (rpta == "1") {
                alert("Contrato anulado");
                location.href = "../Gestionar_Contrato/Inicio";
            } else {
                alert("Error")
            }
        },
        error: function (data) {
            alert('Se ha producido un error conocido Editar.', 'Mensaje de Error');
        }
    });
};

function CrearContrato() {
    $.ajax({
        url: "../Gestionar_Contrato/CrearContrato",
        data: {
            Id_Empleado: $("#VerEmpleado #Id_Empleado").val()
        },
        type: "POST",
        success: function (response) {
            $("#pnlGrilla").html(response);
        },
        error: function () {
            alert("error");
            //$.toast({
            //    heading: 'Error De Listado',
            //    text: 'Hubo un error al realizar la búsqueda, intente nuevamente',
            //    position: 'top-right',
            //    loaderBg: '#ff2a00',
            //    icon: 'warning',
            //    hideAfter: 4000,
            //    stack: 6
            //});
        }
    });
};

function EditarContrato() {
    $.ajax({
        url: "../Gestionar_Contrato/EditarContrato",
        data: {
            Id_Empleado: $("#VerEmpleado #Id_Empleado").val()
        },
        type: "POST",
        success: function (response) {
            $("#pnlGrilla").html(response);
        },
        error: function () {
            alert("error");
            //$.toast({
            //    heading: 'Error De Listado',
            //    text: 'Hubo un error al realizar la búsqueda, intente nuevamente',
            //    position: 'top-right',
            //    loaderBg: '#ff2a00',
            //    icon: 'warning',
            //    hideAfter: 4000,
            //    stack: 6
            //});
        }
    });
};

function VistaAnularContrato() {
    $.ajax({
        url: "../Gestionar_Contrato/VistaAnularContrato",
        data: {
            Id_Empleado: $("#VerEmpleado #Id_Empleado").val()
        },
        type: "POST",
        success: function (response) {
            $("#pnlGrilla").html(response);
        },
        error: function () {
            alert("error");
            //$.toast({
            //    heading: 'Error De Listado',
            //    text: 'Hubo un error al realizar la búsqueda, intente nuevamente',
            //    position: 'top-right',
            //    loaderBg: '#ff2a00',
            //    icon: 'warning',
            //    hideAfter: 4000,
            //    stack: 6
            //});
        }
    });
};

$("#frmBuscar").on("click", "#btnBusEmp", function (e) {
    e.preventDefault();

    $.ajax({
        //dataType: 'JSON',
        url: "../Gestionar_Empleado/BuscarEmpleado",
        data: {
            DNI: $("#frmBuscar #EDNI").val()
        },
        type: "POST",
        success: function (response) {
            $("#pnlGrilla").html(response);
        },
        error: function () {
            alert("error")
        }
    });

})

