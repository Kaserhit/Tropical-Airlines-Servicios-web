using System;
using ProyectoV_Vuelos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoV_Vuelos.Controllers
{
    public class ErroresController : ApiController
    {
        ErrorCRUDController CRUD = new ErrorCRUDController();

        // GET: api/Errores
        public IEnumerable<ErrorModel> Get()
        {
            return CRUD.BuscarErrores();
        }

        // GET: api/Errores/5
        public ErrorModel Get(int id)
        {
            return CRUD.BuscarErrores().Where(e => e.ERRID == id).First();
        }

        // POST: api/Errores
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Errores/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Errores/5
        public void Delete(int id)
        {
        }
    }
}
