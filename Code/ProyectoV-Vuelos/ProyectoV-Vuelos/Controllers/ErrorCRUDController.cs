using BLL;
using ProyectoV_Vuelos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace ProyectoV_Vuelos.Controllers
{
    public class ErrorCRUDController : Controller
    {
        public ActionResult Consulta()
        {
            return View(BuscarErrores());
        }

        public ActionResult Busqueda(FormCollection item)
        {
            DateTime Fecha = Convert.ToDateTime(item["id"]);
            var datos = BuscarErrores().Where(x => x.Fecha == Fecha).Select(x => x).ToList();

            return View("~/Views/ErrorCRUD/Consulta.cshtml", datos);
        }

        public List<ErrorModel> BuscarErrores()
        {
            try
            {
                Errores Error = new Errores();
                List<ErrorModel> lista =
                Error.SP_Solicitar_Info_Errores().Tables[0].AsEnumerable().Select(e => new ErrorModel
                {
                    ERRID = e.Field<int>("ERRID"),
                    Bitac_Error = e.Field<int>("Bitac_Error"),
                    Num_Error = e.Field<int>("Num_Error"),
                    Fecha = e.Field<DateTime>("Fecha"),
                    Mensaje_Error = e.Field<string>("Mensaje_Error"),

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
