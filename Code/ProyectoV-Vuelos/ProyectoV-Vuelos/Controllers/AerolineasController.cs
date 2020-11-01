using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoV_Vuelos.Controllers
{
    public class AerolineasController : ApiController
    {
        // GET: api/Aerolineas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Aerolineas/5
        public string Get(int id)
        {
            return "value";
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
