using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using System.Runtime.CompilerServices;

namespace BLL
{
    public class Vuelos
    {
        #region Propiedades

        public int VLOID { get; set; }

        public int Consec_Vuelo { get; set; }

        public int Vuelo_Aerol { get; set; }

        public int Vuelo_Aerop { get; set; }

        public string CodVuelo { get; set; }

        public string Destino { get; set; }

        public string Procedencia { get; set; }

        public DateTime Fecha { get; set; }

        public string Estado { get; set; }

        public double Monto { get; set; }

        #endregion

        #region Variables Privadas

        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;

        #endregion

        #region Metodos

        public DataSet SP_Solicitar_Info_Vuelos()
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
                    sql = "dbo.SP_Solicitar_Info_Vuelos";
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
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_Info_Vuelos en la Tabla Vuelo: " + ex);
                throw;
            }
        }

        public Vuelos SP_Solicitar_Consec_Vuelo(int VLOID)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Solicitar_Consec_Vuelo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VLOID", VLOID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Vuelos vuelos = new Vuelos();
                    vuelos.Consec_Vuelo = Convert.ToInt32(dr["consec_vuelo"]);
                    return vuelos;
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_Consec_Vuelo en la Tabla Vuelo: " + ex);
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet GenerarVuelo(int Consec_Vuelo, int Vuelo_Aerol, int Vuelo_Aerop, string CodVuelo, string Destino, string Procedencia,
            DateTime Fecha, string Estado, double Monto)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Inserta_Vuelo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Consec_Vuelo", Consec_Vuelo);
                cmd.Parameters.AddWithValue("@Vuelo_Aerol", Vuelo_Aerol);
                cmd.Parameters.AddWithValue("@Vuelo_Aerop", Vuelo_Aerop);
                cmd.Parameters.AddWithValue("@CodVuelo", CodVuelo);
                cmd.Parameters.AddWithValue("@Destino", Destino);
                cmd.Parameters.AddWithValue("@Procedencia", Procedencia);
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.Parameters.AddWithValue("@Monto", Monto);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Inserta_Vuelo en la Tabla Vuelo: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet ActualizarVuelo(int VLOID, int Consec_Vuelo, int Vuelo_Aerol, int Vuelo_Aerop, string CodVuelo, string Destino, string Procedencia,
            DateTime Fecha, string Estado, double Monto)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Vuelo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VLOID", VLOID);
                cmd.Parameters.AddWithValue("@Consec_Vuelo", Consec_Vuelo);
                cmd.Parameters.AddWithValue("@Vuelo_Aerol", Vuelo_Aerol);
                cmd.Parameters.AddWithValue("@Vuelo_Aerop", Vuelo_Aerop);
                cmd.Parameters.AddWithValue("@CodVuelo", CodVuelo);
                cmd.Parameters.AddWithValue("@Destino", Destino);
                cmd.Parameters.AddWithValue("@Procedencia", Procedencia);
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.Parameters.AddWithValue("@Monto", Monto);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_Vuelo en la Tabla Vuelo: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet EliminarVuelo(int VLOID)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Eliminar_Vuelo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VLOID", VLOID);
                cmd.ExecuteNonQuery();
                return null; // success
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Eliminar_Vuelo en la Tabla Vuelo: " + ex);
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
