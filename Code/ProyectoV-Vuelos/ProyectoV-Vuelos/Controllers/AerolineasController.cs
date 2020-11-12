using System;
using ProyectoV_Vuelos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoV_Vuelos.Controllers
{
    public class AerolineasController : ApiController
    {
        AerolineaCRUDController CRUD = new AerolineaCRUDController();

        // GET: api/Aerolineas
        public IEnumerable<AerolineasModel> Get()
        {
            return CRUD.BuscarAerolineas();
        }

        // GET: api/Aerolineas/5
        public AerolineasModel Get(int id)
        {
            return CRUD.BuscarAerolineas().Where(e => e.ALNID == id).First();
        }

        // POST: api/Aerolineas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Aerolineas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Aerolineas/5
        public void Delete(int id)
        {
        }
    }
}