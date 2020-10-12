
//$(document).on('ready', function () {
//   //traer info del socio
//    Consultar_Socio();
//    $('#myModal').show();

//});

$(window).on("load", function () {
    Consultar_Socio();
    HorariosLlenos();
    HorariosSeleccionados();
});
//funcion que muestra al cargar la pagina elnombre del socio
function Consultar_Socio() {
    $.ajax({
        url: 'Controllers/Ctrl_Horarios.asmx/Consultar_Socio',
        method: 'POST',
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
                        $("#nombre_socio").val(row[0].Nombre); //+ " su mensualidad vence: " + row[0].Fecha_Fin_Mensualidad)
                        // $('#myModal').show();
                        
                        $('#myModal').modal('show');
                    }

                }
            }
        }
    });
}

//funcion que muestra al cargar la pagina los horarios ya seleccionados
function HorariosLlenos() {
    $.ajax({
        url: 'Controllers/Ctrl_Horarios.asmx/HorariosLlenos',
        method: 'POST',
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
                        for (var i = 0; i < row.length; i++) {
                            DeshabilitarBotones(row[i].CodigoID);
                        }
                    }

                }
            }
        }
    });
}

function DeshabilitarBotones(CodigoID) {
    document.getElementById(CodigoID).disabled = true;
    document.getElementById(CodigoID).style.backgroundColor = '#bcb8b1';
}

//codigo que coloca en verde los horarios actuales del usuario, si es que tiene
function HorariosSeleccionados() {
    $.ajax({
        url: 'Controllers/Ctrl_Horarios.asmx/HorariosSeleccionados',
        method: 'POST',
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
                        for (var i = 0; i < row.length; i++) {
                            BotonesSeleccionados(row[i].CodigoID);
                        }
                    }

                }
            }
        }
    });
}
function BotonesSeleccionados(codigo) {
    document.getElementById(codigo).style.backgroundColor = "#007f5f";

    if (codigo.includes("l")) {
        $("#Lunes").val(codigo);
    }
    if (codigo.includes("m")) {
        $("#Martes").val(codigo);
    }
    if (codigo.includes("w")) {
        $("#Miercoles").val(codigo);
    }
    if (codigo.includes("j")) {
        $("#Jueves").val(codigo);
    }
    if (codigo.includes("v")) {
        $("#Viernes").val(codigo);
    }
    if (codigo.includes("s")) {
        $("#Sabado").val(codigo);
    }
}

