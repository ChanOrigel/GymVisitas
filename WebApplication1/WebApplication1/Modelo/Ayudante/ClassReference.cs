using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Modelo.Ayudante
{
    public class ClassReference
    {
    }
    public class Sessiones
    {
        private static String P_Usuario_ID = "Usuario_ID";
        private static String P_Usuario = "Usuario";
        private static String P_Email = "Email";
        private static String P_Tipo_Usuario = "Rol";


        private static String P_Socio = "Codigo_Socio";
        private static String P_Socio_ID = "Socio_ID";

        public static String Usuario_ID
        {
            get
            {
                if (HttpContext.Current.Session[Sessiones.P_Usuario_ID] == null)
                    return String.Empty;
                else
                    return HttpContext.Current.Session[Sessiones.P_Usuario_ID].ToString();
            }
            set
            {
                HttpContext.Current.Session[Sessiones.P_Usuario_ID] = value;
            }
        }
        public static String Usuario
        {
            get
            {
                if (HttpContext.Current.Session[Sessiones.P_Usuario] == null)
                    return String.Empty;
                else
                    return HttpContext.Current.Session[Sessiones.P_Usuario].ToString();
            }
            set
            {
                HttpContext.Current.Session[Sessiones.P_Usuario] = value;
            }
        }

        public static String Email
        {
            get
            {
                if (HttpContext.Current.Session[Sessiones.P_Email] == null)
                    return String.Empty;
                else
                    return HttpContext.Current.Session[Sessiones.P_Email].ToString();
            }
            set
            {
                HttpContext.Current.Session[Sessiones.P_Email] = value;
            }
        }
        public static String Tipo_Usuario
        {
            get
            {
                if (HttpContext.Current.Session[Sessiones.P_Tipo_Usuario] == null)
                    return String.Empty;
                else
                    return HttpContext.Current.Session[Sessiones.P_Tipo_Usuario].ToString();
            }
            set
            {
                HttpContext.Current.Session[Sessiones.P_Tipo_Usuario] = value;
            }
        }
        public static String Codigo_Socio
        {
            get
            {
                if (HttpContext.Current.Session[Sessiones.P_Socio] == null)
                    return String.Empty;
                else
                    return HttpContext.Current.Session[Sessiones.P_Socio].ToString();
            }
            set
            {
                HttpContext.Current.Session[Sessiones.P_Socio] = value;
            }
        }

        public static String Socio_ID
        {
            get
            {
                if (HttpContext.Current.Session[Sessiones.P_Socio_ID] == null)
                    return String.Empty;
                else
                    return HttpContext.Current.Session[Sessiones.P_Socio_ID].ToString();
            }
            set
            {
                HttpContext.Current.Session[Sessiones.P_Socio_ID] = value;
            }
        }

    }
    public class Respuesta
    {
        public String Mensaje { get; set; }
        public String Registros { get; set; }
        public String Tabla_Registros { get; set; }
        public Boolean Estatus { get; set; }
        public String data { get; set; }
    }

    public class Semana
    {
        public String Lunes { get; set; }
        public String Martes { get; set; }
        public String Miercoles { get; set; }
        public String Jueves { get; set; }
        public String Viernes { get; set; }
        public String Sabado { get; set; }


    }
}