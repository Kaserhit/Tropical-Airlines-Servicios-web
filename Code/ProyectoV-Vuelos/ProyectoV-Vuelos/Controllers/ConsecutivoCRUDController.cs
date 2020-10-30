using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ProyectoV_Vuelos.Controllers
{
    public class ConsecutivoCRUDController : Controller
    {


        public ActionResult Index()
        {
            Consecutivos db = new Consecutivos();

            return View();
        }



    }




}
