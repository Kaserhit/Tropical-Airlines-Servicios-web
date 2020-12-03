using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ProyectoV_Vuelos.Models
{
    public class ReservasModel
    {
        #region Propiedades

        [DataMember]
        public int RSVID { get; set; }

        [DataMember]

        public int Reserva_Usuario { get; set; }


        [DataMember]
        public int Consec_Reserva { get; set; }


        [DataMember]
        public string Destino { get; set; }


        [DataMember]
        public int Cant_Boletos { get; set; }


        [DataMember]
        public float TotalCompra { get; set; }


        [DataMember]
        public int Num_Reserva { get; set; }

        [DataMember]

        public string BookingID { get; set; }





        #endregion

        #region constructores
        public ReservasModel(int RSVID, int Reserva_Usuario, int Consec_Reserva, string Destino , int Cant_Boletos, float TotalCompra, int Num_Reserva, string BookingID)
        {
            this.RSVID = RSVID;
            this.Reserva_Usuario = Reserva_Usuario;
            this.Consec_Reserva = Consec_Reserva;
            this.Destino = Destino;
            this.TotalCompra = TotalCompra;
            this.Cant_Boletos = Cant_Boletos;
            this.Num_Reserva = Num_Reserva;
            this.BookingID = BookingID;
        }

        public ReservasModel()
        {
        }

        #endregion
    }
}