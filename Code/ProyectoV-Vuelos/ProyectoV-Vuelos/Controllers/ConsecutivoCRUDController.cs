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
    public class ConsecutivoCRUDController : Controller
    {

        public ActionResult Index()
        {
            return View(BuscarConsecutivos());
        }

        public ActionResult Detalles(int id)
        {
            return View(BuscarConsecutivos().Where(e => e.CSVID == id).First());
        }

        public List<ConsecutivosModel> BuscarConsecutivos()
        {
            try
            {
                Consecutivos Consecutivos = new Consecutivos();
                List<ConsecutivosModel> lista =
                Consecutivos.SP_Solicitar_Info_Consecutivos().Tables[0].AsEnumerable().Select(e => new ConsecutivosModel
                {
                    CSVID = e.Field<int>("CSVID"),
                    Descripcion = e.Field<string>("Descripcion"),
                    Consecutivo = e.Field<string>("Consecutivo"),
                    Posee_Prefijo = e.Field<int>("Posee_Prefijo"),
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

        public List<ConsecutivosModel> BuscarConsecutivo()
        {
            try
            {
                Consecutivos Consecutivos = new Consecutivos();
                List<ConsecutivosModel> lista =
                Consecutivos.SP_Solicitar_Info_Consecutivo().Tables[0].AsEnumerable().Select(e => new ConsecutivosModel
                {
                    CSVID = e.Field<int>("CSVID"),
                    Descripcion = e.Field<string>("Descripcion"),
                    Consecutivo = e.Field<string>("Consecutivo"),
                    Posee_Prefijo = e.Field<int>("Posee_Prefijo"),
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

        public ActionResult Generar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Generar(ConsecutivosModel a)
        {
            Consecutivos CSV = new Consecutivos();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                CSV.GenerarConsecutivo(a.Descripcion, a.Consecutivo, a.Posee_Prefijo, a.Prefijo, a.RangoInicial, a.RangoFinal);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Generar Consecutivo", ex);

                return View();
            }

        }

        public ActionResult Actualizar(int id)
        {
            return View(BuscarConsecutivos().Where(e => e.CSVID == id).First());
        }

        [HttpPost]
        public ActionResult Actualizar(ConsecutivosModel a)
        {
            Consecutivos CSV = new Consecutivos();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                CSV.ActualizarConsecutivo(a.CSVID, a.Descripcion, a.Consecutivo, a.Posee_Prefijo, a.Prefijo, a.RangoInicial, a.RangoFinal);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Actualizar Consecutivo", ex);

                return View();
            }

        }

        public ActionResult Eliminar(int id)
        {

            Consecutivos CSV = new Consecutivos();

            CSV.EliminarConsecutivo(id);

            return RedirectToAction("Index");
        }

    }

}
