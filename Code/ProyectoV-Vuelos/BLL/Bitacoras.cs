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
    public class Bitacoras
    {
        #region Propiedades

        public int BTCID { get; set; }

        public int Consec_Bitacora { get; set; }

        public int Usuario_Bitac { get; set; }

        public int Cod_Registro { get; set; }

        public DateTime Fecha { get; set; }

        public string Tipo { get; set; }

        public string Descripcion { get; set; }

        #endregion

        #region Variables Privadas
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region Metodos
        public DataSet SP_Solicitar_Info_Bitacoras()
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "dbo.SP_Solicitar_Info_Bitacoras";
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

        public DataSet GenerarBitacora(int Consec_Bitacora, int Usuario_Bitac, int Cod_Registro, DateTime Fecha, string Tipo, string Descripcion)
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Inserta_Bitacora", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Consec_Bitacora", Consec_Bitacora);
                cmd.Parameters.AddWithValue("@Usuario_Bitac", Usuario_Bitac);
                cmd.Parameters.AddWithValue("@Cod_Registro", Cod_Registro);
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
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

        public DataSet ActualizarBitacora(int BTCID, int Consec_Bitacora, int Usuario_Bitac, int Cod_Registro, DateTime Fecha, string Tipo, string Descripcion)
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Bitacora", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BTCID", BTCID);
                cmd.Parameters.AddWithValue("@Consec_Bitacora", Consec_Bitacora);
                cmd.Parameters.AddWithValue("@Usuario_Bitac", Usuario_Bitac);
                cmd.Parameters.AddWithValue("@Cod_Registro", Cod_Registro);
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.Parameters.AddWithValue("@Tipo", Tipo);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
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
