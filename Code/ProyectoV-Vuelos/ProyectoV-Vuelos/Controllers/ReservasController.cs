using System;
using ProyectoV_Vuelos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using BLL;

namespace ProyectoV_Vuelos.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]

    public class ReservasController : ApiController

    {

        Reservas Reserva = new Reservas();


        // POST: api/Reservas
        [ResponseType(typeof(ReservasModel))]
        public IHttpActionResult PostReservas(ReservasModel p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Reserva.GenerarReserva(p.Reserva_Usuario, p.Consec_Reserva, p.Destino, p.Cant_Boletos, p.TotalCompra, p.Num_Reserva, p.BookingID);

            return CreatedAtRoute("DefaultApi", new { id = p.RSVID }, p);
        }

 
    }
}