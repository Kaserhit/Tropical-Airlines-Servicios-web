using System;
using ProyectoV_Vuelos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using System.Web.Http.Description;

namespace ProyectoV_Vuelos.Controllers
{
    public class SeguridadController : ApiController
    {
        SeguridadCRUDController CRUD = new SeguridadCRUDController();
        Rol_Usuarios Roles = new Rol_Usuarios();
        Seguridad CSV = new Seguridad();

        // GET: api/Seguridad
        public IEnumerable<SeguridadModel> Get()
        {
            return CRUD.BuscarUsuarios();
        }

        // GET: api/Seguridad/5
        public IHttpActionResult Get(int id)
        {
            SeguridadModel s = CRUD.BuscarUsuarios().Where(e => e.USRID == id).First();

            if (s == null)
            {
                return NotFound();
            }

            return Ok(s);
        }

        // POST: api/Seguridad
        [ResponseType(typeof(SeguridadModel))]
        public IHttpActionResult Post(SeguridadModel s)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CSV.Generar(s.Usuario, s.Contrasena, s.Nombre, s.Primer_Apellido, s.Segundo_Apellido, s.Pregunta, s.Respuesta, s.Correo);
            Roles.Generar_Rol_Usuarios(Convert.ToInt32(CRUD.BuscarUsuariosUSRID()), 1, false);
            Roles.Generar_Rol_Usuarios(Convert.ToInt32(CRUD.BuscarUsuariosUSRID()), 2, false);
            Roles.Generar_Rol_Usuarios(Convert.ToInt32(CRUD.BuscarUsuariosUSRID()), 3, false);
            Roles.Generar_Rol_Usuarios(Convert.ToInt32(CRUD.BuscarUsuariosUSRID()), 4, false);
            Roles.Generar_Rol_Usuarios(Convert.ToInt32(CRUD.BuscarUsuariosUSRID()), 5, false);
            Roles.Generar_Rol_Usuarios(Convert.ToInt32(CRUD.BuscarUsuariosUSRID()), 6, true);

            return CreatedAtRoute("DefaultApi", new { id = s.USRID }, s);
        }

        // PUT: api/Seguridad/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, SeguridadModel s)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != s.USRID)
            {
                return BadRequest();
            }

            if (!UsuarioExists(id))
            {
                return NotFound();
            }

            if (s.newcontrasena == s.newcontrasena2)
            {
                CSV.Actualizarcontrasena(s.Contrasena, s.newcontrasena);
            }
            else
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Seguridad/5
        public void Delete(int id)
        {
        }

        private bool UsuarioExists(int id)
        {
            return CRUD.BuscarUsuarios().Count(e => e.USRID == id) > 0;
        }
    }
}
