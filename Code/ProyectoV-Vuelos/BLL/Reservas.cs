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
    public class Reservas
    {
        #region Propiedades

        public int RSVID { get; set; }

        public int Reserva_Usuario { get; set; }

        public int Consec_Reserva { get; set; }

        public string Destino { get; set; }

        public int Cant_Boletos { get; set; }

        public float TotalCompra { get; set; }

        public int Num_Reserva { get; set; }

        public string BookingID { get; set; }


        #endregion

        #region Variables Privadas

        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;

        #endregion

        #region Metodos

        public DataSet SP_Solicitar_Info_Reservas()
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
                    sql = "SP_Solicitar_Info_Reservas";
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
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Solicitar_Info_Reservas en la Tabla Reservas: " + ex);
                throw;
            }
        }

   

        public DataSet GenerarReserva(int Reserva_Usuario, int Consec_Reserva, string Destino, int Cant_Boletos, float TotalCompra,
            int Num_Reserva, string BookingID)
        {
            Errores Error = new Errores();
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Inserta_Reservas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Reserva_Usuario", Reserva_Usuario);
                cmd.Parameters.AddWithValue("@Consec_Reserva", Consec_Reserva);
                cmd.Parameters.AddWithValue("@Destino", Destino);
                cmd.Parameters.AddWithValue("@Cant_Boletos", Cant_Boletos);
                cmd.Parameters.AddWithValue("@TotalCompra", TotalCompra);
                cmd.Parameters.AddWithValue("Num_Reserva", Num_Reserva);
                cmd.Parameters.AddWithValue("@BookingID", BookingID);
                cmd.ExecuteNonQuery();
                return null; // success   
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al ejecutar el store procedure SP_Inserta_Reservas en la Tabla Reservas: " + ex);
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
