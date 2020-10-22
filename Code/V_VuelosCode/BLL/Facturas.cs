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
    public class Facturas
    {
        #region propiedades

        

        public int Num_Factura
        {
            get { return Num_Factura; }
            set { Num_Factura = value; }
        }

      

        public DateTime Fecha_Factura
        {
            get { return Fecha_Factura; }
            set { Fecha_Factura = value; }
        }

     

        public Decimal Total
        {
            get { return Total; }
            set { Total = value; }
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
        public DataSet traer_lista_Facturas()
        {
            conexion = cls_DAL.trae_conexion("Comercio", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                return null;
            }
            else {
                sql = "sp_Trae_Lista_Facturas";
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
        #endregion




        
    }
}
