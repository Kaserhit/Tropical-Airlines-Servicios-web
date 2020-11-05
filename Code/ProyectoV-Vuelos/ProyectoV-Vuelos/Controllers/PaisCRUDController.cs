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
            return View(BuscarPaises());
        }

        public ActionResult Detalles(int id)
        {
            return View(BuscarPaises().Where(e => e.PAISID == id).First());
        }

        public ActionResult DetalleRegistro(int id)
        {
            return View(BuscarPaises().Where(e => e.PAISID == id).First());
        }

        public List<PaisModel> BuscarPaises()
        {
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

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                PAIS.Generar(a.Consec_Pais, a.CodPais, a.Nombre, a.Imagen);
                BTC.GenerarBitacora(a.Consec_Pais, 1, 1, DateTime.Now, "Agregar", "Inserción de un nuevo País");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Generar el Pais", ex);

                return View();
            }

        }

        public ActionResult Actualizar(int id)
        {
            return View(BuscarPaises().Where(e => e.PAISID == id).First());
        }

        [HttpPost]
        public ActionResult Actualizar(PaisModel a)
        {
            Pais PAIS = new Pais();
            Bitacoras BTC = new Bitacoras();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                PAIS.Actualizar(a.PAISID, a.Consec_Pais, a.CodPais, a.Nombre, a.Imagen);
                BTC.GenerarBitacora(a.Consec_Pais, 1, 2, DateTime.Now, "Modificar", "Modificación de un País");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al actualizar el Pais", ex);

                return View();
            }

        }

        public ActionResult Eliminar(int id)
        {

            Pais PAIS = new Pais();
            Bitacoras BTC = new Bitacoras();

            BTC.GenerarBitacora(PAIS.SP_Solicitar_Consec_Pais(id).Consec_Pais, 1, 3, DateTime.Now, "Eliminar", "Eliminación de un País");
            PAIS.Eliminar(id);

            return RedirectToAction("Index");
        }

    }

}
