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
    public class V_prd_brandsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/V_prd_brands
        public IQueryable<V_prd_brands> GetV_prd_brands()
        {
            return db.V_prd_brands;
        }

        // GET: api/V_prd_brands/5
        [ResponseType(typeof(V_prd_brands))]
        public IHttpActionResult GetV_prd_brands(int id)
        {
            V_prd_brands v_prd_brands = db.V_prd_brands.Find(id);
            if (v_prd_brands == null)
            {
                return NotFound();
            }

            return Ok(v_prd_brands);
        }

        // PUT: api/V_prd_brands/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutV_prd_brands(int id, V_prd_brands v_prd_brands)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != v_prd_brands.iDmarca)
            {
                return BadRequest();
            }

            db.Entry(v_prd_brands).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!V_prd_brandsExists(id))
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

        // POST: api/V_prd_brands
        [ResponseType(typeof(V_prd_brands))]
        public IHttpActionResult PostV_prd_brands(V_prd_brands v_prd_brands)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.V_prd_brands.Add(v_prd_brands);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (V_prd_brandsExists(v_prd_brands.iDmarca))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = v_prd_brands.iDmarca }, v_prd_brands);
        }

        // DELETE: api/V_prd_brands/5
        [ResponseType(typeof(V_prd_brands))]
        public IHttpActionResult DeleteV_prd_brands(int id)
        {
            V_prd_brands v_prd_brands = db.V_prd_brands.Find(id);
            if (v_prd_brands == null)
            {
                return NotFound();
            }

            db.V_prd_brands.Remove(v_prd_brands);
            db.SaveChanges();

            return Ok(v_prd_brands);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool V_prd_brandsExists(int id)
        {
            return db.V_prd_brands.Count(e => e.iDmarca == id) > 0;
        }
    }
}