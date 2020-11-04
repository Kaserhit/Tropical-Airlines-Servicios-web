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
    public class SeguridadCRUDController : Controller
    {

        public ActionResult Index()
        {
            return View(BuscarUsuarios());
        }

        public ActionResult Detalles(int id)
        {
            return View(BuscarUsuarios().Where(e => e.USRID == id).First());
        }

        public List<SeguridadModel> BuscarUsuarios()
        {
            try
            {
                Seguridad usuarios = new Seguridad();
                List<SeguridadModel> lista =
                usuarios.SP_Solicitar_Info_Usuarios().Tables[0].AsEnumerable().Select(e => new SeguridadModel
                {
                    USRID = e.Field<int>("USRID"),
                    ID_Rol = e.Field<int>("ID_Rol"),
                    Usuario = e.Field<string>("Usuario"),
                    Contrasena = e.Field<string>("Contrasena"),
                    Nombre = e.Field<string>("Nombre"),
                    Primer_Apellido = e.Field<string>("Primer_Apellido"),
                    Segundo_Apellido = e.Field<string>("Segundo_Apellido"),
                    Correo = e.Field<string>("Correo"),

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
        public ActionResult Generar(SeguridadModel a)
        {
            Seguridad CSV = new Seguridad();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {

                if (a.Contrasena == a.newcontrasena2)
                {
                    CSV.Generar(a.ID_Rol = 6, a.Usuario, a.Contrasena, a.Nombre, a.Primer_Apellido, a.Segundo_Apellido, a.Pregunta, a.Respuesta, a.Correo);
              
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Generar");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Generar el Usuario", ex);

                return View();
            }

        }

        public ActionResult Actualizar(int id)
        {
            return View(BuscarUsuarios().Where(e => e.USRID == id).First());
        }

        [HttpPost]
        public ActionResult Actualizar(SeguridadModel a)
        {
            Seguridad CSV = new Seguridad();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                CSV.Actualizar(a.USRID, a.ID_Rol);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al actualizar el Usuario", ex);

                return View();
            }

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(SeguridadModel a)
        {
            Seguridad CSV = new Seguridad();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                if (CSV.Login(a.Usuario, a.Contrasena))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", "SeguridadCRUD");

                }
              
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Inicio de Sesion Incorrecto", ex);

                throw;
                
            }

        }


        public ActionResult Actualizarcontrasena()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Actualizarcontrasena(SeguridadModel a)
        {
            Seguridad CSV = new Seguridad();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                if (a.newcontrasena == a.newcontrasena2)
                {
                    CSV.Actualizarcontrasena(a.Contrasena, a.newcontrasena);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Actualizarcontrasena");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al actualizar el Usuario", ex);

                return View();
            }

        }

    }

}
