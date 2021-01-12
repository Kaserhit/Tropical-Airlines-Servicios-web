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
    public class Errores
    {
        #region Propiedades

        public int ERRID { get; set; }

        public DateTime Fecha { get; set; }

        public string Mensaje_Error { get; set; }

        #endregion

        #region Variables Privadas
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region Metodos

        public DataSet SP_Solicitar_Info_Errores()
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
                    sql = "dbo.SP_Solicitar_Info_Errores";
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
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_Info_Errores en la Tabla Error: " + ex);
                throw;
            }
        }

        public DataSet GenerarError(DateTime Fecha, string Mensaje_Error)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Inserta_Error", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.Parameters.AddWithValue("@Mensaje_Error", Mensaje_Error);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Inserta_Error en la Tabla Error: " + ex);
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