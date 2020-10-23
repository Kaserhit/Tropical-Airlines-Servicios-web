using Lec04.Data;
using Lec04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lec04.Controllers
{
    public class ConsecutivosController : ApiController
    {
        ConsecutivosData FacturasData = new ConsecutivosData();
        // GET: api/Distritos
        public IEnumerable<ConsecutivosModel> Get()
        {
            return FacturasData.selectData();
        }

        // GET: api/Distritos/5
        public ConsecutivosModel Get(int id)
        {
            return FacturasData.selectData().Where(e => e.CSVID == id).First();
        }

        
    }
}
