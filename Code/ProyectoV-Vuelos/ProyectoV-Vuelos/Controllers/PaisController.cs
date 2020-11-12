using System;
using ProyectoV_Vuelos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoV_Vuelos.Controllers
{
    public class PaisController : ApiController
    {
        PaisCRUDController CRUD = new PaisCRUDController();

        // GET: api/Consecutivos
        public IEnumerable<PaisModel> Get()
        {
            return CRUD.BuscarPaises();
        }

        // GET: api/Consecutivos/5
        public PaisModel Get(int id)
        {
            return CRUD.BuscarPaises().Where(e => e.PAISID == id).First();
        }

        // POST: api/Consecutivos
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Consecutivos/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Consecutivos/5
        public void Delete(int id)
        {
        }
    }
}