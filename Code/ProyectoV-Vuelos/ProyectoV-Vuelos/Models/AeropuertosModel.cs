using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ProyectoV_Vuelos.Models
{
    public class AeropuertosModel
    {
        #region Propiedades

        [DataMember]
        public int APTID { get; set; }

        [DataMember]
        public int Consec_Aerop { get; set; }

        [DataMember]
        public string Cod_Puerta { get; set; }

        [DataMember]
        public int Num_Puerta { get; set; }

        [DataMember]
        public string Detalle { get; set; }

        #endregion

        #region Constructores

        public AeropuertosModel(int APTID, int Consec_Aerop, string Cod_Puerta, int Num_Puerta, string Detalle)
        {
            this.APTID = APTID;
            this.Consec_Aerop = Consec_Aerop;
            this.Cod_Puerta = Cod_Puerta;
            this.Num_Puerta = Num_Puerta;
            this.Detalle = Detalle;
        }

        public AeropuertosModel()
        {
        }

        #endregion
    }
}