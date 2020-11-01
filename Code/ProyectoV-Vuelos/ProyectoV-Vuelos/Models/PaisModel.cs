﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ProyectoV_Vuelos.Models
{
    public class PaisModel
    {
        #region Propiedades
        [DataMember]
        public int PAISID { get; set; }

        [DataMember]
        public string CodPais { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Imagen { get; set; }



        #endregion

        #region constructores
        public PaisModel(int PAISID, string Nombre, string Imagen, string CodPais)
        {
            this.PAISID = PAISID;
            this.Nombre = Nombre;
            this.Imagen = Imagen;
            this.CodPais = CodPais;


        }

        public PaisModel()
        {
        }

        #endregion
    }
}