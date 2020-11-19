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
        public static int ID = 0;
        //Ah Caray!

        public ActionResult Index()
        {
            SeguridadModel seguridad = new SeguridadModel();
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
                    Administrador = e.Field<bool>("Administrador"),
                    Seguridad = e.Field<bool>("Seguridad"),
                    Consecutivo = e.Field<bool>("Consecutivo"),
                    Mantenimiento = e.Field<bool>("Mantenimiento"),
                    Consulta = e.Field<bool>("Consulta"),
                    Cliente = e.Field<bool>("Cliente")

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
                    CSV.Generar(a.Usuario, a.Contrasena, a.Nombre, a.Primer_Apellido, a.Segundo_Apellido, a.Pregunta, a.Respuesta, a.Correo);

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

        public ActionResult ActualizarRol(int id)
        {
            Errores Error = new Errores();
            SeguridadModel Seguridad = new SeguridadModel();

            try
            {
                if (BuscarUsuarios().Where(e => e.USRID == id).First() != null)
                {
                    ID = id;
                    return View(BuscarUsuarios().Where(e => e.USRID == id).First());
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Error.GenerarError(DateTime.Now, "Error al mostrar la vista para actualizar el rol en la Tabla Seguridad: " + ex);
                throw;
            }
        }

        [HttpPost]
        public ActionResult ActualizarRol(string Administrador, string Seguridad, string Consecutivo, string Mantenimiento, string Consulta, string Cliente)
        {
            Seguridad CSV = new Seguridad();
            Rol_Usuarios Rol = new Rol_Usuarios();
            Errores Error = new Errores();

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                bool admin = (Administrador == "true") ? true : false;
                CSV.SP_Actualiza_Rol_Administrador(ID, admin);
                Rol.SP_Actualiza_Estado_Administrador(ID, 1, admin);

                bool seg = (Seguridad == "true") ? true : false;
                CSV.SP_Actualiza_Rol_Seguridad(ID, seg);
                Rol.SP_Actualiza_Estado_Seguridad(ID, 2, seg);

                bool consec = (Consecutivo == "true") ? true : false;
                CSV.SP_Actualiza_Rol_Consecutivo(ID, consec);
                Rol.SP_Actualiza_Estado_Consecutivo(ID, 3, consec);

                bool mant = (Mantenimiento == "true") ? true : false;
                CSV.SP_Actualiza_Rol_Mantenimiento(ID, mant);
                Rol.SP_Actualiza_Estado_Mantenimiento(ID, 4, mant);

                bool consult = (Consulta == "true") ? true : false;
                CSV.SP_Actualiza_Rol_Consulta(ID, consult);
                Rol.SP_Actualiza_Estado_Consultas(ID, 5, consult);

                bool client = (Cliente == "true") ? true : false;
                CSV.SP_Actualiza_Rol_Cliente(ID, client);
                Rol.SP_Actualiza_Estado_Clientes(ID, 6, client);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al actualizar el Rol", ex);
                Error.GenerarError(DateTime.Now, "Error al actualizar un rol en la Tabla Seguridad: " + ex);
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