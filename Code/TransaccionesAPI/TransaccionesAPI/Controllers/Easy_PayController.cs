using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TransaccionesAPI.Models;
using System.Web.Http.Cors;

namespace TransaccionesAPI.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]

    public class Easy_PayController : ApiController
    {
        private TransaccionesWebBDEntities db = new TransaccionesWebBDEntities();

        // GET: api/Easy_Pay
        public IQueryable<Easy_Pay> GetEasy_Pay()
        {
            return db.Easy_Pay;
        }

        // GET: api/Easy_Pay/5
        [ResponseType(typeof(Easy_Pay))]
        public IHttpActionResult GetEasy_Pay(int id)
        {
            Easy_Pay easy_Pay = db.Easy_Pay.Find(id);
            if (easy_Pay == null)
            {
                return NotFound();
            }

            return Ok(easy_Pay);
        }

        // PUT: api/Easy_Pay/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEasy_Pay(int id, Easy_Pay easy_Pay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != easy_Pay.EPID)
            {
                return BadRequest();
            }

            db.Entry(easy_Pay).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Easy_PayExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Easy_Pay
        [ResponseType(typeof(Easy_Pay))]
        public IHttpActionResult PostEasy_Pay(Easy_Pay easy_Pay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Easy_Pay.Add(easy_Pay);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = easy_Pay.EPID }, easy_Pay);
        }

        // DELETE: api/Easy_Pay/5
        [ResponseType(typeof(Easy_Pay))]
        public IHttpActionResult DeleteEasy_Pay(int id)
        {
            Easy_Pay easy_Pay = db.Easy_Pay.Find(id);
            if (easy_Pay == null)
            {
                return NotFound();
            }

            db.Easy_Pay.Remove(easy_Pay);
            db.SaveChanges();

            return Ok(easy_Pay);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Easy_PayExists(int id)
        {
            return db.Easy_Pay.Count(e => e.EPID == id) > 0;
        }
    }
}