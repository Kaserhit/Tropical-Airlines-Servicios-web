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
    public class FacturasController : ApiController
    {
        FacturasData FacturasData = new FacturasData();
        // GET: api/Distritos
        public IEnumerable<FacturasModel> Get()
        {
            return FacturasData.selectData();
        }

        // GET: api/Distritos/5
        public FacturasModel Get(int id)
        {
            return FacturasData.selectData().Where(e => e.Num_Factura == id).First();
        }

        
    }
}
