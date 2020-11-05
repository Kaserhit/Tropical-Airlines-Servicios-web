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

        public byte Posee_Prefijo { get; set; }

        public string Prefijo { get; set; }

        public int? RangoInicial { get; set; }

        public int? RangoFinal { get; set; }

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
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else {
                sql = "dbo.SP_Solicitar_Info_Consecutivos";
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else {
                    return ds;
                }
            }                        
        }

        public DataSet SP_Solicitar_Info_Consecutivo()
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "dbo.SP_Solicitar_Info_Consecutivo";
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    return null;
                }
                else
                {
                    return ds;
                }
            }
        }

        public DataSet GenerarConsecutivo(string Descripcion, string Consecutivo, byte Posee_Prefijo, string Prefijo, int RangoInicial, int RangoFinal)
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
     
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Inserta_Consecutivo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@Consecutivo", Consecutivo);
                cmd.Parameters.AddWithValue("@Posee_Prefijo", Posee_Prefijo);
                cmd.Parameters.AddWithValue("@Prefijo", Prefijo);
                cmd.Parameters.AddWithValue("@RangoInicial", RangoInicial);
                cmd.Parameters.AddWithValue("@RangoFinal", RangoFinal);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet ActualizarConsecutivo(int CSVID, string Descripcion, string Consecutivo, byte Posee_Prefijo, string Prefijo, int RangoInicial, int RangoFinal)
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Consecutivo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CSVID", CSVID);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@Consecutivo", Consecutivo);
                cmd.Parameters.AddWithValue("@Posee_Prefijo", Posee_Prefijo);
                cmd.Parameters.AddWithValue("@Prefijo", Prefijo);
                cmd.Parameters.AddWithValue("@RangoInicial", RangoInicial);
                cmd.Parameters.AddWithValue("@RangoFinal", RangoFinal);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                return ds; 
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet EliminarConsecutivo(int CSVID)
        {
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

      

    

