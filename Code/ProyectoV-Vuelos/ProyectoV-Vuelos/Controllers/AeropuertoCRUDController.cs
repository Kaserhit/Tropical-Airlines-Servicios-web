using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoV_Vuelos.Models;
using BLL;
using System.Data;

namespace ProyectoV_Vuelos.Controllers
{
    public class AeropuertoCRUDController : Controller
    {
        public ActionResult Index()
        {
            Errores Error = new Errores();

            try
            {
                if (BuscarAeropuertos() != null)
                {
                    return View(BuscarAeropuertos());
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al mostrar el Index en la Tabla Aeropuerto: " + ex);
                throw;
            }
        }

        public ActionResult Consulta()
        {
            Errores Error = new Errores();

            try
            {
                if (BuscarAeropuertos() != null)
                {
                    return View(BuscarAeropuertos());
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al mostrar las Consultas en la Tabla Aeropuerto: " + ex);
                throw;
            }
        }

        public List<AeropuertosModel> BuscarAeropuertos()
        {
            Errores Error = new Errores();

            try
            {
                Aeropuertos Aeropuertos = new Aeropuertos();
                List<AeropuertosModel> lista =
                Aeropuertos.SP_Solicitar_Info_Aeropuertos().Tables[0].AsEnumerable().Select(e => new AeropuertosModel
                {
                    APTID = e.Field<int>("APTID"),
                    Consec_Aerop = e.Field<int>("Consec_Aerop"),
                    Cod_Puerta = e.Field<string>("Cod_Puerta"),
                    Num_Puerta = e.Field<int>("Num_Puerta"),
                    Detalle = e.Field<string>("Detalle"),

                }).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Valor Null detectado");
                Error.GenerarError(DateTime.Now, "Error al buscar los aeropuertos en la Tabla Aeropuerto: " + ex);
                throw;
            }
        }

        public ActionResult Generar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Generar(AeropuertosModel a)
        {
            Aeropuertos APT = new Aeropuertos();
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                APT.GenerarAeropuerto(a.Consec_Aerop, a.Cod_Puerta, a.Num_Puerta, a.Detalle);
                BTC.GenerarBitacora(a.Consec_Aerop, 1, 1, DateTime.Now, "Agregar", "Inserción de un nuevo Aeropuerto",
                a.Cod_Puerta, "", "", a.Num_Puerta, a.Detalle, "", "", "", "", DateTime.Now, "", 0);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Generar Aeropuerto", ex);
                Error.GenerarError(DateTime.Now, "Error al generar un nuevo aeropuerto en la Tabla Aeropuerto: " + ex);
                return View();
            }

        }

        public ActionResult Actualizar(int id)
        {
            Errores Error = new Errores();

            try
            {
                if (BuscarAeropuertos().Where(e => e.APTID == id).First() != null)
                {
                    return View(BuscarAeropuertos().Where(e => e.APTID == id).First());
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al buscar un aeropuerto en la Tabla Aeropuerto: " + ex);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Actualizar(AeropuertosModel a)
        {
            Aeropuertos APT = new Aeropuertos();
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                APT.ActualizarAeropuerto(a.APTID, a.Consec_Aerop, a.Cod_Puerta, a.Num_Puerta, a.Detalle);
                BTC.GenerarBitacora(a.Consec_Aerop, 1, 2, DateTime.Now, "Modificar", "Modificación de un Aeropuerto",
                a.Cod_Puerta, "", "", a.Num_Puerta, a.Detalle, "", "", "", "", DateTime.Now, "", 0);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Actualizar Aeropuerto", ex);
                Error.GenerarError(DateTime.Now, "Error al actualizar un aeropuerto en la Tabla Aeropuerto: " + ex);
                return View();
            }

        }

        public ActionResult Eliminar(int id)
        {

            Aeropuertos APT = new Aeropuertos();
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            try
            {
                BTC.GenerarBitacora(APT.SP_Solicitar_Consec_Aeropuerto(id).Consec_Aerop, 1, 3, DateTime.Now, "Eliminar", "Eliminación de un Aeropuerto",
                "", "", "", 0, "", "", "", "", "", DateTime.Now, "", 0);
                APT.EliminarAeropuerto(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al eliminar un aeropuerto en la Tabla Aeropuerto: " + ex);
                throw;
            }
        }
    }
}
