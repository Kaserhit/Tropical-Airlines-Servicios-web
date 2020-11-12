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

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Imagen { get; set; }

        public string Cod_Puerta { get; set; }

        public int Num_Puerta { get; set; }

        public string Detalle { get; set; }

        public int CSVID { get; set; }

        public string Consec_Descripcion { get; set; }

        public string Consecutivo { get; set; }

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
                    sql = "dbo.SP_Solicitar_Info_Bitacoras";
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
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_Info_Bitacoras en la Tabla Bitácora: " + ex);
                throw;
            }
        }

        public DataSet GenerarBitacora(int Consec_Bitacora, int Usuario_Bitac, int Cod_Registro, DateTime Fecha, string Tipo, string Descripcion,
            string Codigo, string Nombre, string Imagen, string Cod_Puerta, int Num_Puerta, string Detalle, int CSVID, string Consec_Descripcion,
            string Consecutivo)
        {
            Errores Error = new Errores();
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
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Imagen", Imagen);
                cmd.Parameters.AddWithValue("@Cod_Puerta", Cod_Puerta);
                cmd.Parameters.AddWithValue("@Num_Puerta", Num_Puerta);
                cmd.Parameters.AddWithValue("@Detalle", Detalle);
                cmd.Parameters.AddWithValue("@CSVID", CSVID);
                cmd.Parameters.AddWithValue("@Consec_Descripcion", Consec_Descripcion);
                cmd.Parameters.AddWithValue("@Consecutivo", Consecutivo);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Inserta_Bitacora en la Tabla Bitácora: " + ex);
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