using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpContent.ApplicationBlocks.Data;
using System.Data.SqlClient;
using WebApplication1.Modelo.Negocio;
using WebApplication1.Modelo.Ayudante;


namespace WebApplication1.Modelo.Datos
{
    public class Operaciones
    {

        ///******************************************************************************* 
        ///NOMBRE DE LA FUNCIÓN: Consulta_Usuario
        ///DESCRIPCIÓN: CONSULTAR A lOS USUARIOS REGISTRADOR
        ///PARAMETROS:  
        ///CREO:       CHANTAL ORIGEL
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public DataTable Consulta_Usuario(Cat_Usuarios Dato)
        {
            String Sql = String.Empty;
            DataTable Dt_Registro = new DataTable();
            try
            {
                Sql = "SELECT * FROM Cat_Usuarios";

                if (!String.IsNullOrEmpty(Dato.Email))
                    Sql += " WHERE Email = '" + Dato.Email + "'";

                if (!String.IsNullOrEmpty(Dato.Password))
                {
                    if (Sql.Contains("WHERE"))
                        Sql += " AND Password = '" + Dato.Password + "'";
                    else
                        Sql += " WHERE Password = '" + Dato.Password + "'";
                }

                using (var ctx = new GymDB())
                {
                    var studentName = ctx.Cat_Usuarios.SqlQuery(Sql).FirstOrDefault<Cat_Usuarios>();
                }
                Dt_Registro = SqlHelper.ExecuteDataset(ConexionBD.BD, CommandType.Text, Sql).Tables[0];
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Dt_Registro;
        }

        ///******************************************************************************* 
        ///NOMBRE DE LA FUNCIÓN: Consulta_Usuario
        ///DESCRIPCIÓN: CONSULTAR A lOS USUARIOS REGISTRADOR
        ///PARAMETROS:  
        ///CREO:       CHANTAL ORIGEL
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public DataTable Consulta_Socio(Cat_Socios Dato)
        {
            String Sql = String.Empty;
            DataTable Dt_Registro = new DataTable();
            try
            {
                Sql = "Select ";
                Sql += "convert(varchar, Cat_Socios.Fecha_Fin_Mensualidad, 111) as Fecha_Fin_Mensualidad,  * ";
                Sql += " from Cat_Socios";
                if (!String.IsNullOrEmpty(Dato.Codigo_Socio))
                    Sql += " WHERE Codigo_Socio = '" + Dato.Codigo_Socio + "'";

                Dt_Registro = SqlHelper.ExecuteDataset(ConexionBD.BD, CommandType.Text, Sql).Tables[0];
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Dt_Registro;
        }

        public DataTable Consulta_Socio(string Dato)
        {
            String Sql = String.Empty;
            DataTable Dt_Registro = new DataTable();
            try
            {
                Sql = "Select ";
                Sql += "convert(varchar, Cat_Socios.Fecha_Fin_Mensualidad, 103) as Fecha_Fin_Mensualidad,  * ";
                Sql += " from Cat_Socios";
                if (!String.IsNullOrEmpty(Dato))
                    Sql += " WHERE Codigo_Socio = '" + Dato + "'";

                Dt_Registro = SqlHelper.ExecuteDataset(ConexionBD.BD, CommandType.Text, Sql).Tables[0];
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Dt_Registro;
        }
        ///******************************************************************************* 
        ///NOMBRE DE LA FUNCIÓN: Consulta_Usuario
        ///DESCRIPCIÓN: CONSULTAR A lOS USUARIOS REGISTRADOR
        ///PARAMETROS:  
        ///CREO:       CHANTAL ORIGEL
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public DataTable HorariosLlenos()
        {
            String Sql = String.Empty;
            DataTable Dt_Registro = new DataTable();
            try
            {
                Sql = "select CodigoID, count(CodigoID) from Horarios group by CodigoID having count(CodigoID)=10";

                Dt_Registro = SqlHelper.ExecuteDataset(ConexionBD.BD, CommandType.Text, Sql).Tables[0];
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Dt_Registro;
        }
        ///******************************************************************************* 
        ///NOMBRE DE LA FUNCIÓN: Consulta_Usuario
        ///DESCRIPCIÓN: CONSULTAR A lOS USUARIOS REGISTRADOR
        ///PARAMETROS:  
        ///CREO:       CHANTAL ORIGEL
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public DataTable HorariosSeleccionados()
        {
            String Sql = String.Empty;
            DataTable Dt_Registro = new DataTable();
            try
            {
                if (!String.IsNullOrEmpty(Sessiones.Socio_ID))
                    Sql = "select * from Horarios where Socio_ID='" + Sessiones.Socio_ID + "'";

                Dt_Registro = SqlHelper.ExecuteDataset(ConexionBD.BD, CommandType.Text, Sql).Tables[0];
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Dt_Registro;
        }
        ///******************************************************************************* 
        ///NOMBRE DE LA FUNCIÓN: Consulta_Usuario
        ///DESCRIPCIÓN: CONSULTAR A lOS USUARIOS REGISTRADOR
        ///PARAMETROS:  
        ///CREO:       CHANTAL ORIGEL
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public DataTable Consultar_Horarios()
        {
            String Sql = String.Empty;
            DataTable Dt_Registro = new DataTable();
            try
            {
                Sql = "select Nombre, Codigo_Socio, convert(varchar, Horarios.Fecha_Creo, 103) as Fecha_Creo, ";
                Sql += "Horarios.CodigoID, Dia, Hora from Horarios inner join  Cat_Socios on Horarios.Socio_ID=Cat_Socios.Socio_ID ";
                Sql += "inner join Codigos on Horarios.CodigoID = Codigos.CodigoID order by Cat_Socios.Codigo_Socio";

                Dt_Registro = SqlHelper.ExecuteDataset(ConexionBD.BD, CommandType.Text, Sql).Tables[0];
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Dt_Registro;
        }
        ///******************************************************************************* 
        ///NOMBRE DE LA FUNCIÓN: Consulta_Usuario
        ///DESCRIPCIÓN: CONSULTAR A lOS USUARIOS REGISTRADOR
        ///PARAMETROS:  
        ///CREO:       CHANTAL ORIGEL
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public DataTable Consultar_Horarios_Excel()
        {
            String Sql = String.Empty;
            DataTable Dt_Registro = new DataTable();
            try
            {
                Sql = "select CodigoID, Codigo_Socio from Horarios inner join Cat_Socios on Horarios.Socio_ID= Cat_Socios.Socio_ID order by CodigoID";

                Dt_Registro = SqlHelper.ExecuteDataset(ConexionBD.BD, CommandType.Text, Sql).Tables[0];
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Dt_Registro;
        }
        ///******************************************************************************* 
        ///NOMBRE DE LA FUNCIÓN: Consulta_Usuario
        ///DESCRIPCIÓN: CONSULTAR A lOS USUARIOS REGISTRADOR
        ///PARAMETROS:  
        ///CREO:       CHANTAL ORIGEL
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public DataTable Consultar_Socio_Existencia(string Codigo_Socio)
        {
            String Sql = String.Empty;
            DataTable Dt_Registro = new DataTable();
            try
            {
                Sql = "select * from Horarios inner join Cat_Socios on Horarios.Socio_ID=Cat_Socios.Socio_ID where Codigo_Socio='" + Codigo_Socio + "'";

                Dt_Registro = SqlHelper.ExecuteDataset(ConexionBD.BD, CommandType.Text, Sql).Tables[0];
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Dt_Registro;
        }
        ///******************************************************************************* 
        ///NOMBRE DE LA FUNCIÓN: Consulta_Usuario
        ///DESCRIPCIÓN: CONSULTAR A lOS USUARIOS REGISTRADOR
        ///PARAMETROS:  
        ///CREO:       CHANTAL ORIGEL
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        internal Boolean Eliminar_Horario(Horarios Dato)
        {
            Boolean Transaccion = false;
            SqlTransaction Obj_Transaccion;
            SqlConnection Obj_Conexion = new SqlConnection(ConexionBD.BD);
            SqlCommand Obj_Comando = new SqlCommand();
            String Sql = String.Empty;
            String Estatus = String.Empty;

            Obj_Conexion.Open();
            Obj_Transaccion = Obj_Conexion.BeginTransaction();
            Obj_Comando.Transaction = Obj_Transaccion;
            Obj_Comando.Connection = Obj_Conexion;

            try
            {
                //eliminar algun horario asociado con este socio
                Sql = " DELETE FROM Horarios";
                Sql += " WHERE  Socio_ID = '" + Dato.Socio_ID + "'";
                Obj_Comando.CommandText = Sql;
                Obj_Comando.ExecuteNonQuery();


                Obj_Transaccion.Commit();
                Obj_Conexion.Close();
                Transaccion = true;
            }
            catch (Exception Ex)
            {
                Transaccion = false;
                Obj_Transaccion.Rollback();
                throw new Exception(Ex.Message);
            }
            finally
            {
                if (!Transaccion)
                {
                    Obj_Conexion.Close();
                }
            }
            return Transaccion;
        }

        ///******************************************************************************* 
        ///NOMBRE DE LA FUNCIÓN: Consulta_Usuario
        ///DESCRIPCIÓN: CONSULTAR A lOS USUARIOS REGISTRADOR
        ///PARAMETROS:  
        ///CREO:       CHANTAL ORIGEL
        ///FECHA_CREO:  
        ///MODIFICO: 
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        internal Boolean Enviar_Horarios(Semana Dato)
        {
            Boolean Transaccion = false;
            SqlTransaction Obj_Transaccion;
            SqlConnection Obj_Conexion = new SqlConnection(ConexionBD.BD);
            SqlCommand Obj_Comando = new SqlCommand();
            String Sql = String.Empty;
            String Estatus = String.Empty;

            Obj_Conexion.Open();
            Obj_Transaccion = Obj_Conexion.BeginTransaction();
            Obj_Comando.Transaction = Obj_Transaccion;
            Obj_Comando.Connection = Obj_Conexion;

            try
            {
                //eliminar algun horario asociado con este socio
                Sql = " DELETE FROM Horarios";
                Sql += " WHERE  Socio_ID = '" + Sessiones.Socio_ID + "'";
                Obj_Comando.CommandText = Sql;
                Obj_Comando.ExecuteNonQuery();



                if (!String.IsNullOrEmpty(Dato.Lunes))
                {
                    Sql = "INSERT INTO Horarios (";
                    Sql += " Socio_ID, ";
                    Sql += " CodigoID ";
                    Sql += ") VALUES (";
                    Sql += (String.IsNullOrEmpty(Sessiones.Socio_ID) ? "null, " : "'" + Sessiones.Socio_ID + "', ");
                    Sql += (String.IsNullOrEmpty(Dato.Lunes) ? "null, " : "'" + Dato.Lunes + "' ");
                    Sql += ")";

                    Obj_Comando.CommandText = Sql;
                    Obj_Comando.ExecuteNonQuery();
                }

                if (!String.IsNullOrEmpty(Dato.Martes))
                {
                    Sql = "INSERT INTO Horarios (";
                    Sql += " Socio_ID, ";
                    Sql += " CodigoID ";
                    Sql += ") VALUES (";
                    Sql += (String.IsNullOrEmpty(Sessiones.Socio_ID) ? "null, " : "'" + Sessiones.Socio_ID + "', ");
                    Sql += (String.IsNullOrEmpty(Dato.Martes) ? "null, " : "'" + Dato.Martes + "' ");
                    Sql += ")";

                    Obj_Comando.CommandText = Sql;
                    Obj_Comando.ExecuteNonQuery();
                }
                if (!String.IsNullOrEmpty(Dato.Miercoles))
                {
                    Sql = "INSERT INTO Horarios (";
                    Sql += " Socio_ID, ";
                    Sql += " CodigoID ";
                    Sql += ") VALUES (";
                    Sql += (String.IsNullOrEmpty(Sessiones.Socio_ID) ? "null, " : "'" + Sessiones.Socio_ID + "', ");
                    Sql += (String.IsNullOrEmpty(Dato.Miercoles) ? "null, " : "'" + Dato.Miercoles + "' ");
                    Sql += ")";

                    Obj_Comando.CommandText = Sql;
                    Obj_Comando.ExecuteNonQuery();
                }

                if (!String.IsNullOrEmpty(Dato.Jueves))
                {
                    Sql = "INSERT INTO Horarios (";
                    Sql += " Socio_ID, ";
                    Sql += " CodigoID ";
                    Sql += ") VALUES (";
                    Sql += (String.IsNullOrEmpty(Sessiones.Socio_ID) ? "null, " : "'" + Sessiones.Socio_ID + "', ");
                    Sql += (String.IsNullOrEmpty(Dato.Jueves) ? "null, " : "'" + Dato.Jueves + "' ");
                    Sql += ")";

                    Obj_Comando.CommandText = Sql;
                    Obj_Comando.ExecuteNonQuery();
                }

                if (!String.IsNullOrEmpty(Dato.Viernes))
                {
                    Sql = "INSERT INTO Horarios (";
                    Sql += " Socio_ID, ";
                    Sql += " CodigoID ";
                    Sql += ") VALUES (";
                    Sql += (String.IsNullOrEmpty(Sessiones.Socio_ID) ? "null, " : "'" + Sessiones.Socio_ID + "', ");
                    Sql += (String.IsNullOrEmpty(Dato.Viernes) ? "null, " : "'" + Dato.Viernes + "' ");
                    Sql += ")";

                    Obj_Comando.CommandText = Sql;
                    Obj_Comando.ExecuteNonQuery();
                }

                if (!String.IsNullOrEmpty(Dato.Sabado))
                {
                    Sql = "INSERT INTO Horarios (";
                    Sql += " Socio_ID, ";
                    Sql += " CodigoID ";
                    Sql += ") VALUES (";
                    Sql += (String.IsNullOrEmpty(Sessiones.Socio_ID) ? "null, " : "'" + Sessiones.Socio_ID + "', ");
                    Sql += (String.IsNullOrEmpty(Dato.Sabado) ? "null, " : "'" + Dato.Sabado + "' ");
                    Sql += ")";

                    Obj_Comando.CommandText = Sql;
                    Obj_Comando.ExecuteNonQuery();
                }


                Obj_Transaccion.Commit();
                Obj_Conexion.Close();
                Transaccion = true;
            }
            catch (Exception Ex)
            {
                Transaccion = false;
                Obj_Transaccion.Rollback();
                throw new Exception(Ex.Message);
            }
            finally
            {
                if (!Transaccion)
                {
                    Obj_Conexion.Close();
                }
            }
            return Transaccion;
        }

    }
}