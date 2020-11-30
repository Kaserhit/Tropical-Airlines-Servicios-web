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
    public class PaisCRUDController : Controller
    {

        public ActionResult Index()
        {
            Errores Error = new Errores();

            try
            {
                if (BuscarPaises() != null)
                {
                    return View(BuscarPaises());
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al mostrar el Index en la Tabla País: " + ex);
                throw;
            }
        }

        public List<PaisModel> BuscarPaises()
        {
            Errores Error = new Errores();

            try
            {
                Pais Paises = new Pais();
                List<PaisModel> lista =
                Paises.SP_Solicitar_Info_Paises().Tables[0].AsEnumerable().Select(e => new PaisModel
                {
                    PAISID = e.Field<int>("PAISID"),
                    Consec_Pais = e.Field<int>("Consec_Pais"),
                    CodPais = e.Field<string>("CodPais"),
                    Nombre = e.Field<string>("Nombre"),
                    Imagen = e.Field<string>("Imagen"),


                }).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Valor Null detectado");
                Error.GenerarError(DateTime.Now, "Error al buscar los países en la Tabla País: " + ex);
                throw;
            }
        }

        public ActionResult Generar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Generar(PaisModel a)
        {
            Pais PAIS = new Pais();
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                PAIS.Generar(a.Consec_Pais, a.CodPais, a.Nombre, a.Imagen);
                BTC.GenerarBitacora(a.Consec_Pais, 1, 1, DateTime.Now, "Agregar", "Inserción de un nuevo País", 
                    a.CodPais, a.Nombre, a.Imagen, 0, "", "", "", "", "", DateTime.Now, "", 0);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Generar el Pais", ex);
                Error.GenerarError(DateTime.Now, "Error al generar un nuevo país en la Tabla País: " + ex);
                return View();
            }

        }

        public ActionResult Actualizar(int id)
        {
            Errores Error = new Errores();

            try
            {
                if (BuscarPaises().Where(e => e.PAISID == id).First() != null)
                {
                    return View(BuscarPaises().Where(e => e.PAISID == id).First());
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al buscar un país en la Tabla País: " + ex);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Actualizar(PaisModel a)
        {
            Pais PAIS = new Pais();
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                PAIS.Actualizar(a.PAISID, a.Consec_Pais, a.CodPais, a.Nombre, a.Imagen);
                BTC.GenerarBitacora(a.Consec_Pais, 1, 2, DateTime.Now, "Modificar", "Modificación de un País",
                    a.CodPais, a.Nombre, a.Imagen, 0, "", "", "", "", "", DateTime.Now, "", 0);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al actualizar el Pais", ex);
                Error.GenerarError(DateTime.Now, "Error al actualizar un país en la Tabla País: " + ex);
                return View();
            }

        }

        public ActionResult Eliminar(int id)
        {

            Pais PAIS = new Pais();
            Bitacoras BTC = new Bitacoras();
            Errores Error = new Errores();

            try
            {
                BTC.GenerarBitacora(PAIS.SP_Solicitar_Consec_Pais(id).Consec_Pais, 1, 3, DateTime.Now, "Eliminar", "Eliminación de un País",
                "", "", "", 0, "", "", "", "", "", DateTime.Now, "", 0);
                PAIS.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al eliminar un país en la Tabla País: " + ex);
                throw;
            }
        }
    }
}
