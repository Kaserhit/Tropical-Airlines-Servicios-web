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

        public int Bitac_Error { get; set; }

        public int Num_Error { get; set; }

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
            conexion = cls_DAL.trae_conexion("WebDB", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else
            {
                sql = "dbo.SP_Solicitar_Info_Errores";
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

        #endregion
    }
}
