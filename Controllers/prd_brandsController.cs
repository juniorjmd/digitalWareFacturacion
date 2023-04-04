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
    public class prd_brandsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/prd_brands
        public IQueryable<prd_brands> Getprd_brands()
        {
            return db.prd_brands;
        }

        // GET: api/prd_brands/5
        [ResponseType(typeof(prd_brands))]
        public IHttpActionResult Getprd_brands(int id)
        {
            prd_brands prd_brands = db.prd_brands.Find(id);
            if (prd_brands == null)
            {
                return NotFound();
            }

            return Ok(prd_brands);
        }

        // PUT: api/prd_brands/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprd_brands(int id, prd_brands prd_brands)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prd_brands.iDmarca)
            {
                return BadRequest();
            }

            db.Entry(prd_brands).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!prd_brandsExists(id))
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

        // POST: api/prd_brands
        [ResponseType(typeof(prd_brands))]
        public IHttpActionResult Postprd_brands(prd_brands prd_brands)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.prd_brands.Add(prd_brands);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prd_brands.iDmarca }, prd_brands);
        }

        // DELETE: api/prd_brands/5
        [ResponseType(typeof(prd_brands))]
        public IHttpActionResult Deleteprd_brands(int id)
        {
            prd_brands prd_brands = db.prd_brands.Find(id);
            if (prd_brands == null)
            {
                return NotFound();
            }

            db.prd_brands.Remove(prd_brands);
            db.SaveChanges();

            return Ok(prd_brands);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool prd_brandsExists(int id)
        {
            return db.prd_brands.Count(e => e.iDmarca == id) > 0;
        }
    }
}