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
    public class Sl_taxesController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/Sl_taxes
        public IQueryable<Sl_taxes> GetSl_taxes()
        {
            return db.Sl_taxes;
        }

        // GET: api/Sl_taxes/5
        [ResponseType(typeof(Sl_taxes))]
        public IHttpActionResult GetSl_taxes(int id)
        {
            Sl_taxes sl_taxes = db.Sl_taxes.Find(id);
            if (sl_taxes == null)
            {
                return NotFound();
            }

            return Ok(sl_taxes);
        }

        // PUT: api/Sl_taxes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSl_taxes(int id, Sl_taxes sl_taxes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sl_taxes.id)
            {
                return BadRequest();
            }

            db.Entry(sl_taxes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sl_taxesExists(id))
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

        // POST: api/Sl_taxes
        [ResponseType(typeof(Sl_taxes))]
        public IHttpActionResult PostSl_taxes(Sl_taxes sl_taxes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sl_taxes.Add(sl_taxes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sl_taxes.id }, sl_taxes);
        }

        // DELETE: api/Sl_taxes/5
        [ResponseType(typeof(Sl_taxes))]
        public IHttpActionResult DeleteSl_taxes(int id)
        {
            Sl_taxes sl_taxes = db.Sl_taxes.Find(id);
            if (sl_taxes == null)
            {
                return NotFound();
            }

            db.Sl_taxes.Remove(sl_taxes);
            db.SaveChanges();

            return Ok(sl_taxes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sl_taxesExists(int id)
        {
            return db.Sl_taxes.Count(e => e.id == id) > 0;
        }
    }
}