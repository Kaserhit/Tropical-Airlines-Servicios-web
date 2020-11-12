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
    public class Aerolineas
    {
        #region Propiedades

        public int ALNID { get; set; }

        public int Aerol_Pais { get; set; }

        public int Consec_Aerol { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Imagen { get; set; }

        #endregion

        #region Variables Privadas
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region Metodos
        public DataSet SP_Solicitar_Info_Aerolineas()
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
                    sql = "dbo.SP_Solicitar_Info_Aerolineas";
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
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_Info_Aerolineas en la Tabla Aerolínea: " + ex);
                throw;
            }
        }

        public Aerolineas SP_Solicitar_Consec_Aerolinea(int ALNID)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Solicitar_Consec_Aerolinea", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ALNID", ALNID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Aerolineas aerolineas = new Aerolineas();
                    aerolineas.Consec_Aerol = Convert.ToInt32(dr["consec_aerol"]);
                    return aerolineas;
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_Consec_Aerolinea en la Tabla Aerolínea: " + ex);
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet GenerarAerolinea(int Aerol_Pais, int Consec_Aerol, string Codigo, string Nombre, string Imagen)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Inserta_Aerolinea", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Aerol_Pais", Aerol_Pais);
                cmd.Parameters.AddWithValue("@Consec_Aerol", Consec_Aerol);
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Imagen", Imagen);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Inserta_Aerolinea en la Tabla Aerolínea: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet ActualizarAerolinea(int ALNID, int Aerol_Pais, int Consec_Aerol, string Codigo, string Nombre, string Imagen)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Aerolinea", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ALNID", ALNID);
                cmd.Parameters.AddWithValue("@Aerol_Pais", Aerol_Pais);
                cmd.Parameters.AddWithValue("@Consec_Aerol", Consec_Aerol);
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Imagen", Imagen);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_Aerolinea en la Tabla Aerolínea: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet EliminarAerolinea(int ALNID)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Eliminar_Aerolinea", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ALNID", ALNID);
                cmd.ExecuteNonQuery();
                return null; // success
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Eliminar_Aerolinea en la Tabla Aerolínea: " + ex);
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