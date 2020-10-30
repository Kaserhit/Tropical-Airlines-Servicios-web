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
    public class Consecutivos
    {
        #region propiedades

        public int CSVID
        {
            get { return CSVID; }
            set { CSVID = value; }
        }

        public int Consec_Pais
        {
            get { return Consec_Pais; }
            set { Consec_Pais = value; }
        }

        public string Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public string Consecutivo
        {
            get { return Consecutivo; }
            set { Consecutivo = value; }
        }

        public string Prefijo
        {
            get { return Prefijo; }
            set { Prefijo = value; }
        }

        public int RangoInicial
        {
            get { return RangoInicial; }
            set { RangoInicial = value; }
        }

        public int RangoFinal
        {
            get { return RangoFinal; }
            set { RangoFinal = value; }
        }

        #endregion

        #region variables privadas
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region metodos
        public DataSet SP_Solicitar_Info_Consecutivos()
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else {
                sql = "dbo.SP_Solicitar_Info_Consecutivos";
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



        public DataSet SP_Inserta_Consecutivo()
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "dbo.SP_Inserta_Consecutivo";
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


        public DataSet GenerarConsecutivo(int Consec_Pais, string Descripcion, string Consecutivo, string Prefijo, int RangoInicial, int RangoFinal)
        {
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
     
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Inserta_Consecutivo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Consec_Pais", Consec_Pais);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@Consecutivo", Consecutivo);
                cmd.Parameters.AddWithValue("@Prefijo", Prefijo);
                cmd.Parameters.AddWithValue("@RangoInicial", RangoInicial);
                cmd.Parameters.AddWithValue("@RangoFinal", RangoFinal);
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

    

