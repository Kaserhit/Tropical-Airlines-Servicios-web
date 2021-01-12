using BLL;
using ProyectoV_Vuelos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace ProyectoV_Vuelos.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]

    public class ComprasController : ApiController
    {
        Compras Compra = new Compras(); 

        // GET: api/Compras
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Compras/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Compras
        [ResponseType(typeof(ComprasModel))]
        public IHttpActionResult PostCompra(ComprasModel c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Compra.GenerarCompra(c.Compra_Usuario, c.Consec_Compra, c.Destino, c.Cant_Boletos, c.TotalCompra);

            return CreatedAtRoute("DefaultApi", new { id = c.CMPID }, c);
        }

        // PUT: api/Compras/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Compras/5
        public void Delete(int id)
        {
        }
    }
}
