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
    public class BitacoraCRUDController : Controller
    {
        public ActionResult Index()
        {
            return View(BuscarBitacoras());
        }

        public ActionResult Detalles(int id)
        {
            return View(BuscarBitacoras().Where(e => e.BTCID == id).First());
        }

        public ActionResult Consulta()
        {
            return View(BuscarBitacoras());
        }

        public List<BitacorasModel> BuscarBitacoras()
        {
            try
            {
                Bitacoras Bitacoras = new Bitacoras();
                List<BitacorasModel> lista =
                Bitacoras.SP_Solicitar_Info_Bitacoras().Tables[0].AsEnumerable().Select(e => new BitacorasModel
                {
                    BTCID = e.Field<int>("BTCID"),
                    Consec_Bitacora = e.Field<int>("Consec_Bitacora"),
                    Usuario_Bitac = e.Field<int>("Usuario_Bitac"),
                    Cod_Registro = e.Field<int>("Cod_Registro"),
                    Fecha = e.Field<DateTime>("Fecha"),
                    Tipo = e.Field<string>("Tipo"),
                    Descripcion = e.Field<string>("Descripcion"),

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
        public ActionResult Generar(BitacorasModel a)
        {
            Bitacoras BTC = new Bitacoras();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                BTC.GenerarBitacora(a.Consec_Bitacora, a.Usuario_Bitac, a.Cod_Registro, a.Fecha, a.Tipo, a.Descripcion);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Generar la Bitacora", ex);

                return View();
            }

        }

        public ActionResult Actualizar(int id)
        {
            return View(BuscarBitacoras().Where(e => e.BTCID == id).First());
        }

        [HttpPost]
        public ActionResult Actualizar(BitacorasModel a)
        {
            Bitacoras BTC = new Bitacoras();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                BTC.ActualizarBitacora(a.BTCID, a.Consec_Bitacora, a.Usuario_Bitac, a.Cod_Registro, a.Fecha, a.Tipo, a.Descripcion);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Actualizar la Bitacora", ex);

                return View();
            }

        }
    }
}
