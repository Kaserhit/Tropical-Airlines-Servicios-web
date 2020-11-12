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
        public static string test;

        public ActionResult Index()
        {
            Errores Error = new Errores();

            try
            {
                if (BuscarUsuarios() != null)
                {
                    return View(BuscarUsuarios());
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al mostrar el Index en la Tabla Seguridad: " + ex);
                throw;
            }
        }

        public List<SeguridadModel> BuscarUsuarios()
        {
            Errores Error = new Errores();

            try
            {
                Seguridad usuarios = new Seguridad();
                List<SeguridadModel> lista =
                usuarios.SP_Solicitar_Info_Usuarios().Tables[0].AsEnumerable().Select(e => new SeguridadModel
                {
                    USRID = e.Field<int>("USRID"),
                    Usuario = e.Field<string>("Usuario"),
                    Contrasena = e.Field<string>("Contrasena"),
                    Nombre = e.Field<string>("Nombre"),
                    Primer_Apellido = e.Field<string>("Primer_Apellido"),
                    Segundo_Apellido = e.Field<string>("Segundo_Apellido"),
                    Correo = e.Field<string>("Correo"),
                    Administrador = e.Field<int>("Administrador"),
                    Seguridad = e.Field<int>("Seguridad"),
                    Consecutivo = e.Field<int>("Consecutivo"),
                    Mantenimiento = e.Field<int>("Mantenimiento"),
                    Consulta = e.Field<int>("Consulta"),
                    Cliente = e.Field<int>("Cliente"),

                }).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Valor Null detectado");
                Error.GenerarError(DateTime.Now, "Error al buscar los usuarios en la Tabla Usuarios: " + ex);
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
            Rol_Usuarios Roles = new Rol_Usuarios();
            Errores Error = new Errores();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {

                if (a.Contrasena == a.newcontrasena2)
                {
                    CSV.Generar(a.Usuario, a.Contrasena, a.Nombre, a.Primer_Apellido, a.Segundo_Apellido, a.Pregunta, a.Respuesta, a.Correo, 0, 0, 0, 0, 0, 0);
                    Roles.Generar_Rol_Usuarios(a.USRID, 1, 0);
                    Roles.Generar_Rol_Usuarios(a.USRID, 2, 0);
                    Roles.Generar_Rol_Usuarios(a.USRID, 3, 0);
                    Roles.Generar_Rol_Usuarios(a.USRID, 4, 0);
                    Roles.Generar_Rol_Usuarios(a.USRID, 5, 0);
                    Roles.Generar_Rol_Usuarios(a.USRID, 6, 0);

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
                Error.GenerarError(DateTime.Now, "Error al generar el rol a un usuario en la Tabla Seguridad: " + ex);
                return View();
            }

        }

        public ActionResult Test(int id)
        {
            Errores Error = new Errores();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                test = id.ToString();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Generar el Usuario", ex);
                Error.GenerarError(DateTime.Now, "Error al generar el rol a un usuario en la Tabla Seguridad: " + ex);
                return View();
            }
        }

        public ActionResult ActualizarRol(FormCollection item)
        {
            Seguridad CSV = new Seguridad();
            Rol_Usuarios Rol = new Rol_Usuarios();
            Errores Error = new Errores();

            string userid = test;
            string administrador = item["Administrador"];
            string seguridad = item["Seguridad"];
            string consecutivo = item["Consecutivo"];
            string mantenimiento = item["Mantenimiento"];
            string consultas = item["Consultas"];
            string cliente = item["Cliente"];

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                if (administrador == "false")
                {
                    CSV.SP_Actualiza_Rol_Administrador(Convert.ToInt32(userid), 0);
                    Rol.SP_Actualiza_Estado_Administrador(Convert.ToInt32(userid), 1, 0);
                }
                else
                {
                    CSV.SP_Actualiza_Rol_Administrador(Convert.ToInt32(userid), 1);
                    Rol.SP_Actualiza_Estado_Administrador(Convert.ToInt32(userid), 1, 1);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al actualizar el Usuario", ex);
                Error.GenerarError(DateTime.Now, "Error al actualizar el rol en la Tabla Seguridad: " + ex);
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
            Errores Error = new Errores();

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
                Error.GenerarError(DateTime.Now, "Error al iniciar sesión en el login en la Tabla Seguridad: " + ex);
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
            Errores Error = new Errores();

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
                Error.GenerarError(DateTime.Now, "Error al actualizar la contraseña en la Tabla Seguridad: " + ex);
                return View();
            }
        }
    }
}