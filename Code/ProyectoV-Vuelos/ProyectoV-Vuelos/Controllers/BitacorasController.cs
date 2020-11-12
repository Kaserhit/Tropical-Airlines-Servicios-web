using System;
using ProyectoV_Vuelos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoV_Vuelos.Controllers
{
    public class BitacorasController : ApiController
    {
        BitacoraCRUDController CRUD = new BitacoraCRUDController();

        // GET: api/Bitacoras
        public IEnumerable<BitacorasModel> Get()
        {
            return CRUD.BuscarBitacoras();
        }

        // GET: api/Bitacoras/5
        public BitacorasModel Get(int id)
        {
            return CRUD.BuscarBitacoras().Where(e => e.BTCID == id).First();
        }

        // POST: api/Bitacoras
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Bitacoras/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bitacoras/5
        public void Delete(int id)
        {
        }
    }
}
