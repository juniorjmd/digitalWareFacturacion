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
    public class V_prd_productController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/V_prd_product
        public IQueryable<V_prd_product> GetV_prd_product()
        {
            return db.V_prd_product;
        }

        // GET: api/V_prd_product/5
        [ResponseType(typeof(V_prd_product))]
        public IHttpActionResult GetV_prd_product(int id)
        {
            V_prd_product v_prd_product = db.V_prd_product.Find(id);
            if (v_prd_product == null)
            {
                return NotFound();
            }

            return Ok(v_prd_product);
        }

        // PUT: api/V_prd_product/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutV_prd_product(int id, V_prd_product v_prd_product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != v_prd_product.iDproducto)
            {
                return BadRequest();
            }

            db.Entry(v_prd_product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!V_prd_productExists(id))
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

        // POST: api/V_prd_product
        [ResponseType(typeof(V_prd_product))]
        public IHttpActionResult PostV_prd_product(V_prd_product v_prd_product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.V_prd_product.Add(v_prd_product);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (V_prd_productExists(v_prd_product.iDproducto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = v_prd_product.iDproducto }, v_prd_product);
        }

        // DELETE: api/V_prd_product/5
        [ResponseType(typeof(V_prd_product))]
        public IHttpActionResult DeleteV_prd_product(int id)
        {
            V_prd_product v_prd_product = db.V_prd_product.Find(id);
            if (v_prd_product == null)
            {
                return NotFound();
            }

            db.V_prd_product.Remove(v_prd_product);
            db.SaveChanges();

            return Ok(v_prd_product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool V_prd_productExists(int id)
        {
            return db.V_prd_product.Count(e => e.iDproducto == id) > 0;
        }
    }
}