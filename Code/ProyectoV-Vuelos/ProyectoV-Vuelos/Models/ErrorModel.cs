using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProyectoV_Vuelos.Models
{
    public class ErrorModel
    {
        #region Propiedades

        [DataMember]
        public int ERRID { get; set; }

        [DataMember]
        public int Bitac_Error { get; set; }

        [DataMember]
        public int Num_Error { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public string Mensaje_Error { get; set; }

        #endregion

        #region Constructores

        public ErrorModel(int ERRID, int Bitac_Error, int Num_Error, DateTime Fecha, string Mensaje_Error)
        {
            this.ERRID = ERRID;
            this.Bitac_Error = Bitac_Error;
            this.Num_Error = Num_Error;
            this.Fecha = Fecha;
            this.Mensaje_Error = Mensaje_Error;
        }

        public ErrorModel()
        {
        }

        #endregion
    }
}