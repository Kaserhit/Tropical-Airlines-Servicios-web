using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProyectoV_Vuelos.Models
{
    public class VuelosModel
    {
        #region Propiedades

        [DataMember]
        public int VLOID { get; set; }

        [DataMember]
        public int Consec_Vuelo { get; set; }

        [DataMember]
        public int Vuelo_Aerol { get; set; }

        [DataMember]
        public int Vuelo_Aerop { get; set; }

        [DataMember]
        public string CodVuelo { get; set; }

        [DataMember]
        public string Destino { get; set; }

        [DataMember]
        public string Procedencia { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public string Estado_Dest { get; set; }

        [DataMember]
        public string Estado_Proced { get; set; }

        [DataMember]
        public decimal Monto { get; set; }

        #endregion

        #region Constructores

        public VuelosModel(int VLOID, int Consec_Vuelo, int Vuelo_Aerol, int Vuelo_Aerop, string CodVuelo, string Destino, string Procedencia,
            DateTime Fecha, string Estado_Dest, string Estado_Proced, decimal Monto)
        {
            this.VLOID = VLOID;
            this.Consec_Vuelo = Consec_Vuelo;
            this.Vuelo_Aerol = Vuelo_Aerol;
            this.Vuelo_Aerop = Vuelo_Aerop;
            this.CodVuelo = CodVuelo;
            this.Destino = Destino;
            this.Procedencia = Procedencia;
            this.Fecha = Fecha;
            this.Estado_Dest = Estado_Dest;
            this.Estado_Proced = Estado_Proced;
            this.Monto = Monto;
        }

        public VuelosModel()
        {
        }

        #endregion
    }
}