using System;
using ProyectoV_Vuelos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoV_Vuelos.Controllers
{
    public class SeguridadController : ApiController
    {
        SeguridadCRUDController CRUD = new SeguridadCRUDController();

        // GET: api/Seguridad
        public IEnumerable<SeguridadModel> Get()
        {
            return CRUD.BuscarUsuarios();
        }

        // GET: api/Seguridad/5
        public SeguridadModel Get(int id)
        {
            return CRUD.BuscarUsuarios().Where(e => e.USRID == id).First();
        }

        // POST: api/Seguridad
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Seguridad/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Seguridad/5
        public void Delete(int id)
        {
        }
    }
}
