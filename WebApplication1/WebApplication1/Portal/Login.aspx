<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Portal.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <script src="../JS/Login.js"></script>

       <section class="titulo">
        <div class="subtitulo--caja">
            <p class="texto">Acceder</p>
        </div>
    </section>
    

    <section class="container--teclado">
        <div class="container--teclado__caja">
            <input type="number" class="input" id="texto" maxlength="4" />
        </div>

        <div class="container--teclado__caja">

            <div class="teclado"><button class="button" id="uno" type="button" onclick="AddNumber('1')" >1</button></div>
            <div class="teclado"><button class="button" id="dos" type="button" onclick="AddNumber('2')">2</button></div>
            <div class="teclado"><button class="button" id="tres" type="button" onclick="AddNumber('3')">3</button></div>
            <div class="teclado"><button class="button" id="cuatro" type="button" onclick="AddNumber('4')">4</button></div>
            <div class="teclado"><button class="button" id="cinco" type="button" onclick="AddNumber('5')">5</button></div>
            <div class="teclado"><button class="button" id="seis" type="button" onclick="AddNumber('6')">6</button></div>
            <div class="teclado"><button class="button" id="siete" type="button" onclick="AddNumber('7')">7</button></div>
            <div class="teclado"><button class="button" id="ocho" type="button" onclick="AddNumber('8')">8</button></div>
            <div class="teclado"><button class="button" id="nueve" type="button" onclick="AddNumber('9')">9</button></div>
            <div class="teclado"><button class="button" id="borrar" type="button" onclick="Borrar()">Borrar</button></div>
            <div class="teclado"><button class="button" id="cero" type="button" onclick="AddNumber('0')">0</button></div>
            <div class="teclado"><button class="button" id="entrar" type="button" onclick="Validar_Socio()">Entrar</button></div>
        </div>
    </section>
    <section>
         <%-- Modal Socio inicio --%>
        <div class="modal" tabindex="-1" role="dialog" id="myModal">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Lo sentimos Socio</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                       <p>Su membresia ha caducado, no puede elegir horarios de entrenamiento</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>

    </section>
</asp:Content>
