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
    public class ConsecutivosController : ApiController
    {

        ConsecutivoCRUDController CRUD = new ConsecutivoCRUDController();
        Consecutivos Consecutivo = new Consecutivos();

        // GET: api/Consecutivos
        public IEnumerable<ConsecutivosModel> Get()
        {
            return CRUD.BuscarConsecutivos();
        }

        // GET: api/Consecutivos/5
        public ConsecutivosModel Get(int id)
        {
            return CRUD.BuscarConsecutivos().Where(e => e.CSVID == id).First();
        }

        // POST: api/Consecutivos
        public IHttpActionResult Post(ConsecutivosModel p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Consecutivo.GenerarConsecutivo(p.Descripcion,p.Consecutivo,p.Prefijo,p.RangoInicial,p.RangoFinal);

            return CreatedAtRoute("DefaultApi", new { id = p.CSVID }, p);
        }

        // PUT: api/Consecutivos/5
        public IHttpActionResult Put(int id, ConsecutivosModel p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p.CSVID)
            {
                return BadRequest();
            }

            if (!ConsecutivoExists(id))
            {
                return NotFound();
            }

            Consecutivo.ActualizarConsecutivo(p.CSVID, p.Descripcion, p.Consecutivo, p.Prefijo, p.RangoInicial, p.RangoFinal);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Consecutivos/5
        public IHttpActionResult Delete(int id)
        {
            ConsecutivosModel p = CRUD.BuscarConsecutivos().Where(e => e.CSVID == id).First();

            if (p == null)
            {
                return NotFound();
            }

            Consecutivo.EliminarConsecutivo(id);

            return Ok(p);
        }
        private bool ConsecutivoExists(int id)
        {
            return CRUD.BuscarConsecutivos().Count(e => e.CSVID == id) > 0;
        }
    }
}
