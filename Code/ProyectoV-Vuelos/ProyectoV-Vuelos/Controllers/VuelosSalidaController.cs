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

    public class VuelosSalidaController : ApiController
    {
        VueloCRUDController CRUD = new VueloCRUDController();

        // GET: api/VuelosSalida
        public IEnumerable<VuelosModel> Get()
        {
            return CRUD.BuscarVuelosSalida();
        }

        // GET: api/VuelosSalida/5
        public IHttpActionResult Get(int id)
        {
            VuelosModel v = CRUD.BuscarVuelosSalida().Where(e => e.VLOID == id).First();

            if (v == null)
            {
                return NotFound();
            }

            return Ok(v);
        }
    }
}
