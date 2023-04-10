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
    public class VSl_document_productsController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/VSl_document_products
        public IQueryable<VSl_document_products> GetVSl_document_products()
        {
            return db.VSl_document_products;
        }

        // GET: api/VSl_document_products/5
        [ResponseType(typeof(VSl_document_products))]
        public IHttpActionResult GetVSl_document_products(int id)
        {
            VSl_document_products vSl_document_products = db.VSl_document_products.Find(id);
            if (vSl_document_products == null)
            {
                return NotFound();
            }

            return Ok(vSl_document_products);
        }

        [HttpGet]
        [Route("api/listadoPrdDocumento/{id}")]
        public IQueryable<VSl_document_products> listadoPrdDocumento( int id )
         {
            //    return db2.VSl_document.Where(s => s.idEstado.Equals(0)).AsQueryable();
            return db.VSl_document_products.Where(s => s.idDocumento.Equals(id) );
        }

    // PUT: api/VSl_document_products/5
    [ResponseType(typeof(void))]
        public IHttpActionResult PutVSl_document_products(int id, VSl_document_products vSl_document_products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vSl_document_products.idDocProduct)
            {
                return BadRequest();
            }

            db.Entry(vSl_document_products).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VSl_document_productsExists(id))
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

        // POST: api/VSl_document_products
        [ResponseType(typeof(VSl_document_products))]
        public IHttpActionResult PostVSl_document_products(VSl_document_products vSl_document_products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VSl_document_products.Add(vSl_document_products);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VSl_document_productsExists(vSl_document_products.idDocProduct))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vSl_document_products.idDocProduct }, vSl_document_products);
        }

        // DELETE: api/VSl_document_products/5
        [ResponseType(typeof(VSl_document_products))]
        public IHttpActionResult DeleteVSl_document_products(int id)
        {
            VSl_document_products vSl_document_products = db.VSl_document_products.Find(id);
            if (vSl_document_products == null)
            {
                return NotFound();
            }

            db.VSl_document_products.Remove(vSl_document_products);
            db.SaveChanges();

            return Ok(vSl_document_products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VSl_document_productsExists(int id)
        {
            return db.VSl_document_products.Count(e => e.idDocProduct == id) > 0;
        }
    }
}