// codigo que muestra el modal de confirmacion --horarios--
function modalHorarios() {
    var lunes = $("#Lunes").val();
    var Martes = $("#Martes").val();
    var Miercoles = $("#Miercoles").val();
    var Jueves = $("#Jueves").val();
    var Viernes = $("#Viernes").val();
    var Sabado = $("#Sabado").val();

    if (lunes != "") {
        $('#LunesRow').show();
        switch (lunes) {
            case "l1":
                $("#LH").val("6:00 - 7:30 am");
                break;
            case "l2":
                $("#LH").val("7:30 - 9:00 am");
                break;
            case "l3":
                $("#LH").val("9:00 - 10:30 am");
                break;
            case "l4":
                $("#LH").val("10:30 - 12:00 pm");
                break;
            case "l5":
                $("#LH").val("12:00 - 1:30 pm");
                break;
            case "l6":
                $("#LH").val("1:30 - 3:00 pm");
                break;
            case "l7":
                $("#LH").val("3:00 - 4:30 pm");
                break;
            case "l8":
                $("#LH").val("4:30 - 6:00 pm");
                break;
            case "l9":
                $("#LH").val("6:00 - 7:00 pm");
                break;
            case "l10":
                $("#LH").val("7:00 - 8:00 pm");
                break;
            case "l11":
                $("#LH").val("8:00 - 9:00 pm");
                break;

        }
    }
    else {
        $('#LunesRow').hide();
    }

    if (Martes != "") {
        $('#MartesRow').show();
        switch (Martes) {
            case "m1":
                $("#MH").val("6:00 - 7:30 am");
                break;
            case "m2":
                $("#MH").val("7:30 - 9:00 am");
                break;
            case "m3":
                $("#MH").val("9:00 - 10:30 am");
                break;
            case "m4":
                $("#MH").val("10:30 - 12:00 pm");
                break;
            case "m5":
                $("#MH").val("12:00 - 1:30 pm");
                break;
            case "m6":
                $("#MH").val("1:30 - 3:00 pm");
                break;
            case "m7":
                $("#MH").val("3:00 - 4:30 pm");
                break;
            case "m8":
                $("#MH").val("4:30 - 6:00 pm");
                break;
            case "m9":
                $("#MH").val("6:00 - 7:00 pm");
                break;
            case "m10":
                $("#MH").val("7:00 - 8:00 pm");
                break;
            case "m11":
                $("#MH").val("8:00 - 9:00 pm");
                break;
        }
    } else {
        $('#MartesRow').hide();
    }

    if (Miercoles != "") {
        $('#MiercolesRow').show();
        switch (Miercoles) {
            case "w1":
                $("#WH").val("6:00 - 7:30 am");
                break;
            case "w2":
                $("#WH").val("7:30 - 9:00 am");
                break;
            case "w3":
                $("#WH").val("9:00 - 10:30 am");
                break;
            case "w4":
                $("#WH").val("10:30 - 12:00 pm");
                break;
            case "w5":
                $("#WH").val("12:00 - 1:30 pm");
                break;
            case "w6":
                $("#WH").val("1:30 - 3:00 pm");
                break;
            case "w7":
                $("#WH").val("3:00 - 4:30 pm");
                break;
            case "w8":
                $("#WH").val("4:30 - 6:00 pm");
                break;
            case "w9":
                $("#WH").val("6:00 - 7:00 pm");
                break;
            case "w10":
                $("#WH").val("7:00 - 8:00 pm");
                break;
            case "w11":
                $("#WH").val("8:00 - 9:00 pm");
                break;
        }
    } else {
        $('#MiercolesRow').hide();
    }

    if (Jueves != "") {
        $('#JuevesRow').show();
        switch (Jueves) {
            case "j1":
                $("#JH").val("6:00 - 7:30 am");
                break;
            case "j2":
                $("#JH").val("7:30 - 9:00 am");
                break;
            case "j3":
                $("#JH").val("9:00 - 10:30 am");
                break;
            case "j4":
                $("#JH").val("10:30 - 12:00 pm");
                break;
            case "j5":
                $("#JH").val("12:00 - 1:30 pm");
                break;
            case "j6":
                $("#JH").val("1:30 - 3:00 pm");
                break;
            case "j7":
                $("#JH").val("3:00 - 4:30 pm");
                break;
            case "j8":
                $("#JH").val("4:30 - 6:00 pm");
                break;
            case "j9":
                $("#JH").val("6:00 - 7:00 pm");
                break;
            case "j10":
                $("#JH").val("7:00 - 8:00 pm");
                break;
            case "j11":
                $("#JH").val("8:00 - 9:00 pm");
                break;

        }
    } else {
        $('#JuevesRow').hide();
    }

    if (Viernes != "") {
        $('#ViernesRow').show();
        switch (Viernes) {
            case "v1":
                $("#VH").val("6:00 - 7:30 am");
                break;
            case "v2":
                $("#VH").val("7:30 - 9:00 am");
                break;
            case "v3":
                $("#VH").val("9:00 - 10:30 am");
                break;
            case "v4":
                $("#VH").val("10:30 - 12:00 pm");
                break;
            case "v5":
                $("#VH").val("12:00 - 1:30 pm");
                break;
            case "v6":
                $("#VH").val("1:30 - 3:00 pm");
                break;
            case "v7":
                $("#VH").val("3:00 - 4:30 pm");
                break;
            case "v8":
                $("#VH").val("4:30 - 6:00 pm");
                break;
            case "v9":
                $("#VH").val("6:00 - 7:00 pm");
                break;
            case "v10":
                $("#VH").val("7:00 - 8:00 pm");
                break;
            case "v11":
                $("#VH").val("8:00 - 9:00 pm");
                break;
        }
    } else {
        $('#ViernesRow').hide();
    }

    if (Sabado != "") {
        $('#SabadoRow').show();
        switch (Sabado) {
            case "s1":
                $("#SH").val("7:00 - 8:30 am");
                break;
            case "s2":
                $("#SH").val("8:30 - 10:00 am");
                break;
            case "s3":
                $("#SH").val("10:00 - 11:30 am");
                break;
            case "s4":
                $("#SH").val("11:30 - 1:00 pm");
                break;
        }
    } else {
        $('#SabadoRow').hide();
    }
}

