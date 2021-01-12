using System;
using ProyectoV_Vuelos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace ProyectoV_Vuelos.Controllers
{
    public class AerolineasController : ApiController
    {
        AerolineaCRUDController CRUD = new AerolineaCRUDController();
        Aerolineas Aereolinea = new Aerolineas();

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
        public IHttpActionResult Post(AerolineasModel p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Aereolinea.GenerarAerolinea(p.Aerol_Pais, p.Consec_Aerol, p.Codigo, p.Nombre, p.Imagen);

            return CreatedAtRoute("DefaultApi", new { id = p.ALNID }, p);
        }

        // PUT: api/Aerolineas/5
        public IHttpActionResult Put(int id, AerolineasModel p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p.ALNID)
            {
                return BadRequest();
            }

            if (!AereolineaExists(id))
            {
                return NotFound();
            }

            Aereolinea.ActualizarAerolinea(p.ALNID, p.Aerol_Pais, p.Consec_Aerol, p.Codigo, p.Nombre, p.Imagen);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Aerolineas/5
        public IHttpActionResult Delete(int id)
        {
            AerolineasModel p = CRUD.BuscarAerolineas().Where(e => e.ALNID == id).First();

            if (p == null)
            {
                return NotFound();
            }

            Aereolinea.EliminarAerolinea(id);

            return Ok(p);
        }

        private bool AereolineaExists(int id)
        {
            return CRUD.BuscarAerolineas().Count(e => e.ALNID == id) > 0;
        }
    }
}