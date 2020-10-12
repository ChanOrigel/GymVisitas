using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace WebApplication1.Modelo.Ayudante
{
    public class ConexionBD
    {
        public static string BD = ConfigurationManager.ConnectionStrings["GymDB"].ConnectionString;  
    }
}