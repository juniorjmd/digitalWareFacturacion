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
    public class Sl_document_StatesController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/Sl_document_States
        public IQueryable<Sl_document_States> GetSl_document_States()
        {
            return db.Sl_document_States;
        }

        // GET: api/Sl_document_States/5
        [ResponseType(typeof(Sl_document_States))]
        public IHttpActionResult GetSl_document_States(int id)
        {
            Sl_document_States sl_document_States = db.Sl_document_States.Find(id);
            if (sl_document_States == null)
            {
                return NotFound();
            }

            return Ok(sl_document_States);
        }

        // PUT: api/Sl_document_States/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSl_document_States(int id, Sl_document_States sl_document_States)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sl_document_States.id)
            {
                return BadRequest();
            }

            db.Entry(sl_document_States).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sl_document_StatesExists(id))
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

        // POST: api/Sl_document_States
        [ResponseType(typeof(Sl_document_States))]
        public IHttpActionResult PostSl_document_States(Sl_document_States sl_document_States)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sl_document_States.Add(sl_document_States);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sl_document_States.id }, sl_document_States);
        }

        // DELETE: api/Sl_document_States/5
        [ResponseType(typeof(Sl_document_States))]
        public IHttpActionResult DeleteSl_document_States(int id)
        {
            Sl_document_States sl_document_States = db.Sl_document_States.Find(id);
            if (sl_document_States == null)
            {
                return NotFound();
            }

            db.Sl_document_States.Remove(sl_document_States);
            db.SaveChanges();

            return Ok(sl_document_States);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sl_document_StatesExists(int id)
        {
            return db.Sl_document_States.Count(e => e.id == id) > 0;
        }
    }
}