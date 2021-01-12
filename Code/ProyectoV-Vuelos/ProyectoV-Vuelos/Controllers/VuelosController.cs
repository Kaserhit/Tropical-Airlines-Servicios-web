using BLL;
using ProyectoV_Vuelos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;

namespace ProyectoV_Vuelos.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]

    public class VuelosController : ApiController
    {
        VueloCRUDController CRUD = new VueloCRUDController();
        Vuelos VLO = new Vuelos();

        // GET: api/Vuelos
        public IEnumerable<VuelosModel> GetVuelos()
        {
            return CRUD.BuscarVuelos();
        }

        // GET: api/Vuelos/5
        public IHttpActionResult GetVuelo(int id)
        {
            VuelosModel v = CRUD.BuscarVuelos().Where(e => e.VLOID == id).First();

            if (v == null)
            {
                return NotFound();
            }

            return Ok(v);
        }

        // POST: api/Vuelos
        [ResponseType(typeof(VuelosModel))]
        public IHttpActionResult PostVuelo(VuelosModel v)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            VLO.GenerarVuelo(v.Consec_Vuelo, v.Vuelo_Aerol, v.Vuelo_Aerop, v.CodVuelo, v.Destino, v.Procedencia, v.Fecha, v.Estado, v.Monto);

            return CreatedAtRoute("DefaultApi", new { id = v.VLOID }, v);
        }

        // PUT: api/Vuelos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVuelo(int id, VuelosModel v)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != v.VLOID)
            {
                return BadRequest();
            }

            if (!VueloExists(id))
            {
                return NotFound();
            }

            VLO.ActualizarVuelo(v.VLOID, v.Consec_Vuelo, v.Vuelo_Aerol, v.Vuelo_Aerop, v.CodVuelo, v.Destino, v.Procedencia, v.Fecha, v.Estado, v.Monto);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Vuelos/5
        [ResponseType(typeof(VuelosModel))]
        public IHttpActionResult DeleteVuelo(int id)
        {
            VuelosModel v = CRUD.BuscarVuelos().Where(e => e.VLOID == id).First();

            if (v == null)
            {
                return NotFound();
            }

            VLO.EliminarVuelo(id);

            return Ok(v);
        }

        private bool VueloExists(int id)
        {
            return CRUD.BuscarVuelos().Count(e => e.VLOID == id) > 0;
        }
    }
}
