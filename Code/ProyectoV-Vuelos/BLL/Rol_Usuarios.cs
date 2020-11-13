using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Rol_Usuarios
    {
        #region Propiedades

        public int USRID { get; set; }

        public int ROLID { get; set; }

        public bool Estado { get; set; }

        #endregion

        #region Variables Privadas
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region Metodos

        public DataSet SP_Solicitar_Info_Rol_Usuarios()
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
                    sql = "dbo.SP_Solicitar_Info_Rol_Usuarios";
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
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_Info_Rol_Usuarios en la Tabla Rol_Usuario: " + ex);
                throw;
            }
        }

        public DataSet Generar_Rol_Usuarios(int USRID, int ROLID, bool Estado)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Inserta_Rol_Usuarios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USRID", USRID);
                cmd.Parameters.AddWithValue("@ROLID", ROLID);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Inserta_Rol_Usuarios en la Tabla Rol_Usuario: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet SP_Actualiza_Estado_Administrador(int USRID, int ROLID, bool Estado)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Estado_Administrador", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USRID", USRID);
                cmd.Parameters.AddWithValue("@ROLID", ROLID);
                cmd.Parameters.AddWithValue("@Estado", Estado);

                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_Estado_Administrador en la Tabla Rol_Usuario: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet SP_Actualiza_Estado_Seguridad(int USRID, int ROLID, bool Estado)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Estado_Seguridad", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USRID", USRID);
                cmd.Parameters.AddWithValue("@ROLID", ROLID);
                cmd.Parameters.AddWithValue("@Estado", Estado);

                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_Estado_Seguridad en la Tabla Rol_Usuario: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet SP_Actualiza_Estado_Consecutivo(int USRID, int ROLID, bool Estado)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Estado_Consecutivo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USRID", USRID);
                cmd.Parameters.AddWithValue("@ROLID", ROLID);
                cmd.Parameters.AddWithValue("@Estado", Estado);

                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_Estado_Consecutivo en la Tabla Rol_Usuario: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet SP_Actualiza_Estado_Mantenimiento(int USRID, int ROLID, bool Estado)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Estado_Mantenimiento", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USRID", USRID);
                cmd.Parameters.AddWithValue("@ROLID", ROLID);
                cmd.Parameters.AddWithValue("@Estado", Estado);

                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_Estado_Mantenimiento en la Tabla Rol_Usuario: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet SP_Actualiza_Estado_Consultas(int USRID, int ROLID, bool Estado)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Estado_Consultas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USRID", USRID);
                cmd.Parameters.AddWithValue("@ROLID", ROLID);
                cmd.Parameters.AddWithValue("@Estado", Estado);

                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_Estado_Consultas en la Tabla Rol_Usuario: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet SP_Actualiza_Estado_Clientes(int USRID, int ROLID, bool Estado)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Estado_Clientes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USRID", USRID);
                cmd.Parameters.AddWithValue("@ROLID", ROLID);
                cmd.Parameters.AddWithValue("@Estado", Estado);

                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_Estado_Clientes en la Tabla Rol_Usuario: " + ex);
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