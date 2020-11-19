using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class Seguridad
    {
        #region Propiedades

        public int USRID { get; set; }

        public string Usuario { get; set; }

        public string Contrasena { get; set; }

        public string Nombre { get; set; }

        public string Primer_Apellido { get; set; }

        public string Segundo_Apellido { get; set; }

        public string Pregunta { get; set; }

        public string Respuesta { get; set; }

        public string Correo { get; set; }

        public bool Administrador { get; set; }

        public bool Rol_Seguridad { get; set; }

        public bool Consecutivo { get; set; }

        public bool Mantenimiento { get; set; }

        public bool Consulta { get; set; }

        public bool Cliente { get; set; }

        #endregion

        #region Variables Privadas
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region Metodos
        public DataSet SP_Solicitar_Info_Usuarios()
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                if (conexion == null)
                {
                    Error.GenerarError(DateTime.Now, "Error con la conexión con la base de datos");
                    return null;
                }
                else
                {
                    sql = "dbo.SP_Solicitar_Info_Usuarios";
                    ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref mensaje_error, ref numero_error);
                    if (numero_error != 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        return ds;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_Info_Usuarios en la Tabla Seguridad: " + ex);
                throw;
            }
        }

        public DataSet SP_Solicitar_USRID_Usuarios()
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                if (conexion == null)
                {
                    Error.GenerarError(DateTime.Now, "Error con la conexión con la base de datos");
                    return null;
                }
                else
                {
                    sql = "dbo.SP_Solicitar_USRID_Usuarios";
                    ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref mensaje_error, ref numero_error);
                    if (numero_error != 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        return ds;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_USRID_Usuarios en la Tabla Consecutivo: " + ex);
                throw;
            }
        }

        public DataSet Generar(string Usuario, string Contrasena, string Nombre, string Primer_Apellido, string Segundo_Apellido, string Pregunta, string Respuesta, string Correo)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Inserta_Usuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Contrasena", Contrasena);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Primer_Apellido", Primer_Apellido);
                cmd.Parameters.AddWithValue("@Segundo_Apellido", Segundo_Apellido);
                cmd.Parameters.AddWithValue("@Pregunta", Pregunta);
                cmd.Parameters.AddWithValue("@Respuesta", Respuesta);
                cmd.Parameters.AddWithValue("@Correo", Correo);
                cmd.Parameters.AddWithValue("@Administrador", 0);
                cmd.Parameters.AddWithValue("@Seguridad", 0);
                cmd.Parameters.AddWithValue("@Consecutivo", 0);
                cmd.Parameters.AddWithValue("@Mantenimiento", 0);
                cmd.Parameters.AddWithValue("@Consulta", 0);
                cmd.Parameters.AddWithValue("@Cliente", 1);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Inserta_Usuario en la Tabla Seguridad: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public Boolean Login(string Usuario, string Contrasena)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Login_Usuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter returnParameter = cmd.Parameters.Add("RetVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                cmd.Parameters.Add(new SqlParameter("@Usuario", Usuario));
                cmd.Parameters.Add(new SqlParameter("@Contrasena", Contrasena));

                cmd.ExecuteNonQuery();
                conexion.Close();


                int id = (int)returnParameter.Value;

                if (id == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Login_Usuario en la Tabla Seguridad: " + ex);
                return false;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet Actualizarcontrasena(string contrasena, string newcontrasena)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_contrasena", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                cmd.Parameters.AddWithValue("@newcontrasena", newcontrasena);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_contrasena en la Tabla Seguridad: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet SP_Actualiza_Rol_Administrador(int USRID, bool Administrador)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Rol_Administrador", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USRID", USRID);
                cmd.Parameters.AddWithValue("@Administrador", Administrador);

                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_Rol_Administrador en la Tabla Seguridad: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet SP_Actualiza_Rol_Seguridad(int USRID, bool Seguridad)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Rol_Seguridad", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USRID", USRID);
                cmd.Parameters.AddWithValue("@Seguridad", Seguridad);

                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_Rol_Seguridad en la Tabla Seguridad: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet SP_Actualiza_Rol_Consecutivo(int USRID, bool Consecutivo)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Rol_Consecutivo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USRID", USRID);
                cmd.Parameters.AddWithValue("@Consecutivo", Consecutivo);

                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_Rol_Consecutivo en la Tabla Seguridad: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet SP_Actualiza_Rol_Mantenimiento(int USRID, bool Mantenimiento)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Rol_Mantenimiento", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USRID", USRID);
                cmd.Parameters.AddWithValue("@Mantenimiento", Mantenimiento);

                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_Rol_Mantenimiento en la Tabla Seguridad: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet SP_Actualiza_Rol_Consulta(int USRID, bool Consulta)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Rol_Consulta", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USRID", USRID);
                cmd.Parameters.AddWithValue("@Consulta", Consulta);

                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_Rol_Consulta en la Tabla Seguridad: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet SP_Actualiza_Rol_Cliente(int USRID, bool Cliente)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Rol_Cliente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USRID", USRID);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);

                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_Rol_Cliente en la Tabla Seguridad: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        #endregion
    }
}