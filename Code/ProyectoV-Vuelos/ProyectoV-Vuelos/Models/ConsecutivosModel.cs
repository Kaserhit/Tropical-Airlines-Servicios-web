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
        public string Descripcion { get; set; }

        [DataMember]
        public string Consecutivo { get; set; }

        [DataMember]
        public byte Posee_Prefijo { get; set; }

        [DataMember]
        public string Prefijo { get; set; }

        [DataMember]
        public int RangoInicial { get; set; }

        [DataMember]
        public int RangoFinal { get; set; }

        #endregion

        #region Constructores

        public ConsecutivosModel(int CSVID, string Descripcion, string Consecutivo, byte Posee_Prefijo, string Prefijo, int RangoInicial, int RangoFinal)
        {
            this.CSVID = CSVID;
            this.Descripcion = Descripcion;
            this.Consecutivo = Consecutivo;
            this.Posee_Prefijo = Posee_Prefijo;
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