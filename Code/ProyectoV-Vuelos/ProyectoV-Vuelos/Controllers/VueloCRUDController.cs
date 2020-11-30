using BLL;
using ProyectoV_Vuelos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoV_Vuelos.Controllers
{
    public class VueloCRUDController : Controller
    {
        public ActionResult Index()
        {
            Errores Error = new Errores();

            try
            {
                if (BuscarVuelos() != null)
                {
                    return View(BuscarVuelos());
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al mostrar el Index en la Tabla Vuelo: " + ex);
                throw;
            }
        }

        public List<VuelosModel> BuscarVuelos()
        {
            Errores Error = new Errores();

            try
            {
                Vuelos vuelos = new Vuelos();
                List<VuelosModel> lista =
                vuelos.SP_Solicitar_Info_Vuelos().Tables[0].AsEnumerable().Select(e => new VuelosModel
                {
                    VLOID = e.Field<int>("VLOID"),
                    Consec_Vuelo = e.Field<int>("Consec_Vuelo"),
                    Vuelo_Aerol = e.Field<int>("Vuelo_Aerol"),
                    Vuelo_Aerop = e.Field<int>("Vuelo_Aerop"),
                    CodVuelo = e.Field<string>("CodVuelo"),
                    Destino = e.Field<string>("Destino"),
                    Procedencia = e.Field<string>("Procedencia"),
                    Fecha = e.Field<DateTime>("Fecha"),
                    Estado = e.Field<string>("Estado"),
                    Monto = e.Field<double>("Monto")

                }).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Valor Null detectado");
                Error.GenerarError(DateTime.Now, "Error al buscar los vuelos en la Tabla Vuelo: " + ex);
                throw;
            }
        }

        public ActionResult Generar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Generar(VuelosModel v)
        {
            Vuelos VLO = new Vuelos();
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                string destino = v.Destino;
                string procedencia = v.Procedencia;

                if (destino == null)
                    destino = "";

                if (procedencia == null)
                    procedencia = "";

                VLO.GenerarVuelo(v.Consec_Vuelo, v.Vuelo_Aerol, v.Vuelo_Aerop, v.CodVuelo, destino, procedencia, DateTime.Now, v.Estado, v.Monto);

                BTC.GenerarBitacora(v.Consec_Vuelo, 1, 1, DateTime.Now, "Agregar", "Inserción de un nuevo Vuelo",
                    v.CodVuelo, "", "", 0, "", "", "", destino, procedencia, v.Fecha, v.Estado, v.Monto);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Generar Vuelo", ex);
                Error.GenerarError(DateTime.Now, "Error al generar un nuevo vuelo en la Tabla Vuelo: " + ex);
                return View();
            }

        }

        public ActionResult Actualizar(int id)
        {
            Errores Error = new Errores();

            try
            {
                if (BuscarVuelos().Where(e => e.VLOID == id).First() != null)
                {
                    return View(BuscarVuelos().Where(e => e.VLOID == id).First());
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al buscar un vuelo en la Tabla Vuelo: " + ex);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Actualizar(VuelosModel v)
        {
            Vuelos VLO = new Vuelos();
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                string destino = v.Destino;
                string procedencia = v.Procedencia;

                if (destino == null)
                    destino = "";

                if (procedencia == null)
                    procedencia = "";

                VLO.ActualizarVuelo(v.VLOID, v.Consec_Vuelo, v.Vuelo_Aerol, v.Vuelo_Aerop, v.CodVuelo, destino, procedencia, v.Fecha, v.Estado, v.Monto);

                BTC.GenerarBitacora(v.Consec_Vuelo, 1, 2, DateTime.Now, "Modificar", "Modificación de un Vuelo",
                    v.CodVuelo, "", "", 0, "", "", "", destino, procedencia, v.Fecha, v.Estado, v.Monto);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Actualizar Vuelo", ex);
                Error.GenerarError(DateTime.Now, "Error al actualizar un vuelo en la Tabla Vuelo: " + ex);
                return View();
            }

        }

        public ActionResult Eliminar(int id)
        {

            Vuelos VLO = new Vuelos();
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            try
            {
                BTC.GenerarBitacora(VLO.SP_Solicitar_Consec_Vuelo(id).Consec_Vuelo, 1, 3, DateTime.Now, "Eliminar", "Eliminación de un Vuelo",
                "", "", "", 0, "", "", "", "", "", DateTime.Now, "", 0);
                VLO.EliminarVuelo(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al eliminar un vuelo en la Tabla Vuelo: " + ex);
                throw;
            }
        }
    }
}
