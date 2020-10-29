using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;
using ProyectoV_Vuelos.Models;

namespace ProyectoV_Vuelos.Data
{
    public class ConsecutivosData
    {

        public List<ConsecutivosModel> selectData()
        {
            try
            {
                Consecutivos Consecutivos = new Consecutivos();
                List<ConsecutivosModel> lista =
                Consecutivos.SP_Solicitar_Info_Consecutivos().Tables[0].AsEnumerable().Select(e => new ConsecutivosModel
                {
                    CSVID = e.Field<int>("CSVID"),
                    Consec_Pais = e.Field<int>("Consec_Pais"),
                    Descripcion = e.Field<string>("Descripcion"),
                    Consecutivo = e.Field<string>("Consecutivo"),
                    Prefijo = e.Field<string>("Prefijo"),
                    RangoInicial = e.Field<int>("RangoInicial"),
                    RangoFinal = e.Field<int>("RangoFinal"),

                }).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Valor Null detectado");
                throw;
            }
        }

    }
}