//codigo que limpia los horarios seleccionados
function limpiar() {
    for (var i = 1; i <= 11; i++) {
        document.getElementById("l" + i).style.backgroundColor = "white";
    }
    for (var i = 1; i <= 11; i++) {
        document.getElementById("m" + i).style.backgroundColor = "white";
    }
    for (var i = 1; i <= 11; i++) {
        document.getElementById("w" + i).style.backgroundColor = "white";
    }
    for (var i = 1; i <= 11; i++) {
        document.getElementById("j" + i).style.backgroundColor = "white";
    }
    for (var i = 1; i <= 11; i++) {
        document.getElementById("v" + i).style.backgroundColor = "white";
    }
    for (var i = 1; i <= 4; i++) {
        document.getElementById("s" + i).style.backgroundColor = "white";
    }
    $("#Lunes").val('');
    $("#Martes").val('');
    $("#Miercoles").val('');
    $("#Jueves").val('');
    $("#Viernes").val('');
    $("#Sabado").val('');

    HorariosLlenos();
    HorariosSeleccionados();
}
//codigo de los botones al ser seleccionados pantalla --horarios--

function Botones(codigo) {

    if (codigo.includes("l")) {
        for (var i = 1; i <= 11; i++) {

            if (document.getElementById("l" + i).disabled)
                document.getElementById("l" + i).style.backgroundColor = '#bcb8b1';
            else
                document.getElementById("l" + i).style.backgroundColor = "white";
        }
        document.getElementById(codigo).style.backgroundColor = "#007f5f";
        $("#Lunes").val(codigo);
    }
    if (codigo.includes("m")) {
        for (var i = 1; i <= 11; i++) {

            if (document.getElementById("m" + i).disabled)
                document.getElementById("m" + i).style.backgroundColor = '#bcb8b1';
            else
                document.getElementById("m" + i).style.backgroundColor = "white";
        }
        document.getElementById(codigo).style.backgroundColor = "#007f5f";
        $("#Martes").val(codigo);
    }
    if (codigo.includes("w")) {
        for (var i = 1; i <= 11; i++) {

            if (document.getElementById("w" + i).disabled)
                document.getElementById("w" + i).style.backgroundColor = '#bcb8b1';
            else
                document.getElementById("w" + i).style.backgroundColor = "white";
        }
        document.getElementById(codigo).style.backgroundColor = "#007f5f";
        $("#Miercoles").val(codigo);
    }
    if (codigo.includes("j")) {
        for (var i = 1; i <= 11; i++) {

            if (document.getElementById("j" + i).disabled)
                document.getElementById("j" + i).style.backgroundColor = '#bcb8b1';
            else
                document.getElementById("j" + i).style.backgroundColor = "white";
        }
        document.getElementById(codigo).style.backgroundColor = "#007f5f";
        $("#Jueves").val(codigo);
    }
    if (codigo.includes("v")) {
        for (var i = 1; i <= 11; i++) {

            if (document.getElementById("v" + i).disabled)
                document.getElementById("v" + i).style.backgroundColor = '#bcb8b1';
            else
                document.getElementById("v" + i).style.backgroundColor = "white";
        }
        document.getElementById(codigo).style.backgroundColor = "#007f5f";
        $("#Viernes").val(codigo);
    }
    if (codigo.includes("s")) {
        for (var i = 1; i <= 4; i++) {

            if (document.getElementById("s" + i).disabled)
                document.getElementById("s" + i).style.backgroundColor = '#bcb8b1';
            else
                document.getElementById("s" + i).style.backgroundColor = "white";
        }
        document.getElementById(codigo).style.backgroundColor = "#007f5f";
        $("#Sabado").val(codigo);
    }
}

