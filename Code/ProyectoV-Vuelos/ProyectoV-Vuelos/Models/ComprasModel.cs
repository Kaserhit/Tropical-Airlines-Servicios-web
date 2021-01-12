using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProyectoV_Vuelos.Models
{
    public class ComprasModel
    {
        #region Propiedades

        [DataMember]
        public int CMPID { get; set; }

        [DataMember]

        public int Compra_Usuario { get; set; }

        [DataMember]
        public int Consec_Compra { get; set; }

        [DataMember]
        public string Destino { get; set; }

        [DataMember]
        public int Cant_Boletos { get; set; }

        [DataMember]
        public float TotalCompra { get; set; }

        #endregion

        #region constructores
        public ComprasModel(int CMPID, int Compra_Usuario, int Consec_Compra, string Destino, int Cant_Boletos, float TotalCompra)
        {
            this.CMPID = CMPID;
            this.Compra_Usuario = Compra_Usuario;
            this.Consec_Compra = Consec_Compra;
            this.Destino = Destino;
            this.Cant_Boletos = Cant_Boletos;
            this.TotalCompra = TotalCompra;
        }

        public ComprasModel()
        {
        }

        #endregion
    }
}