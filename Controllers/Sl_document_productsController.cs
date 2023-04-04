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
    public class Sl_document_productsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Sl_document_products
        public IQueryable<Sl_document_products> GetSl_document_products()
        {
            return db.Sl_document_products;
        }

        // GET: api/Sl_document_products/5
        [ResponseType(typeof(Sl_document_products))]
        public IHttpActionResult GetSl_document_products(int id)
        {
            Sl_document_products sl_document_products = db.Sl_document_products.Find(id);
            if (sl_document_products == null)
            {
                return NotFound();
            }

            return Ok(sl_document_products);
        }

        // PUT: api/Sl_document_products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSl_document_products(int id, Sl_document_products sl_document_products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sl_document_products.idDocProduct)
            {
                return BadRequest();
            }

            db.Entry(sl_document_products).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sl_document_productsExists(id))
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

        // POST: api/Sl_document_products
        [ResponseType(typeof(Sl_document_products))]
        public IHttpActionResult PostSl_document_products(Sl_document_products sl_document_products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sl_document_products.Add(sl_document_products);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sl_document_products.idDocProduct }, sl_document_products);
        }

        // DELETE: api/Sl_document_products/5
        [ResponseType(typeof(Sl_document_products))]
        public IHttpActionResult DeleteSl_document_products(int id)
        {
            Sl_document_products sl_document_products = db.Sl_document_products.Find(id);
            if (sl_document_products == null)
            {
                return NotFound();
            }

            db.Sl_document_products.Remove(sl_document_products);
            db.SaveChanges();

            return Ok(sl_document_products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sl_document_productsExists(int id)
        {
            return db.Sl_document_products.Count(e => e.idDocProduct == id) > 0;
        }
    }
}