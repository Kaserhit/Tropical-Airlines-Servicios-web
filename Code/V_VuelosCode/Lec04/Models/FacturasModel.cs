using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Lec04.Models
{
    public class FacturasModel
    {
     
        #region Propiedades
        [DataMember]
        public int Num_Factura { get; set; }

        [DataMember]
        public DateTime Fecha_Factura { get; set; }

        [DataMember]
        public Decimal Total { get; set; }

        #endregion


        #region constructores
        public FacturasModel(int Num_Factura, string Fecha_Factura, int Total)
        {
            Num_Factura = Num_Factura;
            Fecha_Factura = Fecha_Factura;
            Total = Total;
        }

        public FacturasModel()
        {
        }

        #endregion
    }
}