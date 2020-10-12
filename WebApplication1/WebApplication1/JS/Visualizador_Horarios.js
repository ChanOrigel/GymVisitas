$(window).on("load", function () {
    cargar_tabla();
});


/// <summary>
/// FUNCION PARA CARGAR LOS REGISTROS
/// </summary>
function cargar_tabla() {
    var registros = "{}";

    $.ajax({
        url: 'Controllers/Ctrl_Horarios.asmx/Consultar_Horarios',
        //data: "{'Parametros':'" + JSON.stringify(Obj_Param) + "'}",
        method: 'POST',
        cache: false,
        async: true,
        responsive: true,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            if (data.d != undefined && data.d != null) {
                var res = eval("(" + data.d + ")");
                registros = res.Registros;
                llenar_grid(registros);
            }
            //else {
            //    llenar_grid_prod();
            //}
        }
    });
}
/// </summary>
///Llenar tabla
/// </summary>
function llenar_grid(registros) {
    try {
        //PRODUCTOS TABLE///////////////////////////////////////////////////////

        $('#Tbl_Registros').bootstrapTable('destroy');
        $('#Tbl_Registros').bootstrapTable({
            data: JSON.parse(registros),
            method: 'POST',
            height: 420,
            striped: true,
            pagination: true,
            pageSize: 10,
            pageList: [10, 15, 25, 50, 100],
            search: true,
            showColumns: false,
            showRefresh: false,
            minimumCountColumns: 2,
            clickToSelect: true,
            columns: [
                { field: 'Codigo_Socio', title: 'Socio', align: 'left', valign: 'center', sortable: true, clickToSelect: false },
                //{ field: 'Nombre', title: 'Nombre', align: 'left', valign: 'center', sortable: true, clickToSelect: false },
                { field: 'Dia', title: 'Dia', align: 'left', valign: 'center', sortable: true, clickToSelect: false },
                { field: 'Hora', title: 'Hora', align: 'left', valign: 'center', sortable: true, clickToSelect: false },
                { field: 'Fecha_Creo', title: 'Fecha Horario', align: 'left', valign: 'center', sortable: true, clickToSelect: false },

                { title: "CodigoID", visible: false },


            ],
        });

    } catch (e) {
        alert(e);
        //asignar_modal("Tabla Productos", e);
        //jQuery('#modal_mensaje').modal({ backdrop: 'static', keyboard: false });
    }

}

function Verificar() {
    if ($('#cliente').val() == undefined || $('#cliente').val() == "" || $('#cliente').val() == null) {
        $('#myModalNegado').modal('show');
    }
    else {
        try {
            var Codigo_Socio = $('#cliente').val();

            $.ajax({
                url: 'Controllers/Ctrl_Horarios.asmx/Consultar_Socio_Existencia',
                data: "{'Codigo_Socio':'" + Codigo_Socio + "'}",
                type: 'POST',
                cache: false,
                async: true,
                responsive: true,
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    if (data.d != undefined && data.d != null) {
                        var res = eval("(" + data.d + ")");
                        row = JSON.parse(res.Registros);
                        if (row != null) {
                            if (row.length > 0) {
                                $('#socio').val(row[0].Codigo_Socio);
                                $('#Socio_ID').val(row[0].Socio_ID);
                                $('#myModal1').modal('show');
                            }
                        }
                    } else {
                        $('#myModalNegado').modal('show');

                    }
                }
            });

        } catch (e) {
            asignar_modal("", e);
            jQuery('#modal_mensaje').modal({ backdrop: 'static', keyboard: false });
        }
    }


}


function Eliminar_Horario() {
    var Obj_usuario = new Object();

    try {
        Obj_usuario.Socio_ID = $('#Socio_ID').val();

        $.ajax({
            url: 'Controllers/Ctrl_Horarios.asmx/Eliminar_Horario',
            data: "{'Datos':'" + JSON.stringify(Obj_usuario) + "'}",
            type: 'POST',
            cache: false,
            async: true,
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (Resultado) {
                var res = eval("(" + Resultado.d + ")");
                if (res.Estatus) {
                    $('#socio').val('');
                    $('#Socio_ID').val('');
                    $('#cliente').val('');

                    $('#myModalExitoso').modal('show');

                    cargar_tabla();

                }
                else {

                }
            }
        });

    } catch (e) {
        asignar_modal("", e);
        jQuery('#modal_mensaje').modal({ backdrop: 'static', keyboard: false });
    }
}

function Exportar_Excel() {

    try {

        $.ajax({
            url: 'Controllers/Ctrl_Horarios.asmx/Exportar_Excel',
            method: 'POST',
            cache: false,
            async: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function(Resultado) {
                var res = eval("(" + Resultado.d + ")");
                if (res.Estatus) {
                        registros = res.Registros;
                        window.open("../../Temporal/" + registros + "", "FW9", 'toolbar=0,directories=0,menubar=0,status=0,scrollbars=0,resizable=1,width=500,height=100');
                }
            }
            //complete: function (data) {
            //    if (data.d != undefined && data.d != null) {
            //    var res = eval("(" + Resultado.d + ")");
            //        registros = res.Registros;
            //        window.open("../../Temporal/" + registros + "", "FW9", 'toolbar=0,directories=0,menubar=0,status=0,scrollbars=0,resizable=1,width=500,height=100');

            //        //window.open("../../Temporal/Horarios.xlsx", "FW9", 'toolbar=0,directories=0,menubar=0,status=0,scrollbars=0,resizable=1,width=500,height=100');
            //    }
            //}
        });

    } catch (e) {

    }
}