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
    public class Pais
    {
        #region propiedades

        public int PAISID { get; set; }

        public int Consec_Pais { get; set; }

        public string CodPais { get; set; }

        public string Nombre { get; set; }

        public string Imagen { get; set; }


        #endregion

        #region variables privadas
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region metodos
        public DataSet SP_Solicitar_Info_Paises()
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
                    sql = "dbo.SP_Solicitar_Info_Paises";
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
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_Info_Paises en la Tabla País: " + ex);
                throw;
            }
        }

        public Pais SP_Solicitar_Filtro_Pais(string Nombre)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Solicitar_Filtro_Pais", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Pais pais = new Pais();
                    pais.PAISID = Convert.ToInt32(dr["paisid"]);
                    return pais;
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_Filtro_Pais en la Tabla País: " + ex);
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public Pais SP_Solicitar_Consec_Pais(int PAISID)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Solicitar_Consec_Pais", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PAISID", PAISID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Pais pais = new Pais();
                    pais.Consec_Pais = Convert.ToInt32(dr["consec_pais"]);
                    return pais;
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_Consec_Pais en la Tabla País: " + ex);
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet Generar(int Consec_Pais, string CodPais, string Nombre, string Imagen)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Inserta_Pais", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Consec_Pais", Consec_Pais);
                cmd.Parameters.AddWithValue("@CodPais", CodPais);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Imagen", Imagen);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Inserta_Pais en la Tabla País: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet Actualizar(int PAISID, int Consec_Pais, string CodPais, string Nombre, string Imagen)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Actualiza_Pais", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PAISID", PAISID);
                cmd.Parameters.AddWithValue("@Consec_Pais", Consec_Pais);
                cmd.Parameters.AddWithValue("@CodPais", CodPais);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Imagen", Imagen);

                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Actualiza_Pais en la Tabla País: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet Eliminar(int PAISID)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Eliminar_Pais", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PAISID", PAISID);
                cmd.ExecuteNonQuery();
                return null; // success
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Eliminar_Pais en la Tabla País: " + ex);
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

    }
}

#endregion