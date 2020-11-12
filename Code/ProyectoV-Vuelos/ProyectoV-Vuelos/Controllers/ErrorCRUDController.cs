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
            Errores Error = new Errores();

            try
            {
                if (BuscarErrores() != null)
                {
                    return View(BuscarErrores());
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al mostrar el Index en la Tabla Error: " + ex);
                throw;
            }
        }

        public ActionResult Busqueda(FormCollection item)
        {
            Errores Error = new Errores();
            string fechainicio = item["fechainicio"];
            string fechafinal = item["fechafinal"];

            try
            {
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
                        return View("~/Views/ErrorCRUD/Consulta.cshtml", datos);
                    }

                    if (fechafinal != "")
                    {
                        var datos = BuscarErrores().Where(x => x.Fecha <= Convert.ToDateTime(fechafinal)).Select(x => x).ToList();
                        return View("~/Views/ErrorCRUD/Consulta.cshtml", datos);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al realizar la busqueda en la Tabla Error: " + ex);
                throw;
            }
            
            return View("~/Views/ErrorCRUD/Consulta.cshtml", BuscarErrores());
        }

        public List<ErrorModel> BuscarErrores()
        {
            Errores Error = new Errores();

            try
            {
                List<ErrorModel> lista =
                Error.SP_Solicitar_Info_Errores().Tables[0].AsEnumerable().Select(e => new ErrorModel
                {
                    ERRID = e.Field<int>("ERRID"),
                    Fecha = e.Field<DateTime>("Fecha"),
                    Mensaje_Error = e.Field<string>("Mensaje_Error"),

                }).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Valor Null detectado");
                Error.GenerarError(DateTime.Now, "Error al buscar los datos en la Tabla Error: " + ex);
                throw;
            }
        }
    }
}
