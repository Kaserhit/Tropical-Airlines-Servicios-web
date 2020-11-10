using BLL;
using ProyectoV_Vuelos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ProyectoV_Vuelos.Controllers
{
    public class BitacoraCRUDController : Controller
    {
        public ActionResult Index()
        {
            return View(BuscarBitacoras());
        }

        public static string Split(string d)
        {
            string[] lista = d.Split(' ');
            string descripcion = lista[lista.Length - 1];

            return descripcion;
        }

        public ActionResult DetalleRegistro(int id, string descripcion)
        {
            string descrip = Split(descripcion);

            switch (descrip)
            {
                case "País":
                    var Datos_Pais = BuscarBitacoras().Where(x => x.BTCID == id).Select(x => x).ToList();
                    return View("~/Views/BitacoraCRUD/Detalle_Pais.cshtml", Datos_Pais);

                case "Consecutivo":
                    var Datos_Consec = BuscarBitacoras().Where(x => x.BTCID == id).Select(x => x).ToList();
                    return View("~/Views/BitacoraCRUD/Detalle_Consecutivo.cshtml", Datos_Consec);

                case "Aerolínea":
                    var Datos_Aerol = BuscarBitacoras().Where(x => x.BTCID == id).Select(x => x).ToList();
                    return View("~/Views/BitacoraCRUD/Detalle_Aerolinea.cshtml", Datos_Aerol);

                case "Aeropuerto":
                    var Datos_Aerop = BuscarBitacoras().Where(x => x.BTCID == id).Select(x => x).ToList();
                    return View("~/Views/BitacoraCRUD/Detalle_Aeropuerto.cshtml", Datos_Aerop);

                default:
                    Console.WriteLine("La descripción es nula o tiene otro valor");
                    break;
            }

            return View();
        }

        public ActionResult Busqueda(FormCollection item)
        {
            string usuario = item["user"];
            string fechainicio = item["fechainicio"];
            string fechafinal = item["fechafinal"];
            string tipo = item["tipo"];

            if (usuario == "" && fechainicio == "" && fechafinal == "" && tipo == "")
            {
                return View("~/Views/BitacoraCRUD/Consulta.cshtml", BuscarBitacoras());
            }
            else
            {
                if (usuario != "" && fechainicio != "" && fechafinal != "" && tipo != "")
                {
                    var datos = BuscarBitacoras().Where(x => x.Usuario_Bitac == Convert.ToInt32(usuario) && x.Fecha >= Convert.ToDateTime(fechainicio) 
                    && x.Fecha <= Convert.ToDateTime(fechafinal) && x.Tipo == tipo).Select(x => x).ToList();
                    return View("~/Views/BitacoraCRUD/Consulta.cshtml", datos);
                }
                else
                {
                    if ((usuario != "" && fechainicio != "" && fechafinal != "") && tipo == "")
                    {
                        var datos = BuscarBitacoras().Where(x => x.Usuario_Bitac == Convert.ToInt32(usuario) && x.Fecha >= Convert.ToDateTime(fechainicio) 
                        && x.Fecha <= Convert.ToDateTime(fechafinal)).Select(x => x).ToList();
                        return View("~/Views/BitacoraCRUD/Consulta.cshtml", datos);
                    }

                    if ((fechainicio != "" && fechafinal != "" && tipo != "") && usuario == "")
                    {
                        var datos = BuscarBitacoras().Where(x => x.Fecha >= Convert.ToDateTime(fechainicio)
                        && x.Fecha <= Convert.ToDateTime(fechafinal) && x.Tipo == tipo).Select(x => x).ToList();
                        return View("~/Views/BitacoraCRUD/Consulta.cshtml", datos);
                    }

                    if ((usuario != "" && tipo != "") && (fechainicio == "" && fechafinal == ""))
                    {
                        var datos = BuscarBitacoras().Where(x => x.Usuario_Bitac == Convert.ToInt32(usuario) && x.Tipo == tipo).Select(x => x).ToList();
                        return View("~/Views/BitacoraCRUD/Consulta.cshtml", datos);
                    }

                    if (usuario != "" && fechainicio != "")
                    {
                        var datos = BuscarBitacoras().Where(x => x.Usuario_Bitac == Convert.ToInt32(usuario) && x.Fecha >= Convert.ToDateTime(fechainicio)).Select(x => x).ToList();
                        return View("~/Views/BitacoraCRUD/Consulta.cshtml", datos);
                    }

                    if (usuario != "" && fechafinal != "")
                    {
                        var datos = BuscarBitacoras().Where(x => x.Usuario_Bitac == Convert.ToInt32(usuario) && x.Fecha <= Convert.ToDateTime(fechafinal)).Select(x => x).ToList();
                        return View("~/Views/BitacoraCRUD/Consulta.cshtml", datos);
                    }

                    if (fechainicio != "" && fechafinal != "")
                    {
                        var datos = BuscarBitacoras().Where(x => x.Fecha >= Convert.ToDateTime(fechainicio) && x.Fecha <= Convert.ToDateTime(fechafinal)).Select(x => x).ToList();
                        return View("~/Views/BitacoraCRUD/Consulta.cshtml", datos);
                    }

                    if (tipo != "" && fechainicio != "")
                    {
                        var datos = BuscarBitacoras().Where(x => x.Tipo == tipo && x.Fecha >= Convert.ToDateTime(fechainicio)).Select(x => x).ToList();
                        return View("~/Views/BitacoraCRUD/Consulta.cshtml", datos);
                    }

                    if (tipo != "" && fechafinal != "")
                    {
                        var datos = BuscarBitacoras().Where(x => x.Tipo == tipo && x.Fecha <= Convert.ToDateTime(fechafinal)).Select(x => x).ToList();
                        return View("~/Views/BitacoraCRUD/Consulta.cshtml", datos);
                    }

                    if (usuario != "")
                    {
                        var datos = BuscarBitacoras().Where(x => x.Usuario_Bitac == Convert.ToInt32(usuario)).Select(x => x).ToList();
                        return View("~/Views/BitacoraCRUD/Consulta.cshtml", datos);
                    }

                    if (fechainicio != "")
                    {
                        var datos = BuscarBitacoras().Where(x => x.Fecha >= Convert.ToDateTime(fechainicio)).Select(x => x).ToList();
                        return View("~/Views/BitacoraCRUD/Consulta.cshtml", datos);
                    }

                    if (fechafinal != "")
                    {
                        var datos = BuscarBitacoras().Where(x => x.Fecha <= Convert.ToDateTime(fechafinal)).Select(x => x).ToList();
                        return View("~/Views/BitacoraCRUD/Consulta.cshtml", datos);
                    }

                    if (tipo != "")
                    {
                        var datos = BuscarBitacoras().Where(x => x.Tipo == tipo).Select(x => x).ToList();
                        return View("~/Views/BitacoraCRUD/Consulta.cshtml", datos);
                    }
                }
            }

            return View("~/Views/BitacoraCRUD/Consulta.cshtml", BuscarBitacoras());
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
                    Codigo = e.Field<string>("Codigo"),
                    Nombre = e.Field<string>("Nombre"),
                    Imagen = e.Field<string>("Imagen"),
                    Cod_Puerta = e.Field<string>("Cod_Puerta"),
                    Num_Puerta = e.Field<int>("Num_Puerta"),
                    Detalle = e.Field<string>("Detalle"),
                    CSVID = e.Field<int>("CSVID"),
                    Consec_Descripcion = e.Field<string>("Consec_Descripcion"),
                    Consecutivo = e.Field<string>("Consecutivo"),

                }).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Valor Null detectado");
                throw;
            }
        }
    }
}
