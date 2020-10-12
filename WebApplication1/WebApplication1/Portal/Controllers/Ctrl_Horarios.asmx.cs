using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web.Script.Services;
using CarlosAg.ExcelXmlWriter;
using System.Text;
using LitJson;
using Newtonsoft.Json;
using System.Web;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.IO;
using System.Web.Services;
using WebApplication1.Modelo.Datos;
using WebApplication1.Modelo.Negocio;
using WebApplication1.Modelo.Ayudante;

namespace WebApplication1.Portal.Controllers
{
    /// <summary>
    /// Summary description for Ctrl_Horarios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ctrl_Horarios : System.Web.Services.WebService
    {
        ///******************************************************************************* 
        ///NOMBRE DE LA FUNCIÓN: 
        ///DESCRIPCIÓN:
        ///PARAMETROS:  
        ///CREO:       CHANTAL ORIGEL
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public String Consultar_Socio()
        {
            Operaciones Controlador = new Operaciones();
            Respuesta Obj_Respuesta = new Respuesta();
            Cat_Socios Obj_Socios = new Cat_Socios();
            String Json_Resultado = String.Empty;
            DataTable Dt_Registros = new DataTable();
            try
            {

                string codigo = Sessiones.Codigo_Socio.ToString();
                Dt_Registros = Controlador.Consulta_Socio(codigo);
                if (Dt_Registros != null)
                {
                    if (Dt_Registros.Rows.Count > 0)
                        Obj_Respuesta.Registros = JsonConvert.SerializeObject(Dt_Registros, Newtonsoft.Json.Formatting.None);

                    Obj_Respuesta.Mensaje = "ok";
                    Obj_Respuesta.Estatus = true;
                }
            }
            catch (Exception Ex)
            {
                Obj_Respuesta.Estatus = false;
                Obj_Respuesta.Mensaje = "Consultar Cliente [" + Ex.Message + "]";
            }
            finally
            {
                Json_Resultado = JsonMapper.ToJson(Obj_Respuesta);
            }
            return Json_Resultado;
        }

        ////******************************************************************************* 
        ///NOMBRE DE LA FUNCIÓN: 
        ///DESCRIPCIÓN:
        ///PARAMETROS:  
        ///CREO:       MARIA CHANTAL ORIGEL SEGURA
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************      
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public String Enviar_Horarios(String Datos)
        {
            Semana Obj_Negocios = new Semana();
            Operaciones Obj_Negocio = new Operaciones();
            Respuesta Obj_Resp = new Respuesta();
            JsonSerializerSettings Configuracion_Json = new JsonSerializerSettings();
            Configuracion_Json.NullValueHandling = NullValueHandling.Ignore;
            String Str_Respuesta;
            DataTable Dt_Parametros = new DataTable();

            try
            {
                Obj_Negocios = JsonConvert.DeserializeObject<Semana>(Datos);


                if (Obj_Negocio.Enviar_Horarios(Obj_Negocios))
                {
                    Obj_Resp.Estatus = true;
                    Obj_Resp.Mensaje = "Registro exitoso.";
                }

                Obj_Resp.Estatus = true;
                Obj_Resp.Mensaje = "Registro exitoso.";
            }
            catch (Exception ex)
            {
                //Documento.Close();
                Obj_Resp.Estatus = false;
                Obj_Resp.Mensaje = "Guardar[" + ex.Message + "]";
            }
            finally
            {
                Str_Respuesta = JsonConvert.SerializeObject(Obj_Resp, Formatting.Indented, Configuracion_Json);
            }
            return Str_Respuesta;
        }

        ///******************************************************************************* 
        ///NOMBRE DE LA FUNCIÓN: 
        ///DESCRIPCIÓN:
        ///PARAMETROS:  
        ///CREO:       CHANTAL ORIGEL
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public String HorariosLlenos()
        {
            Operaciones Controlador = new Operaciones();
            Respuesta Obj_Respuesta = new Respuesta();
            Cat_Socios Obj_Socios = new Cat_Socios();
            String Json_Resultado = String.Empty;
            DataTable Dt_Registros = new DataTable();
            try
            {

                string codigo = Sessiones.Codigo_Socio.ToString();
                Dt_Registros = Controlador.HorariosLlenos();
                if (Dt_Registros != null)
                {
                    if (Dt_Registros.Rows.Count > 0)
                        Obj_Respuesta.Registros = JsonConvert.SerializeObject(Dt_Registros, Newtonsoft.Json.Formatting.None);

                    Obj_Respuesta.Mensaje = "ok";
                    Obj_Respuesta.Estatus = true;
                }
            }
            catch (Exception Ex)
            {
                Obj_Respuesta.Estatus = false;
                Obj_Respuesta.Mensaje = "Consultar Cliente [" + Ex.Message + "]";
            }
            finally
            {
                Json_Resultado = JsonMapper.ToJson(Obj_Respuesta);
            }
            return Json_Resultado;
        }
        ///******************************************************************************* 
        ///NOMBRE DE LA FUNCIÓN: 
        ///DESCRIPCIÓN:
        ///PARAMETROS:  
        ///CREO:       CHANTAL ORIGEL
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public String HorariosSeleccionados()
        {
            Operaciones Controlador = new Operaciones();
            Respuesta Obj_Respuesta = new Respuesta();
            Cat_Socios Obj_Socios = new Cat_Socios();
            String Json_Resultado = String.Empty;
            DataTable Dt_Registros = new DataTable();
            try
            {

                Dt_Registros = Controlador.HorariosSeleccionados();
                if (Dt_Registros != null)
                {
                    if (Dt_Registros.Rows.Count > 0)
                        Obj_Respuesta.Registros = JsonConvert.SerializeObject(Dt_Registros, Newtonsoft.Json.Formatting.None);

                    Obj_Respuesta.Mensaje = "ok";
                    Obj_Respuesta.Estatus = true;
                }
            }
            catch (Exception Ex)
            {
                Obj_Respuesta.Estatus = false;
                Obj_Respuesta.Mensaje = "Consultar Cliente [" + Ex.Message + "]";
            }
            finally
            {
                Json_Resultado = JsonMapper.ToJson(Obj_Respuesta);
            }
            return Json_Resultado;
        }
        ///******************************************************************************* 
        ///PROYECTO:Cafeteria Neurologos
        ///NOMBRE DE LA FUNCIÓN: 
        ///DESCRIPCIÓN:
        ///PARAMETROS:  
        ///CREO:       
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public String Consultar_Horarios()
        {
            Operaciones Controlador = new Operaciones();
            Respuesta Obj_Respuesta = new Respuesta();
            String Json_Resultado = String.Empty;
            DataTable Dt_Registros = new DataTable();
            try
            {
                Dt_Registros = Controlador.Consultar_Horarios();
                if (Dt_Registros != null)
                {
                    if (Dt_Registros.Rows.Count > 0)
                        Obj_Respuesta.Registros = JsonConvert.SerializeObject(Dt_Registros, Newtonsoft.Json.Formatting.None);

                    Obj_Respuesta.Mensaje = "ok";
                    Obj_Respuesta.Estatus = true;

                    Obj_Respuesta.data = JsonConvert.SerializeObject(Dt_Registros, Formatting.None);

                }
            }
            catch (Exception Ex)
            {
                Obj_Respuesta.Estatus = false;
                Obj_Respuesta.Mensaje = "Consultar Horarios [" + Ex.Message + "]";
            }
            finally
            {
                Json_Resultado = JsonMapper.ToJson(Obj_Respuesta);
            }
            return Json_Resultado;
        }
        ////******************************************************************************* 
        ///NOMBRE DE LA FUNCIÓN: 
        ///DESCRIPCIÓN:
        ///PARAMETROS:  
        ///CREO:       MARIA CHANTAL ORIGEL SEGURA
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************      
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public String Consultar_Socio_Existencia(String Codigo_Socio)
        {
            Operaciones Controlador = new Operaciones();
            Respuesta Obj_Respuesta = new Respuesta();
            String Json_Resultado = String.Empty;
            DataTable Dt_Registros = new DataTable();

            try
            {
                Dt_Registros = Controlador.Consultar_Socio_Existencia(Codigo_Socio);
                if (Dt_Registros != null)
                {
                    if (Dt_Registros.Rows.Count > 0)
                        Obj_Respuesta.Registros = JsonConvert.SerializeObject(Dt_Registros, Newtonsoft.Json.Formatting.None);

                    Obj_Respuesta.Mensaje = "ok";
                    Obj_Respuesta.Estatus = true;
                }
            }
            catch (Exception Ex)
            {
                Obj_Respuesta.Estatus = false;
                Obj_Respuesta.Mensaje = "Consultar Horarios [" + Ex.Message + "]";
            }
            finally
            {
                Json_Resultado = JsonMapper.ToJson(Obj_Respuesta);
            }
            return Json_Resultado;
        }
        ////******************************************************************************* 
        ///NOMBRE DE LA FUNCIÓN: 
        ///DESCRIPCIÓN:
        ///PARAMETROS:  
        ///CREO:       MARIA CHANTAL ORIGEL SEGURA
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************      
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public String Eliminar_Horario(String Datos)
        {
            Horarios Obj_Negocios = new Horarios();
            Operaciones Obj_Negocio = new Operaciones();
            Respuesta Obj_Resp = new Respuesta();
            JsonSerializerSettings Configuracion_Json = new JsonSerializerSettings();
            Configuracion_Json.NullValueHandling = NullValueHandling.Ignore;
            String Str_Respuesta;
            DataTable Dt_Parametros = new DataTable();

            try
            {
                Obj_Negocios = JsonConvert.DeserializeObject<Horarios>(Datos);


                if (Obj_Negocio.Eliminar_Horario(Obj_Negocios))
                {
                    Obj_Resp.Estatus = true;
                    Obj_Resp.Mensaje = "Registro exitoso.";
                }

                Obj_Resp.Estatus = true;
                Obj_Resp.Mensaje = "Registro exitoso.";
            }
            catch (Exception ex)
            {
                //Documento.Close();
                Obj_Resp.Estatus = false;
                Obj_Resp.Mensaje = "Guardar[" + ex.Message + "]";
            }
            finally
            {
                Str_Respuesta = JsonConvert.SerializeObject(Obj_Resp, Formatting.Indented, Configuracion_Json);
            }
            return Str_Respuesta;
        }

        ///******************************************************************************* 
        ///NOMBRE DE LA FUNCIÓN: 
        ///DESCRIPCIÓN:  
        ///PARAMETROS:  
        ///CREO:
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public String Exportar_Excel()
        {
            Operaciones Controlador = new Operaciones();
            Respuesta Obj_Resp = new Respuesta();
            String Json_Resultado;
            DataTable Dt_Registros = new DataTable();
            JsonSerializerSettings Configuracion_Json = new JsonSerializerSettings();
            Configuracion_Json.NullValueHandling = NullValueHandling.Ignore;

            try
            {
                Dt_Registros = Controlador.Consultar_Horarios_Excel();

                Guid ID = Guid.NewGuid();
                if (Dt_Registros.Rows.Count > 0)
                {
                    Workbook Book_Reporte = new Workbook();
                    String Ruta = HttpContext.Current.Server.MapPath("~") + "\\Temporal";
                    String ruta_plantilla = System.AppDomain.CurrentDomain.BaseDirectory + "Design\\HorariosTemplate.xlsx";
                    String nombre_archivo = "Horarios_"+ ID + ".xlsx";
                    String ruta_almacenamiento = Ruta + "\\" + nombre_archivo;

                    //eiminar todos los archivos
                    System.IO.DirectoryInfo dInfo = new System.IO.DirectoryInfo(@Ruta);
                    foreach (System.IO.FileInfo file in dInfo.GetFiles())
                        file.Delete();

                    //crear el nuevo reporte
                    Crear_Reporte(ruta_plantilla, ruta_almacenamiento, Dt_Registros);

                    if (!Directory.Exists(Ruta))
                        Directory.CreateDirectory(Ruta);

                    //HttpContext.Current.ApplicationInstance.Response.Clear();
                    //HttpContext.Current.ApplicationInstance.Response.Buffer = true;
                    //HttpContext.Current.ApplicationInstance.Response.ContentType = "application/vnd.ms-excel";
                    //HttpContext.Current.ApplicationInstance.Response.AddHeader("Content-Disposition", "attachment; filename=" + nombre_archivo);
                    //HttpContext.Current.ApplicationInstance.Response.Charset = "UTF-8";
                    //HttpContext.Current.ApplicationInstance.Response.ContentEncoding = Encoding.Default;
                    //HttpContext.Current.ApplicationInstance.Response.WriteFile(ruta_almacenamiento);
                    //HttpContext.Current.ApplicationInstance.CompleteRequest();

                    Obj_Resp.Registros = nombre_archivo;
                    Obj_Resp.Estatus = true;
                    Obj_Resp.Mensaje = "Registro exitoso.";

                }
                else
                {
                    Obj_Resp.Mensaje = "No hay datos que mostrar.";
                    Obj_Resp.Estatus = false;
                }
            }
            catch (Exception Ex)
            {
                Obj_Resp.Estatus = false;
                Obj_Resp.Mensaje = "Exportar Excel[" + Ex.Message + "]";
            }
            finally
            {
                Json_Resultado = JsonConvert.SerializeObject(Obj_Resp, Formatting.Indented, Configuracion_Json);

                //Json_Resultado = JsonMapper.ToJson(Obj_Resp);
            }
            return Json_Resultado;
        }


        public void Crear_Reporte(String ruta_plantilla, String ruta_nueva_archivo, System.Data.DataTable Tabla)
        {
            FileInfo template;
            template = new FileInfo(ruta_plantilla);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var date = DateTime.Now;

            using (ExcelPackage p = new ExcelPackage(template, true))
            {

                ExcelWorksheet ws = p.Workbook.Worksheets["Horarios"];

                int renglonL = 3;
                int renglonM = 13;
                int renglonW = 23;
                int renglonJ = 33;
                int renglonV = 43;
                int renglonS = 54;

                var flag = "";

                foreach (DataRow Dr in Tabla.Rows)
                {
                    var codigo = Dr["CodigoID"].ToString();
                    var columna = System.Convert.ToInt32(codigo.Substring(1));

                    if (codigo.Contains("l"))
                    {

                        if (flag == codigo)
                            renglonL++;
                        else
                        {
                            renglonL = 3;
                            flag = codigo;
                        }
                        ws.Cells[renglonL, ++columna].Value = Dr["Codigo_Socio"].ToString();

                    }
                    else if (codigo.Contains("m"))
                    {
                        if (flag == codigo)
                            renglonM++;
                        else
                        {
                            renglonM = 13;
                            flag = codigo;
                        }
                        ws.Cells[renglonM, ++columna].Value = Dr["Codigo_Socio"].ToString();

                    }
                    else if (codigo.Contains("w"))
                    {
                        if (flag == codigo)
                            renglonW++;
                        else
                        {
                            renglonW = 23;
                            flag = codigo;
                        }
                        ws.Cells[renglonW, ++columna].Value = Dr["Codigo_Socio"].ToString();

                    }
                    else if (codigo.Contains("j"))
                    {
                        if (flag == codigo)
                            renglonJ++;
                        else
                        {
                            renglonJ = 33;
                            flag = codigo;
                        }
                        ws.Cells[renglonJ, ++columna].Value = Dr["Codigo_Socio"].ToString();

                    }
                    else if (codigo.Contains("v"))
                    {
                        if (flag == codigo)
                            renglonV++;
                        else
                        {
                            renglonV = 43;
                            flag = codigo;
                        }
                        ws.Cells[renglonV, ++columna].Value = Dr["Codigo_Socio"].ToString();

                    }
                    else if (codigo.Contains("s"))
                    {
                        if (flag == codigo)
                            renglonS++;
                        else
                        {
                            renglonS = 54;
                            flag = codigo;
                        }
                        ws.Cells[renglonS, ++columna].Value = Dr["Codigo_Socio"].ToString();

                    }

                    if (string.IsNullOrEmpty(flag))
                        flag = codigo;

                }

                // guarda los cambios
                Byte[] bin = p.GetAsByteArray();
                String file = ruta_nueva_archivo;
                File.WriteAllBytes(file, bin);
            }
        }
    }
}
