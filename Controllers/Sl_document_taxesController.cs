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
    public class Sl_document_taxesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Sl_document_taxes
        public IQueryable<Sl_document_taxes> GetSl_document_taxes()
        {
            return db.Sl_document_taxes;
        }

        // GET: api/Sl_document_taxes/5
        [ResponseType(typeof(Sl_document_taxes))]
        public IHttpActionResult GetSl_document_taxes(int id)
        {
            Sl_document_taxes sl_document_taxes = db.Sl_document_taxes.Find(id);
            if (sl_document_taxes == null)
            {
                return NotFound();
            }

            return Ok(sl_document_taxes);
        }

        // PUT: api/Sl_document_taxes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSl_document_taxes(int id, Sl_document_taxes sl_document_taxes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sl_document_taxes.idTaxeDocumento)
            {
                return BadRequest();
            }

            db.Entry(sl_document_taxes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sl_document_taxesExists(id))
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

        // POST: api/Sl_document_taxes
        [ResponseType(typeof(Sl_document_taxes))]
        public IHttpActionResult PostSl_document_taxes(Sl_document_taxes sl_document_taxes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sl_document_taxes.Add(sl_document_taxes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sl_document_taxes.idTaxeDocumento }, sl_document_taxes);
        }

        // DELETE: api/Sl_document_taxes/5
        [ResponseType(typeof(Sl_document_taxes))]
        public IHttpActionResult DeleteSl_document_taxes(int id)
        {
            Sl_document_taxes sl_document_taxes = db.Sl_document_taxes.Find(id);
            if (sl_document_taxes == null)
            {
                return NotFound();
            }

            db.Sl_document_taxes.Remove(sl_document_taxes);
            db.SaveChanges();

            return Ok(sl_document_taxes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sl_document_taxesExists(int id)
        {
            return db.Sl_document_taxes.Count(e => e.idTaxeDocumento == id) > 0;
        }
    }
}