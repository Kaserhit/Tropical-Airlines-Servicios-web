using ProyectoV_Vuelos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoV_Vuelos.Controllers
{
    public class AeropuertosController : ApiController
    {

        AeropuertoCRUDController CRUD = new AeropuertoCRUDController();

        // GET: api/Aeropuertos
        public IEnumerable<AeropuertosModel> Get()
        {
            return CRUD.BuscarAeropuertos();
        }

        // GET: api/Aeropuertos/5
        public AeropuertosModel Get(int id)
        {
            return CRUD.BuscarAeropuertos().Where(e => e.APTID == id).First();
        }

        // POST: api/Aeropuertos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Aeropuertos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Aeropuertos/5
        public void Delete(int id)
        {
        }
    }
}
