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
    public class Compras
    {
        #region Propiedades

        public int CMPID { get; set; }

        public int Compra_Usuario { get; set; }

        public int Consec_Compra { get; set; }

        public string Destino { get; set; }

        public int Cant_Boletos { get; set; }

        public float TotalCompra { get; set; }

        #endregion

        #region Variables Privadas

        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;

        #endregion

        #region Metodos

        public DataSet SP_Solicitar_Info_Compras()
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
                    sql = "SP_Solicitar_Info_Compras";
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
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_Info_Compras en la Tabla Compra: " + ex);
                throw;
            }
        }



        public DataSet GenerarCompra(int Compra_Usuario, int Consec_Compra, string Destino, int Cant_Boletos, float TotalCompra)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Inserta_Compra", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Compra_Usuario", Compra_Usuario);
                cmd.Parameters.AddWithValue("@Consec_Compra", Consec_Compra);
                cmd.Parameters.AddWithValue("@Destino", Destino);
                cmd.Parameters.AddWithValue("@Cant_Boletos", Cant_Boletos);
                cmd.Parameters.AddWithValue("@TotalCompra", TotalCompra);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Inserta_Compra en la Tabla Compra: " + ex);
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
