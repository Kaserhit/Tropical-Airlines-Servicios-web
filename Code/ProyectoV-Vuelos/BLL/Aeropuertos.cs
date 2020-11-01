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
    public class Aeropuertos
    {
        #region Propiedades

        public int APTID { get; set; }

        public int Consec_Aerop { get; set; }

        public string Cod_Puerta { get; set; }

        public int Num_Puerta { get; set; }

        public string Detalle { get; set; }

        #endregion

        #region Variables Privadas
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region Metodos
        public DataSet SP_Solicitar_Info_Aeropuertos()
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "dbo.SP_Solicitar_Info_Aeropuertos";
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

        public DataSet SP_Solicitar_Info_Aeropuerto()
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "dbo.SP_Solicitar_Info_Aeropuerto";
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

        public DataSet GenerarAeropuerto(int Consec_Aerop, string Cod_Puerta, int Num_Puerta, string Detalle)
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Inserta_Aeropuerto", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Consec_Aerop", Consec_Aerop);
                cmd.Parameters.AddWithValue("@Cod_Puerta", Cod_Puerta);
                cmd.Parameters.AddWithValue("@Num_Puerta", Num_Puerta);
                cmd.Parameters.AddWithValue("@Detalle", Detalle);
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

        public DataSet ActualizarAeropuerto(int APTID, int Consec_Aerop, string Cod_Puerta, int Num_Puerta, string Detalle)
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Aeropuerto", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@APTID", APTID);
                cmd.Parameters.AddWithValue("@Consec_Aerop", Consec_Aerop);
                cmd.Parameters.AddWithValue("@Cod_Puerta", Cod_Puerta);
                cmd.Parameters.AddWithValue("@Num_Puerta", Num_Puerta);
                cmd.Parameters.AddWithValue("@Detalle", Detalle);
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

        public DataSet EliminarAeropuerto(int APTID)
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Eliminar_Aeropuerto", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@APTID", APTID);
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
