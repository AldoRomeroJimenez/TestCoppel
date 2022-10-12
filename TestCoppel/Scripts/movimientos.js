//Movimientos 
//Usando Peticiones Ajax JQuery

function BuscarEmpleado() {
    var NumeroEmpleado = $('#numeroEmpleado').val();
    var data = { numero: NumeroEmpleado }
    $.post(Path.BuscarEmpleado, data).done((data) => {
        LlenarEmpleado(data);
    }).fail(SinResultado).always(() => {
        alert("Busqueda terminada");
    });

}
function LlenarEmpleado(result) {
    $('#nombreEmpleado').val(result.Nombre);
    $('#rolEmpleado').val(result.RolName);
    $('#IdEmpleado').val(result.IdEmpleado);
}
function SinResultado() {
    alert("No se encontraron empleados con ese numero");
}

function Calcular() {
    var idEmpleado=$('#IdEmpleado').val();
    var mes = $('#mesMovimiento').val();
    var Cantidad = $('#cantidadMovimiento').val();

    var data = { IdEmpleado: idEmpleado, Mes: mes, CantidadEntregas: Cantidad }
    $.post(Path.RealizaCalculo, data).done((data) => {
        MostrarResultados(data);
    }).fail(() => { alert("No se encontraron empleados con ese numero"); }).always(() => {
        alert("Calculo realizado");
    });
}
function MostrarResultados(data) {    
    $('#idmovimiento').val(data.IdMovimiento);
    $('#totalmensual').val(data.TotalMensualBruto);
    $('#totalisr').val(data.TotalISR);
    $('#totalneto').val(data.TotalNETO);

}