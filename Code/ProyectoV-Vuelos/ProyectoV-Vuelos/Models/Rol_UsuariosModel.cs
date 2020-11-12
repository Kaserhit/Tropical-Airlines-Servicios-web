using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProyectoV_Vuelos.Models
{
    public class Rol_UsuariosModel
    {
        #region Propiedades
        [DataMember]
        public int USRID { get; set; }

        [DataMember]
        public int ROLID { get; set; }

        [DataMember]
        public int Estado { get; set; }

        #endregion

        #region constructores
        public Rol_UsuariosModel(int USRID, int ROLID, int Estado)
        {
            this.USRID = USRID;
            this.ROLID = ROLID;
            this.Estado = Estado;
        }

        public Rol_UsuariosModel()
        {
        }

        #endregion
    }
}