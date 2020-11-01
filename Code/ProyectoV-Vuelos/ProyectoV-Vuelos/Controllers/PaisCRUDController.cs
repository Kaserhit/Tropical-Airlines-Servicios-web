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

        public List<PaisModel> BuscarPaises()
        {
            try
            {
                Pais Paises = new Pais();
                List<PaisModel> lista =
                Paises.SP_Solicitar_Info_Paises().Tables[0].AsEnumerable().Select(e => new PaisModel
                {
                    PAISID = e.Field<int>("PAISID"),
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
            Pais CSV = new Pais();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                CSV.Generar(a.CodPais, a.Nombre, a.Imagen);
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
            Pais CSV = new Pais();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                CSV.Actualizar(a.PAISID, a.CodPais, a.Nombre, a.Imagen);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al actualizar el pais", ex);

                return View();
            }

        }

        public ActionResult Eliminar(int id)
        {

            Pais CSV = new Pais();

            CSV.Eliminar(id);

            return RedirectToAction("Index");
        }

    }

}
