using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProyectoV_Vuelos.Models
{
    public class BitacorasModel
    {
        #region Propiedades

        [DataMember]
        public int BTCID { get; set; }

        [DataMember]
        public int Consec_Bitacora { get; set; }

        [DataMember]
        public int Usuario_Bitac { get; set; }

        [DataMember]
        public int Cod_Registro { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public string Tipo { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        #endregion

        #region Constructores

        public BitacorasModel(int BTCID, int Consec_Bitacora, int Usuario_Bitac, int Cod_Registro, DateTime Fecha, string Tipo, string Descripcion)
        {
            this.BTCID = BTCID;
            this.Consec_Bitacora = Consec_Bitacora;
            this.Usuario_Bitac = Usuario_Bitac;
            this.Cod_Registro = Cod_Registro;
            this.Fecha = Fecha;
            this.Tipo = Tipo;
            this.Descripcion = Descripcion;
        }

        public BitacorasModel()
        {
        }

        #endregion
    }
}