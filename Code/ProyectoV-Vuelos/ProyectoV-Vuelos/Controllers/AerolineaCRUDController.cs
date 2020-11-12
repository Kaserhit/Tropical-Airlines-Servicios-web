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
    public class AerolineaCRUDController : Controller
    {
        public ActionResult Index()
        {
            Errores Error = new Errores();

            try
            {
                if (BuscarAerolineas() != null)
                {
                    return View(BuscarAerolineas());
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al mostrar el Index en la Tabla Aerolínea: " + ex);
                throw;
            }
        }

        public ActionResult Consulta()
        {
            Errores Error = new Errores();

            try
            {
                if (BuscarAerolineas() != null)
                {
                    return View(BuscarAerolineas());
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al mostrar las Consultas en la Tabla Aerolínea: " + ex);
                throw;
            }
        }

        public ActionResult Busqueda(FormCollection item)
        {
            Errores Error = new Errores();

            try
            {
                Pais pais = new Pais();
                Aerolineas Aerolinea = new Aerolineas();
                string Nombre = item["nombre"];
                var PAISID = pais.SP_Solicitar_Filtro_Pais(Nombre).PAISID;
                var datos = BuscarAerolineas().Where(x => x.Aerol_Pais == PAISID).Select(x => x).ToList();

                return View("~/Views/AerolineaCRUD/Consulta.cshtml", datos);
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al realizar la busqueda en la Tabla Aerolínea: " + ex);
                throw;
            }
        }

        public List<AerolineasModel> BuscarAerolineas()
        {
            Errores Error = new Errores();

            try
            {
                Aerolineas Aerolineas = new Aerolineas();
                List<AerolineasModel> lista =
                Aerolineas.SP_Solicitar_Info_Aerolineas().Tables[0].AsEnumerable().Select(e => new AerolineasModel
                {
                    ALNID = e.Field<int>("ALNID"),
                    Aerol_Pais = e.Field<int>("Aerol_Pais"),
                    Consec_Aerol = e.Field<int>("Consec_Aerol"),
                    Codigo = e.Field<string>("Codigo"),
                    Nombre = e.Field<string>("Nombre"),
                    Imagen = e.Field<string>("Imagen"),

                }).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Valor Null detectado");
                Error.GenerarError(DateTime.Now, "Error al buscar las aerolíneas en la Tabla Aerolínea: " + ex);
                throw;
            }
        }

        public ActionResult Generar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Generar(AerolineasModel a)
        {
            Aerolineas ALN = new Aerolineas();
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                ALN.GenerarAerolinea(a.Aerol_Pais, a.Consec_Aerol, a.Codigo, a.Nombre, a.Imagen);
                BTC.GenerarBitacora(a.Consec_Aerol, 1, 1, DateTime.Now, "Agregar", "Inserción de una nueva Aerolínea",
                    a.Codigo, a.Nombre, a.Imagen, "", 0, "", 0, "", "");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Generar Aerolinea", ex);
                Error.GenerarError(DateTime.Now, "Error al generar una nueva aerolínea en la Tabla Aerolínea: " + ex);
                return View();
            }

        }

        public ActionResult Actualizar(int id)
        {
            Errores Error = new Errores();

            try
            {
                if (BuscarAerolineas().Where(e => e.ALNID == id).First() != null)
                {
                    return View(BuscarAerolineas().Where(e => e.ALNID == id).First());
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al buscar una aerolínea en la Tabla Aerolínea: " + ex);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Actualizar(AerolineasModel a)
        {
            Aerolineas ALN = new Aerolineas();
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                ALN.ActualizarAerolinea(a.ALNID, a.Aerol_Pais, a.Consec_Aerol, a.Codigo, a.Nombre, a.Imagen);
                BTC.GenerarBitacora(a.Consec_Aerol, 1, 2, DateTime.Now, "Modificar", "Modificación de una Aerolínea",
                    a.Codigo, a.Nombre, a.Imagen, "", 0, "", 0, "", "");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Actualizar Aerolinea", ex);
                Error.GenerarError(DateTime.Now, "Error al actualizar una aerolínea en la Tabla Aerolínea: " + ex);
                return View();
            }

        }

        public ActionResult Eliminar(int id)
        {

            Aerolineas ALN = new Aerolineas();
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            try
            {
                BTC.GenerarBitacora(ALN.SP_Solicitar_Consec_Aerolinea(id).Consec_Aerol, 1, 3, DateTime.Now, "Eliminar", "Eliminación de una Aerolínea",
                "", "", "", "", 0, "", 0, "", "");
                ALN.EliminarAerolinea(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al eliminar una aerolínea en la Tabla Aerolínea: " + ex);
                throw;
            }
        }
    }
}
