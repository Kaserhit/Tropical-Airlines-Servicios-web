using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ProyectoV_Vuelos.Models
{
    public class ConsecutivosModel
    {
        #region Propiedades
        [DataMember]
        public int CSVID { get; set; }

        [DataMember]
        public int Consec_Pais { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public string Consecutivo { get; set; }

        [DataMember]
        public string Prefijo { get; set; }

        [DataMember]
        public int RangoInicial { get; set; }

        [DataMember]
        public int RangoFinal { get; set; }

        #endregion

        #region constructores
        public ConsecutivosModel(int CSVID, int Consec_Pais, string Descripcion, string Consecutivo, string Prefijo, int RangoInicial, int RangoFinal)
        {
            this.CSVID = CSVID;
            this.Consec_Pais = Consec_Pais;
            this.Descripcion = Descripcion;
            this.Consecutivo = Consecutivo;
            this.Prefijo = Prefijo;
            this.RangoInicial = RangoInicial;
            this.RangoFinal = RangoFinal;

        }

        public ConsecutivosModel()
        {
        }

        #endregion
    }
}