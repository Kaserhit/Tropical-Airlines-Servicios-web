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
            Errores Error = new Errores();

            try
            {
                conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
                if (conexion == null)
                {
                    Error.GenerarError(DateTime.Now, "Error con la conexión con la base de datos");
                    return null;
                }
                else
                {
                    sql = "dbo.SP_Solicitar_Info_Aeropuertos";
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
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_Info_Aeropuertos en la Tabla Aeropuerto: " + ex);
                throw;
            }
        }

        public Aeropuertos SP_Solicitar_Consec_Aeropuerto(int APTID)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Solicitar_Consec_Aeropuerto", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@APTID", APTID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Aeropuertos aeropuertos = new Aeropuertos();
                    aeropuertos.Consec_Aerop = Convert.ToInt32(dr["consec_aerop"]);
                    return aeropuertos;
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_Consec_Aeropuerto en la Tabla Aeropuerto: " + ex);
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet GenerarAeropuerto(int Consec_Aerop, string Cod_Puerta, int Num_Puerta, string Detalle)
        {
            Errores Error = new Errores();
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
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Inserta_Aeropuerto en la Tabla Aeropuerto: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet ActualizarAeropuerto(int APTID, int Consec_Aerop, string Cod_Puerta, int Num_Puerta, string Detalle)
        {
            Errores Error = new Errores();
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
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_Aeropuerto en la Tabla Aeropuerto: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet EliminarAeropuerto(int APTID)
        {
            Errores Error = new Errores();
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
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Eliminar_Aeropuerto en la Tabla Aeropuerto: " + ex);
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