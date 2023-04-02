using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using apiFacturacionPrb.Models;

namespace apiFacturacionPrb.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Sl_discountsController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/Sl_discounts
        public IQueryable<Sl_discounts> GetSl_discounts()
        {
            return db.Sl_discounts;
        }

        // GET: api/Sl_discounts/5
        [ResponseType(typeof(Sl_discounts))]
        public IHttpActionResult GetSl_discounts(int id)
        {
            Sl_discounts sl_discounts = db.Sl_discounts.Find(id);
            if (sl_discounts == null)
            {
                return NotFound();
            }

            return Ok(sl_discounts);
        }

        // PUT: api/Sl_discounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSl_discounts(int id, Sl_discounts sl_discounts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sl_discounts.id)
            {
                return BadRequest();
            }

            db.Entry(sl_discounts).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sl_discountsExists(id))
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

        // POST: api/Sl_discounts
        [ResponseType(typeof(Sl_discounts))]
        public IHttpActionResult PostSl_discounts(Sl_discounts sl_discounts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sl_discounts.Add(sl_discounts);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sl_discounts.id }, sl_discounts);
        }

        // DELETE: api/Sl_discounts/5
        [ResponseType(typeof(Sl_discounts))]
        public IHttpActionResult DeleteSl_discounts(int id)
        {
            Sl_discounts sl_discounts = db.Sl_discounts.Find(id);
            if (sl_discounts == null)
            {
                return NotFound();
            }

            db.Sl_discounts.Remove(sl_discounts);
            db.SaveChanges();

            return Ok(sl_discounts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sl_discountsExists(int id)
        {
            return db.Sl_discounts.Count(e => e.id == id) > 0;
        }
    }
}