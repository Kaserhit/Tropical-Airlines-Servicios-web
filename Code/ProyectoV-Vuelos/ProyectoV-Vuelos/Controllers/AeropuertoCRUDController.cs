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
            return View(BuscarAeropuertos());
        }

        public ActionResult Consulta()
        {
            return View(BuscarAeropuertos());
        }

        public ActionResult Detalles(int id)
        {
            return View(BuscarAeropuertos().Where(e => e.APTID == id).First());
        }

        public List<AeropuertosModel> BuscarAeropuertos()
        {
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
                throw;
            }
        }

        public List<AeropuertosModel> BuscarAeropuerto()
        {
            try
            {
                Aeropuertos Aeropuertos = new Aeropuertos();
                List<AeropuertosModel> lista =
                Aeropuertos.SP_Solicitar_Info_Aeropuerto().Tables[0].AsEnumerable().Select(e => new AeropuertosModel
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

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                APT.GenerarAeropuerto(a.Consec_Aerop, a.Cod_Puerta, a.Num_Puerta, a.Detalle);
                BTC.GenerarBitacora(a.Consec_Aerop, 1, 1, DateTime.Now, "Agregar", "Inserción de un nuevo Aeropuerto");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Generar Aeropuerto", ex);

                return View();
            }

        }

        public ActionResult Actualizar(int id)
        {
            return View(BuscarAeropuertos().Where(e => e.APTID == id).First());
        }

        [HttpPost]
        public ActionResult Actualizar(AeropuertosModel a)
        {
            Aeropuertos APT = new Aeropuertos();
            Bitacoras BTC = new Bitacoras();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                APT.ActualizarAeropuerto(a.APTID, a.Consec_Aerop, a.Cod_Puerta, a.Num_Puerta, a.Detalle);
                BTC.GenerarBitacora(a.Consec_Aerop, 1, 2, DateTime.Now, "Modificar", "Modificación de un Aeropuerto");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Actualizar Aeropuerto", ex);

                return View();
            }

        }

        public ActionResult Eliminar(int id)
        {

            Aeropuertos APT = new Aeropuertos();
            Bitacoras BTC = new Bitacoras();

            BTC.GenerarBitacora(APT.SP_Solicitar_Consec_Aeropuerto(id).Consec_Aerop, 1, 3, DateTime.Now, "Eliminar", "Eliminación de un Aeropuerto");
            APT.EliminarAeropuerto(id);

            return RedirectToAction("Index");
        }
    }
}