//CODIGO QUE GUARDA LOS HORARIOS
function Enviar_Horarios() {
    var Obj_usuario = new Object();

    try {
        Obj_usuario.Lunes = $('#Lunes').val();
        Obj_usuario.Martes = $('#Martes').val();
        Obj_usuario.Miercoles = $('#Miercoles').val();
        Obj_usuario.Jueves = $('#Jueves').val();
        Obj_usuario.Viernes = $('#Viernes').val();
        Obj_usuario.Sabado = $('#Sabado').val();


        $.ajax({
            url: 'Controllers/Ctrl_Horarios.asmx/Enviar_Horarios',
            data: "{'Datos':'" + JSON.stringify(Obj_usuario) + "'}",
            type: 'POST',
            cache: false,
            async: true,
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (Resultado) {
                var res = eval("(" + Resultado.d + ")");
                if (res.Estatus) {
                    $('#modalExito').modal({
                        backdrop: 'static',
                        keyboard: false
                    })
                }
                else {
                   
                }
            }
        });

    } catch (e) {
       
    }
}

$(function () {

    //CODIGO QUE HACE QUE FUNCIONEN LOS CARRUSELES --horarios--
    const buttonPrev_L = document.getElementById('button-prev-L');
    const buttonNext_L = document.getElementById('button-next-L');
    const track_L = document.getElementById('track-L');
    const slickList_L = document.getElementById('slick-list-L');
    const slick_L = document.querySelectorAll('.slick-L');

    const slickWidth_L = slick_L[0].offsetWidth;

    buttonPrev_L.onclick = () => MoveL(1);
    buttonNext_L.onclick = () => MoveL(2);

    function MoveL(value) {
        const trackWidth = track_L.offsetWidth;
        const listWidth = slickList_L.offsetWidth;

        track_L.style.left == "" ? leftPosition = track_L.style.left = 0 : leftPosition = parseFloat(track_L.style.left.slice(0, -2) * -1);

        if (leftPosition < (trackWidth - listWidth) && value == 2) {
            track_L.style.left = `${-1 * (leftPosition + slickWidth_L)}px`;
        } else if (leftPosition > 0 && value == 1) {
            track_L.style.left = `${-1 * (leftPosition - slickWidth_L)}px`;
        }
    }



    const buttonPrev_M = document.getElementById('button-prev-M');
    const buttonNext_M = document.getElementById('button-next-M');
    const track_M = document.getElementById('track-M');
    const slickList_M = document.getElementById('slick-list-M');
    const slick_M = document.querySelectorAll('.slick-M');

    const slickWidth_M = slick_M[0].offsetWidth;

    buttonPrev_M.onclick = () => MoveM(1);
    buttonNext_M.onclick = () => MoveM(2);

    function MoveM(value) {
        const trackWidth = track_M.offsetWidth;
        const listWidth = slickList_M.offsetWidth;

        track_M.style.left == "" ? leftPosition = track_M.style.left = 0 : leftPosition = parseFloat(track_M.style.left.slice(0, -2) * -1);

        if (leftPosition < (trackWidth - listWidth) && value == 2) {
            track_M.style.left = `${-1 * (leftPosition + slickWidth_M)}px`;
        } else if (leftPosition > 0 && value == 1) {
            track_M.style.left = `${-1 * (leftPosition - slickWidth_M)}px`;
        }
    }




    const buttonPrev_W = document.getElementById('button-prev-W');
    const buttonNext_W = document.getElementById('button-next-W');
    const track_W = document.getElementById('track-W');
    const slickList_W = document.getElementById('slick-list-W');
    const slick_W = document.querySelectorAll('.slick-W');

    const slickWidth_W = slick_W[0].offsetWidth;

    buttonPrev_W.onclick = () => MoveW(1);
    buttonNext_W.onclick = () => MoveW(2);

    function MoveW(value) {
        const trackWidth = track_W.offsetWidth;
        const listWidth = slickList_W.offsetWidth;

        track_W.style.left == "" ? leftPosition = track_W.style.left = 0 : leftPosition = parseFloat(track_W.style.left.slice(0, -2) * -1);

        if (leftPosition < (trackWidth - listWidth) && value == 2) {
            track_W.style.left = `${-1 * (leftPosition + slickWidth_W)}px`;
        } else if (leftPosition > 0 && value == 1) {
            track_W.style.left = `${-1 * (leftPosition - slickWidth_W)}px`;
        }
    }




    const buttonPrev_J = document.getElementById('button-prev-J');
    const buttonNext_J = document.getElementById('button-next-J');
    const track_J = document.getElementById('track-J');
    const slickList_J = document.getElementById('slick-list-J');
    const slick_J = document.querySelectorAll('.slick-J');

    const slickWidth_J = slick_J[0].offsetWidth;

    buttonPrev_J.onclick = () => MoveJ(1);
    buttonNext_J.onclick = () => MoveJ(2);

    function MoveJ(value) {
        const trackWidth = track_J.offsetWidth;
        const listWidth = slickList_J.offsetWidth;

        track_J.style.left == "" ? leftPosition = track_J.style.left = 0 : leftPosition = parseFloat(track_J.style.left.slice(0, -2) * -1);

        if (leftPosition < (trackWidth - listWidth) && value == 2) {
            track_J.style.left = `${-1 * (leftPosition + slickWidth_J)}px`;
        } else if (leftPosition > 0 && value == 1) {
            track_J.style.left = `${-1 * (leftPosition - slickWidth_J)}px`;
        }
    }



    const buttonPrev_V = document.getElementById('button-prev-V');
    const buttonNext_V = document.getElementById('button-next-V');
    const track_V = document.getElementById('track-V');
    const slickList_V = document.getElementById('slick-list-V');
    const slick_V = document.querySelectorAll('.slick-V');

    const slickWidth_V = slick_V[0].offsetWidth;

    buttonPrev_V.onclick = () => MoveV(1);
    buttonNext_V.onclick = () => MoveV(2);

    function MoveV(value) {
        const trackWidth = track_V.offsetWidth;
        const listWidth = slickList_V.offsetWidth;

        track_V.style.left == "" ? leftPosition = track_V.style.left = 0 : leftPosition = parseFloat(track_V.style.left.slice(0, -2) * -1);

        if (leftPosition < (trackWidth - listWidth) && value == 2) {
            track_V.style.left = `${-1 * (leftPosition + slickWidth_V)}px`;
        } else if (leftPosition > 0 && value == 1) {
            track_V.style.left = `${-1 * (leftPosition - slickWidth_V)}px`;
        }
    }


    const buttonPrev_S = document.getElementById('button-prev-S');
    const buttonNext_S = document.getElementById('button-next-S');
    const track_S = document.getElementById('track-S');
    const slickList_S = document.getElementById('slick-list-S');
    const slick_S = document.querySelectorAll('.slick-S');

    const slickWidth_S = slick_S[0].offsetWidth;

    buttonPrev_S.onclick = () => MoveS(1);
    buttonNext_S.onclick = () => MoveS(2);

    function MoveS(value) {
        const trackWidth = track_S.offsetWidth;
        const listWidth = slickList_S.offsetWidth;

        track_S.style.left == "" ? leftPosition = track_S.style.left = 0 : leftPosition = parseFloat(track_S.style.left.slice(0, -2) * -1);

        if (leftPosition < (trackWidth - listWidth) && value == 2) {
            track_S.style.left = `${-1 * (leftPosition + slickWidth_S)}px`;
        } else if (leftPosition > 0 && value == 1) {
            track_S.style.left = `${-1 * (leftPosition - slickWidth_S)}px`;
        }
    }


});






