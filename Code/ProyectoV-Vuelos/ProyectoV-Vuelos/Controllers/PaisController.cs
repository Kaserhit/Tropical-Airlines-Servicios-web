using System;
using ProyectoV_Vuelos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BLL;

namespace ProyectoV_Vuelos.Controllers
{
    public class PaisController : ApiController
    {
        PaisCRUDController CRUD = new PaisCRUDController();
        Pais PAIS = new Pais();

        // GET: api/Pais
        public IEnumerable<PaisModel> GetPais()
        {
            return CRUD.BuscarPaises();
        }

        // GET: api/Pais/5
        public IHttpActionResult GetPais(int id)
        {
            PaisModel p = CRUD.BuscarPaises().Where(e => e.PAISID == id).First();

            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        // POST: api/Pais
        [ResponseType(typeof(PaisModel))]
        public IHttpActionResult PostPais(PaisModel p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PAIS.Generar(p.Consec_Pais, p.CodPais, p.Nombre, p.Imagen);

            return CreatedAtRoute("DefaultApi", new { id = p.PAISID }, p);
        }

        // PUT: api/Pais/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPais(int id, PaisModel p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p.PAISID)
            {
                return BadRequest();
            }

            if (!PaisExists(id))
            {
                return NotFound();
            }

            PAIS.Actualizar(p.PAISID, p.Consec_Pais, p.CodPais, p.Nombre, p.Imagen);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Pais/5
        [ResponseType(typeof(PaisModel))]
        public IHttpActionResult DeletePais(int id)
        {
            PaisModel p = CRUD.BuscarPaises().Where(e => e.PAISID == id).First();

            if (p == null)
            {
                return NotFound();
            }

            PAIS.Eliminar(id);

            return Ok(p);
        }

        private bool PaisExists(int id)
        {
            return CRUD.BuscarPaises().Count(e => e.PAISID == id) > 0;
        }
    }
}