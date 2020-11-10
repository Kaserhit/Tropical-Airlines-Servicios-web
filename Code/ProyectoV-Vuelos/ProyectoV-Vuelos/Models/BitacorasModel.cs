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

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Imagen { get; set; }

        [DataMember]
        public string Cod_Puerta { get; set; }

        [DataMember]
        public int Num_Puerta { get; set; }

        [DataMember]
        public string Detalle { get; set; }

        [DataMember]
        public int CSVID { get; set; }

        [DataMember]
        public string Consec_Descripcion { get; set; }

        [DataMember]
        public string Consecutivo { get; set; }

        #endregion

        #region Constructores

        public BitacorasModel(int BTCID, int Consec_Bitacora, int Usuario_Bitac, int Cod_Registro, DateTime Fecha, string Tipo, string Descripcion,
            string Codigo, string Nombre, string Imagen, string Cod_Puerta, int Num_Puerta, string Detalle, int CSVID, string Consec_Descripcion,
            string Consecutivo)
        {
            this.BTCID = BTCID;
            this.Consec_Bitacora = Consec_Bitacora;
            this.Usuario_Bitac = Usuario_Bitac;
            this.Cod_Registro = Cod_Registro;
            this.Fecha = Fecha;
            this.Tipo = Tipo;
            this.Descripcion = Descripcion;
            this.Codigo = Codigo;
            this.Nombre = Nombre;
            this.Imagen = Imagen;
            this.Cod_Puerta = Cod_Puerta;
            this.Num_Puerta = Num_Puerta;
            this.Detalle = Detalle;
            this.CSVID = CSVID;
            this.Consec_Descripcion = Consec_Descripcion;
            this.Consecutivo = Consecutivo;
        }

        public BitacorasModel()
        {
        }

        #endregion
    }
}