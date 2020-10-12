<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" Inherits="WebApplication1.Portal.LoginAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>GYM LAYN | Inicia sesión</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no" />
    <meta name="description" content="IMASEN" />
    <meta http-equiv="Content-Language" content="es" />
    <meta name="author" content="" />
    <!--styles -->
    <link href="../Design/Styles.css" rel="stylesheet" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
     <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" runat="server" href="">GYM LAYN</a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li><a runat="server" href="~">Socio</a></li>
                    </ul>
                    <asp:LoginView runat="server" ViewStateMode="Disabled">
                        <AnonymousTemplate>
                            <ul class="nav navbar-nav navbar-right">
                                <li><a runat="server" href="~/Portal/LoginAdmin">Log in</a></li>
                            </ul>
                        </AnonymousTemplate>
                     
                    </asp:LoginView>
                </div>
            </div>
        </div>
    <section class="titulo">
        <div class="titulo--caja">
            <p>GYM LAYN</p>
        </div>
    </section>
    <section>
        <div class="LoginAdmin">
            <div class="LoginAdmin--contenedor">
                <div class="LoginAdmin__leyenda">
                    <p>Ingresa tus datos para acceder al Portal</p>
                </div>
                <div class="LoginAdmin__input">
                    <input type="text" placeholder="Correo electrónico" class="input" name="username" id="Txt_User" />
                    <small>
                        <label style="color: red" class="label-error" id="lbl_error_user"></label>
                    </small>

                    <input type="password" placeholder="Contraseña" class="input" name="password" id="Txt_Password_User" />
                    <small>
                        <label style="color: red" class="label-error" id="lbl_error_password"></label>
                    </small>
                </div>
                <div class="LoginAdmin__boton">
                    <button id="Btn_Entrar" class="botonAdmin" onclick="Validar_Usuario()" type="submit" onclientclick="return false;">Iniciar sesión</button>
                </div>
            </div>
        </div>
    </section>
    <aside>
        <%-- Modal Socio inicio --%>
        <div class="modal" tabindex="-1" role="dialog" id="myModal">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Login No Exitoso!</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div >
                    <div class="modal-body socioModal">
                       <p>El usuario o password es incorrecto</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </aside>
    <footer class="footer"></footer>

  
    <!--  javascript ================================================== -->
    <script src="../Scripts/jquery-3.5.1.min.js"></script>
    <script src="../JS/Login.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

</body>
</html>
<%--<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <script src="../JS/Login.js"></script>


    <section>
        <div class="LoginAdmin">
            <div class="LoginAdmin--contenedor">
                <div class="LoginAdmin__leyenda">
                    <p>Ingresa tus datos para acceder al Portal</p>
                </div>
                <div class="LoginAdmin__input">
                    <input type="text" placeholder="Correo electrónico" class="input" name="username" id="Txt_User" />
                    <small>
                        <label style="color: red" class="label-error" id="lbl_error_user"></label>
                    </small>

                    <input type="password" placeholder="Contraseña" class="input" name="password" id="Txt_Password_User" />
                    <small>
                        <label style="color: red" class="label-error" id="lbl_error_password"></label>
                    </small>
                </div>
                <div class="LoginAdmin__boton">
                    <asp: button id="Btn_Entrar" class="botonAdmin" onclick="Validar_Usuario()" type="submit" runat="server" OnClientClick="return false;">Iniciar sesión</asp:>
                </div>
            </div>
        </div>
    </section>

</asp:Content>--%>
