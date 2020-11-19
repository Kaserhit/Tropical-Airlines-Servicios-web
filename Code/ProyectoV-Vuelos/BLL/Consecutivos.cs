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
    public class Consecutivos
    {
        #region Propiedades

        public int CSVID { get; set; }

        public string Descripcion { get; set; }

        public string Consecutivo { get; set; }

        public string Prefijo { get; set; }

        public int RangoInicial { get; set; }

        public int RangoFinal { get; set; }

        #endregion

        #region Variables Privadas

        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;

        #endregion

        #region Metodos
        public DataSet SP_Solicitar_Info_Consecutivos()
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
                    sql = "dbo.SP_Solicitar_Info_Consecutivos";
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
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_Info_Consecutivos en la Tabla Consecutivo: " + ex);
                throw;
            }
        }

        public DataSet SP_Solicitar_CSVID_Consecutivos()
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
                    sql = "dbo.SP_Solicitar_CSVID_Consecutivos";
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
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_CSVID_Consecutivos en la Tabla Consecutivo: " + ex);
                throw;
            }
        }

        public Consecutivos SP_Solicitar_Consec_ID(int CSVID)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Solicitar_Consec_ID", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CSVID", CSVID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Consecutivos consecutivos = new Consecutivos();
                    consecutivos.CSVID = Convert.ToInt32(dr["csvid"]);
                    return consecutivos;
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_Consec_ID en la Tabla Consecutivo: " + ex);
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet GenerarConsecutivo(string Descripcion, string Consecutivo, string Prefijo, int RangoInicial, int RangoFinal)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Inserta_Consecutivo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@Consecutivo", Consecutivo);
                cmd.Parameters.AddWithValue("@Prefijo", Prefijo);
                cmd.Parameters.AddWithValue("@RangoInicial", RangoInicial);
                cmd.Parameters.AddWithValue("@RangoFinal", RangoFinal);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Inserta_Consecutivo en la Tabla Consecutivo: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet ActualizarConsecutivo(int CSVID, string Descripcion, string Consecutivo, string Prefijo, int RangoInicial, int RangoFinal)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Consecutivo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CSVID", CSVID);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@Consecutivo", Consecutivo);
                cmd.Parameters.AddWithValue("@Prefijo", Prefijo);
                cmd.Parameters.AddWithValue("@RangoInicial", RangoInicial);
                cmd.Parameters.AddWithValue("@RangoFinal", RangoFinal);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_Consecutivo en la Tabla Consecutivo: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet EliminarConsecutivo(int CSVID)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Eliminar_Consecutivo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CSVID", CSVID);
                cmd.ExecuteNonQuery();
                return null; // success
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Eliminar_Consecutivo en la Tabla Consecutivo: " + ex);
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