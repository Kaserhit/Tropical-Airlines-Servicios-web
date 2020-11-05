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
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else {
                sql = "dbo.SP_Solicitar_Info_Paises";
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

        public DataSet SP_Solicitar_Info_Pais()
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "dbo.SP_Solicitar_Info_Pais";
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

        public Pais SP_Solicitar_Filtro_Pais(string Nombre)
        {
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
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet Generar(int Consec_Pais, string CodPais, string Nombre, string Imagen)
        {
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
                return ds;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet Actualizar(int PAISID, int Consec_Pais, string CodPais, string Nombre, string Imagen)
        {
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
                return ds; 
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet Eliminar(int PAISID)
        {
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

    



    

