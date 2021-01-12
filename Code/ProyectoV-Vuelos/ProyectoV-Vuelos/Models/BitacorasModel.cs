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
        public int Num_Puerta { get; set; }

        [DataMember]
        public string Detalle { get; set; }

        [DataMember]
        public string Consec_Descripcion { get; set; }

        [DataMember]
        public string Consecutivo { get; set; }

        [DataMember]
        public string Destino { get; set; }

        [DataMember]
        public string Procedencia { get; set; }

        [DataMember]
        public DateTime Fecha_Vuelo { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public double Monto { get; set; }

        #endregion

        #region Constructores

        public BitacorasModel(int BTCID, int Consec_Bitacora, int Usuario_Bitac, int Cod_Registro, DateTime Fecha, string Tipo, string Descripcion,
            string Codigo, string Nombre, string Imagen, int Num_Puerta, string Detalle, string Consec_Descripcion,
            string Consecutivo, string Destino, string Procedencia, DateTime Fecha_Vuelo, string Estado, double Monto)
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
            this.Num_Puerta = Num_Puerta;
            this.Detalle = Detalle;
            this.Consec_Descripcion = Consec_Descripcion;
            this.Consecutivo = Consecutivo;
            this.Destino = Destino;
            this.Procedencia = Procedencia;
            this.Fecha_Vuelo = Fecha_Vuelo;
            this.Estado = Estado;
            this.Monto = Monto;
        }

        public BitacorasModel()
        {
        }

        #endregion
    }
}