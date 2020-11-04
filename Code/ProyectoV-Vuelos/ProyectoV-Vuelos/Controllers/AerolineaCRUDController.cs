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
            return View(BuscarAerolineas());
        }

        public ActionResult Consulta()
        {
            return View(BuscarAerolineas());
        }

        public ActionResult Detalles(int id)
        {
            return View(BuscarAerolineas().Where(e => e.ALNID == id).First());
        }

        public ActionResult Busqueda(FormCollection item)
        {
            Pais pais = new Pais();
            Aerolineas Aerolinea = new Aerolineas();
            string Nombre = item["id"];
            var PAISID = pais.SP_Solicitar_Filtro_Pais(Nombre).PAISID;
            var datos = BuscarAerolineas().Where(x => x.Aerol_Pais == PAISID).Select(x => x).ToList();

            return View("~/Views/AerolineaCRUD/Consulta.cshtml", datos);
        }

        public List<AerolineasModel> BuscarAerolineas()
        {
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
                throw;
            }
        }

        public List<AerolineasModel> BuscarAerolinea()
        {
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

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                ALN.GenerarAerolinea(a.Aerol_Pais, a.Consec_Aerol, a.Codigo, a.Nombre, a.Imagen);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Generar Aerolinea", ex);

                return View();
            }

        }

        public ActionResult Actualizar(int id)
        {
            return View(BuscarAerolineas().Where(e => e.ALNID == id).First());
        }

        [HttpPost]
        public ActionResult Actualizar(AerolineasModel a)
        {
            Aerolineas ALN = new Aerolineas();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                ALN.ActualizarAerolinea(a.ALNID, a.Aerol_Pais, a.Consec_Aerol, a.Codigo, a.Nombre, a.Imagen);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Actualizar Aerolinea", ex);

                return View();
            }

        }

        public ActionResult Eliminar(int id)
        {

            Aerolineas ALN = new Aerolineas();

            ALN.EliminarAerolinea(id);

            return RedirectToAction("Index");
        }
    }
}
