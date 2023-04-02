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
    public class Sl_documentController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/Sl_document
        public IQueryable<Sl_document> GetSl_document()
        {
            return db.Sl_document;
        }

        // GET: api/Sl_document/5
        [ResponseType(typeof(Sl_document))]
        public IHttpActionResult GetSl_document(int id)
        {
            Sl_document sl_document = db.Sl_document.Find(id);
            if (sl_document == null)
            {
                return NotFound();
            }

            return Ok(sl_document);
        }

        // PUT: api/Sl_document/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSl_document(int id, Sl_document sl_document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sl_document.id)
            {
                return BadRequest();
            }

            db.Entry(sl_document).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sl_documentExists(id))
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

        // POST: api/Sl_document
        [ResponseType(typeof(Sl_document))]
        public IHttpActionResult PostSl_document(Sl_document sl_document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sl_document.Add(sl_document);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sl_document.id }, sl_document);
        }

        // DELETE: api/Sl_document/5
        [ResponseType(typeof(Sl_document))]
        public IHttpActionResult DeleteSl_document(int id)
        {
            Sl_document sl_document = db.Sl_document.Find(id);
            if (sl_document == null)
            {
                return NotFound();
            }

            db.Sl_document.Remove(sl_document);
            db.SaveChanges();

            return Ok(sl_document);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sl_documentExists(int id)
        {
            return db.Sl_document.Count(e => e.id == id) > 0;
        }
    }
}