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
    public class prd_productController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/prd_product
        public IQueryable<prd_product> Getprd_product()
        {
            return db.prd_product;
        }

        // GET: api/prd_product/5
        [ResponseType(typeof(prd_product))]
        public IHttpActionResult Getprd_product(int id)
        {
            prd_product prd_product = db.prd_product.Find(id);
            if (prd_product == null)
            {
                return NotFound();
            }

            return Ok(prd_product);
        }

        // PUT: api/prd_product/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprd_product(int id, prd_product prd_product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prd_product.id)
            {
                return BadRequest();
            }

            db.Entry(prd_product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!prd_productExists(id))
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

        // POST: api/prd_product
        [ResponseType(typeof(prd_product))]
        public IHttpActionResult Postprd_product(prd_product prd_product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.prd_product.Add(prd_product);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (prd_productExists(prd_product.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = prd_product.id }, prd_product);
        }

        // DELETE: api/prd_product/5
        [ResponseType(typeof(prd_product))]
        public IHttpActionResult Deleteprd_product(int id)
        {
            prd_product prd_product = db.prd_product.Find(id);
            if (prd_product == null)
            {
                return NotFound();
            }

            db.prd_product.Remove(prd_product);
            db.SaveChanges();

            return Ok(prd_product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool prd_productExists(int id)
        {
            return db.prd_product.Count(e => e.id == id) > 0;
        }
    }
}