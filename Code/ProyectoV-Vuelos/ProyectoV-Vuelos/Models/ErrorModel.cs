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
        public DateTime Fecha { get; set; }

        [DataMember]
        public string Mensaje_Error { get; set; }

        #endregion

        #region Constructores

        public ErrorModel(int ERRID, DateTime Fecha, string Mensaje_Error)
        {
            this.ERRID = ERRID;
            this.Fecha = Fecha;
            this.Mensaje_Error = Mensaje_Error;
        }

        public ErrorModel()
        {
        }

        #endregion
    }
}