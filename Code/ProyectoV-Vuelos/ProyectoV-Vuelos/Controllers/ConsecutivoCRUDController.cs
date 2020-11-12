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
            Errores Error = new Errores();

            try
            {
                if (BuscarConsecutivos() != null)
                {
                    return View(BuscarConsecutivos());
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al mostrar el Index en la Tabla Consecutivo: " + ex);
                throw;
            }
        }

        public List<ConsecutivosModel> BuscarConsecutivos()
        {
            Errores Error = new Errores();

            try
            {
                Consecutivos Consecutivos = new Consecutivos();
                List<ConsecutivosModel> lista =
                Consecutivos.SP_Solicitar_Info_Consecutivos().Tables[0].AsEnumerable().Select(e => new ConsecutivosModel
                {
                    CSVID = e.Field<int>("CSVID"),
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
                Error.GenerarError(DateTime.Now, "Error al buscar los consecutivos en la Tabla Consecutivo: " + ex);
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
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                if (a.Prefijo == null)
                {
                    a.Prefijo = "No";
                }


                if (a.RangoInicial > a.RangoFinal)
                {
                    return View("");
                }

                CSV.GenerarConsecutivo(a.Descripcion, a.Consecutivo, a.Prefijo, a.RangoInicial, a.RangoFinal);
                BTC.GenerarBitacora(a.CSVID, 1, 1, DateTime.Now, "Agregar", "Inserción de un nuevo Consecutivo",
                "", "", "", "", 0, "", a.CSVID, a.Descripcion, a.Consecutivo);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Generar Consecutivo", ex);
                Error.GenerarError(DateTime.Now, "Error al generar un nuevo consecutivo en la Tabla Consecutivo: " + ex);
                return View();
            }

        }

        public ActionResult Actualizar(int id)
        {
            Errores Error = new Errores();

            try
            {
                if (BuscarConsecutivos().Where(e => e.CSVID == id).First() != null)
                {
                    return View(BuscarConsecutivos().Where(e => e.CSVID == id).First());
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al buscar un consecutivo en la Tabla Consecutivo: " + ex);
                throw;
            }
            
        }

        [HttpPost]
        public ActionResult Actualizar(ConsecutivosModel a)
        {
            Consecutivos CSV = new Consecutivos();
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                if (a.Prefijo == null)
                {
                    a.Prefijo = "No";
                }

                if (a.RangoInicial > a.RangoFinal)
                {
                    return View("");
                }

                CSV.ActualizarConsecutivo(a.CSVID, a.Descripcion, a.Consecutivo, a.Prefijo, a.RangoInicial, a.RangoFinal);
                BTC.GenerarBitacora(a.CSVID, 1, 2, DateTime.Now, "Modificar", "Modificación de un Consecutivo",
                "", "", "", "", 0, "", a.CSVID, a.Descripcion, a.Consecutivo);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Actualizar Consecutivo", ex);
                Error.GenerarError(DateTime.Now, "Error al actualizar un consecutivo en la Tabla Consecutivo: " + ex);
                return View();
            }

        }

        public ActionResult Eliminar(int id)
        {
            Consecutivos CSV = new Consecutivos();
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            try
            {
                BTC.GenerarBitacora(CSV.SP_Solicitar_Consec_ID(id).CSVID, 1, 3, DateTime.Now, "Eliminar", "Eliminación de un Consecutivo",
                                "", "", "", "", 0, "", 0, "", "");
                CSV.EliminarConsecutivo(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al eliminar un consecutivo en la Tabla Consecutivo: " + ex);
                throw;
            }
        }
    }
}