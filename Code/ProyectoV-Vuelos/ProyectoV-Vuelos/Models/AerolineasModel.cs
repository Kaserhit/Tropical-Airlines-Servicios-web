using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ProyectoV_Vuelos.Models
{
    public class AerolineasModel
    {
        #region Propiedades

        [DataMember]
        public int ALNID { get; set; }

        [DataMember]
        public int Aerol_Pais { get; set; }

        [DataMember]
        public int Consec_Aerol { get; set; }

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Imagen { get; set; }

        #endregion

        #region Constructores

        public AerolineasModel(int ALNID, int Aerol_Pais, int Consec_Aerol, string Codigo, string Nombre, string Imagen)
        {
            this.ALNID = ALNID;
            this.Aerol_Pais = Aerol_Pais;
            this.Consec_Aerol = Consec_Aerol;
            this.Codigo = Codigo;
            this.Nombre = Nombre;
            this.Imagen = Imagen;
        }

        public AerolineasModel()
        {
        }

        #endregion
    }
}