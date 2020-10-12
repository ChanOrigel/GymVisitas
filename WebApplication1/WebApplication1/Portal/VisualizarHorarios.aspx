<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VisualizarHorarios.aspx.cs" Inherits="WebApplication1.Portal.VisualizadorHorarios" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://unpkg.com/bootstrap-table@1.14.2/dist/bootstrap-table.min.js"></script>
    <script src="../JS/Visualizador_Horarios.js"></script>
    <%--<script src="../JS/Login_Horarios.js"></script>--%>

        <input type="hidden" id="Socio_ID" />

    <section class="titulo">
        <div class="subtitulo--caja">
            <p class="texto">Visualizador de horarios</p>
        </div>
    </section>
    <section class="Eliminar">
        <div class="Eliminar--horario__excel"><button id="Excel" type="button" class="boton--cliente" onclick="Exportar_Excel()">Descargar horarios</button></div>
    </section>
    
    <section class="Eliminar--socio ">
        <div class="Eliminar--horario">
            <div class="cliente-texto">Codigo Socio</div>
            <input type="text" id="cliente" class="cliente"/>
            <button type="button"  class="boton--cliente" onclick="Verificar()">Eliminar Horario</button>
        </div>
    </section>

    <section class="Tabla">
        <div class="table-responsive-md" id="DatosProd">
                <table id="Tbl_Registros" class="table" cellspacing="0" width="70%"></table>
            </div>
    </section>

    <aside>
         <%-- Modal Socio inicio --%>
        <div class="modal" tabindex="-1" role="dialog" id="myModal1">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Ventana de Confirmacion</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div >
                    <div class="modal-body socioModal">
                        <p>Esta seguro de eliminar el horario de entrenamiento del socio?</p>
                        <input type="text" id="socio" class="inputsModal" disabled />
                       
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" onclick="Eliminar_Horario()" data-dismiss="modal">Continuar</button>
                        <button type="button" class="btn btn-secundary" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>


         <div class="modal" tabindex="-1" role="dialog" id="myModalNegado">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Alerta!</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div >
                    <div class="modal-body socioModal">
                        <p>Favor de colocar un numero de socio valido</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>


          <div class="modal" tabindex="-1" role="dialog" id="myModalExitoso">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Ventana de Confirmacion</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div >
                    <div class="modal-body socioModal">
                        <p>Horario eliminado</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
    </aside>
  
</asp:Content>


