/*====================================== INICIO-CARGA =====================================*/
window.onload = function () {
    document.getElementById("texto").focus();
};

//codigo al iniciar la pagina --login--


function Borrar() {
    var texto = $('#texto').val();
    var newText = '';
    if (texto.length >= 1) {
        for (var i = 0; i < texto.length - 1; i++) {
            newText += texto[i];
        }
        $('#texto').val(newText);
    }

}

function AddNumber(number) {
    var texto = $('#texto').val();
    $('#texto').val(texto + number);
}



/// <summary>
/// FUNCION QUE INICIALIZA LOS MANEJADORES DE EVENTOS.
/// </summary>

function eventos() {
   
    $('#entrar').on('click', function (e) {
        e.preventDefault();
        Validar_Socio();
    });

    //$(document).on("keypress", "#Txt_Password", function (e) {
    //    if (e.which == 13) {
    //        Validar_Autenticacion();
    //    }
    //});
}

/// <summary>
/// FUNCION PARA EL LOGIN
/// </summary>
function Validar_Usuario() {
    var valido = true;
    try {
        if ($('#Txt_User').val() == undefined || $('#Txt_User').val() == "" || $('#Txt_User').val() == null) {
            valido = false;
            $('#lbl_error_user').text('Favor de proporcionar su Usuario');
        }

        if ($('#Txt_Password_User').val() == undefined || $('#Txt_Password_User').val() == "" || $('#Txt_Password_User').val() == null) {
            valido = false;
            $('#lbl_error_password').text('Favor de proporcionar la contraseña');
        }

        if (valido) {
            var Parametros = new Array();
            Parametros = new Object();
            Parametros.Email = $('#Txt_User').val();

            Parametros.Password = $('#Txt_Password_User').val();

            $.ajax({
                url: "WebSessions.aspx?Accion=Autentificar&Param=" + JSON.stringify(Parametros),
                method: 'POST',
                cache: false,
                async: true,
                contentType: 'application/json; charset=UTF-8',
                dataType: 'json',
                success: function (resp) {
                    if (resp.Estatus) {
                        window.location.href = 'VisualizarHorarios.aspx';
                    }
                    else {
                        $('#myModal').modal('show');
                    }
                }
            });
        } else {
            $("label").addClass("font-label-error");
        }
    } catch (e) {
        asignar_modal("Informe Técnico", e);
    }
}

/// <summary>
/// FUNCION PARA EL LOGIN
/// </summary>
function Validar_Socio() {
    var valido = true;
    try {
        if ($('#texto').val() == undefined || $('#texto').val() == "" || $('#texto').val() == null) {
            valido = false;
        }

        if (valido) {
            var Parametros = new Array();
            Parametros = new Object();
            Parametros.Codigo_Socio = $('#texto').val();

            $.ajax({
                url: "Portal/WebSessions.aspx?Accion=Socio&Param=" + JSON.stringify(Parametros),
                method: 'POST',
                cache: false,
                async: true,
                contentType: 'application/json; charset=UTF-8',
                dataType: 'json',
                success: function (resp) {
                    if (resp.Estatus) {
                        window.location.href = 'Portal/horarios.aspx';
                    }
                    else {
                        $('#myModal').modal('show');
                        $('#texto').val('');
                    }
                }
            });
        } else {
            $("label").addClass("font-label-error");
        }
    } catch (e) {
        asignar_modal("Informe Técnico", e);
    }
}

/// <summary>
/// CREAR MODAL MENSAJE
/// </summary>
function asignar_modal(titulo, mensaje) {
    $('#title').text('');
    $('#Mensaje').text('');
    $('#title').text(titulo);
    $('#Mensaje').text(mensaje);
}