using System;
using ProyectoV_Vuelos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoV_Vuelos.Controllers
{
    public class ConsecutivosController : ApiController
    {

        ConsecutivoCRUDController CRUD = new ConsecutivoCRUDController();

        //GET: api/Consecutivos
        public IEnumerable<ConsecutivosModel> Get()
        {
            return CRUD.selectData();
        }

        //GET: api/Consecutivos/5
        public ConsecutivosModel Get(int id)
        {
            return CRUD.selectData().Where(e => e.CSVID == id).First();
        }

        // POST: api/Consecutivos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Consecutivos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Consecutivos/5
        public void Delete(int id)
        {
        }
    }
}
