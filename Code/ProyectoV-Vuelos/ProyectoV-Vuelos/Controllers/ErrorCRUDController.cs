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
            string fechainicio = item["fechainicio"];
            string fechafinal = item["fechafinal"];

            if (fechainicio == "" && fechafinal == "")
            {
                return View("~/Views/ErrorCRUD/Consulta.cshtml", BuscarErrores());
            }
            else
            {
                if (fechainicio != "" && fechafinal != "")
                {
                    var datos = BuscarErrores().Where(x => x.Fecha >= Convert.ToDateTime(fechainicio) && x.Fecha <= Convert.ToDateTime(fechafinal)).Select(x => x).ToList();
                    return View("~/Views/ErrorCRUD/Consulta.cshtml", datos);
                }

                if (fechainicio != "")
                {
                    var datos = BuscarErrores().Where(x => x.Fecha >= Convert.ToDateTime(fechainicio)).Select(x => x).ToList();
                    return View("~/Views/BitacoraCRUD/Consulta.cshtml", datos);
                }

                if (fechafinal != "")
                {
                    var datos = BuscarErrores().Where(x => x.Fecha <= Convert.ToDateTime(fechafinal)).Select(x => x).ToList();
                    return View("~/Views/BitacoraCRUD/Consulta.cshtml", datos);
                }   
            }
            return View("~/Views/ErrorCRUD/Consulta.cshtml", BuscarErrores());
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
