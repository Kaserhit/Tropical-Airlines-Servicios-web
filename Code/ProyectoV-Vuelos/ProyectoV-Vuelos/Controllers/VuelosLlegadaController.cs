using ProyectoV_Vuelos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProyectoV_Vuelos.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]

    public class VuelosLlegadaController : ApiController
    {
        VueloCRUDController CRUD = new VueloCRUDController();

        // GET: api/VuelosLlegada
        public IEnumerable<VuelosModel> Get()
        {
            return CRUD.BuscarVuelosLlegada();
        }

        // GET: api/VuelosLlegada/5
        public IHttpActionResult Get(int id)
        {
            VuelosModel v = CRUD.BuscarVuelosLlegada().Where(e => e.VLOID == id).First();

            if (v == null)
            {
                return NotFound();
            }

            return Ok(v);
        }
    }
}
