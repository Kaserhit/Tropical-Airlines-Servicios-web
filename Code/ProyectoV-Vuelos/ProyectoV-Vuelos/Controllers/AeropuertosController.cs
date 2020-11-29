using ProyectoV_Vuelos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;


namespace ProyectoV_Vuelos.Controllers
{
    public class AeropuertosController : ApiController
    {

        AeropuertoCRUDController CRUD = new AeropuertoCRUDController();
        Aeropuertos Aereopuerto = new Aeropuertos();

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
        public IHttpActionResult Post(AeropuertosModel p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Aereopuerto.GenerarAeropuerto(p.Consec_Aerop, p.Cod_Puerta, p.Num_Puerta, p.Detalle);

            return CreatedAtRoute("DefaultApi", new { id = p.APTID }, p);
        }

        // PUT: api/Aeropuertos/5
        public IHttpActionResult Put(int id, AeropuertosModel p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p.APTID)
            {
                return BadRequest();
            }

            if (!AerepuertoExists(id))
            {
                return NotFound();
            }

            Aereopuerto.ActualizarAeropuerto(p.APTID, p.Consec_Aerop, p.Cod_Puerta, p.Num_Puerta, p.Detalle);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Aeropuertos/5
        public IHttpActionResult Delete(int id)
        {
            AeropuertosModel p = CRUD.BuscarAeropuertos().Where(e => e.APTID == id).First();

            if (p == null)
            {
                return NotFound();
            }

            Aereopuerto.EliminarAeropuerto(id);

            return Ok(p);
        }


        private bool AerepuertoExists(int id)
        {
            return CRUD.BuscarAeropuertos().Count(e => e.APTID == id) > 0;
        }
    }
}
