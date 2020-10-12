using System;
using System.Web;
using System.Data;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using LitJson;
using WebApplication1.Models;
using WebApplication1.Modelo.Datos;
using WebApplication1.Modelo.Negocio;
using WebApplication1.Modelo.Ayudante;

namespace WebApplication1.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }

        ///******************************************************************************* 
        ///NOMBRE DE LA FUNCIÓN: AutentificarUsuario
        ///DESCRIPCIÓN: VALIDA AUTENTIFICACION
        ///PARAMETROS:  
        ///CREO:       
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private String Autentificar()
        {
            Operaciones Controlador = new Operaciones();
            Cat_Usuarios Obj_Negocio = new Cat_Usuarios();
            Respuesta Obj_Respuesta = new Respuesta();
            String Json_Resultado = String.Empty;
            String Json_Object = String.Empty;
            DataTable Dt_Registros = new DataTable();
            String Str_Json = String.Empty;

            try
            {
                Json_Object = HttpUtility.HtmlDecode(HttpContext.Current.Request["Param"] == null ? String.Empty : HttpContext.Current.Request["Param"].ToString().Trim());
                Obj_Negocio = JsonMapper.ToObject<Cat_Usuarios>(Json_Object);
                Dt_Registros = Controlador.Consulta_Usuario(Obj_Negocio);
                if (Dt_Registros != null)
                {
                    if (Dt_Registros.Rows.Count > 0)
                    {
                        if (Dt_Registros.Rows[0]["Estatus"].ToString().Trim().ToUpper() == "ACTIVO")
                        {
                            var result = SignInStatus.Success;

                            switch (result)
                            {
                                case SignInStatus.Success:
                                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                                    break;
                                case SignInStatus.LockedOut:
                                    Response.Redirect("/Account/Lockout");
                                    break;
                                case SignInStatus.RequiresVerification:
                                    Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                                    Request.QueryString["ReturnUrl"],
                                                                    RememberMe.Checked),
                                                      true);
                                    break;
                                case SignInStatus.Failure:
                                default:
                                    FailureText.Text = "Invalid login attempt";
                                    ErrorMessage.Visible = true;
                                    break;
                            }
                            //Obj_Respuesta.Estatus = true;
                            //Sessiones.Usuario_ID = Dt_Registros.Rows[0]["Usuario_ID"].ToString().Trim();
                            //Sessiones.Usuario = Dt_Registros.Rows[0]["Usuario"].ToString().Trim().ToUpper();
                            //Sessiones.Email = Dt_Registros.Rows[0]["Email"].ToString().Trim();
                            //Sessiones.Tipo_Usuario = Dt_Registros.Rows[0]["Rol"].ToString().Trim();
                            //FormsAuthentication.Initialize();
                        }
                        else
                        {
                            Obj_Respuesta.Estatus = false;
                            Obj_Respuesta.Mensaje = "Favor de comunicarse con el área administrativa, para activar su Login";
                        }
                    }
                    else
                    {
                        Obj_Respuesta.Estatus = false;
                        Obj_Respuesta.Mensaje = "Favor de introducir sus datos correctos.";
                    }
                }
                else
                {
                    Obj_Respuesta.Estatus = false;
                    Obj_Respuesta.Mensaje = "Favor de introducir sus datos correctos.";
                }
            }
            catch (Exception Ex)
            {
                Obj_Respuesta.Estatus = false;
                Obj_Respuesta.Mensaje = "Informe técnico - [No se encontró el servidor o éste no estaba accesible]";
            }
            finally
            {
                Json_Resultado = JsonMapper.ToJson(Obj_Respuesta);
            }
            return Json_Resultado;
        }
    }
}