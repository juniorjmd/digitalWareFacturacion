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
    public class prd_inventory_stockController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/prd_inventory_stock
        public IQueryable<prd_inventory_stock> Getprd_inventory_stock()
        {
            return db.prd_inventory_stock;
        }

        // GET: api/prd_inventory_stock/5
        [ResponseType(typeof(prd_inventory_stock))]
        public IHttpActionResult Getprd_inventory_stock(int id)
        {
            prd_inventory_stock prd_inventory_stock = db.prd_inventory_stock.Find(id);
            if (prd_inventory_stock == null)
            {
                return NotFound();
            }

            return Ok(prd_inventory_stock);
        }

        // PUT: api/prd_inventory_stock/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprd_inventory_stock(int id, prd_inventory_stock prd_inventory_stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prd_inventory_stock.id)
            {
                return BadRequest();
            }

            db.Entry(prd_inventory_stock).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!prd_inventory_stockExists(id))
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

        // POST: api/prd_inventory_stock
        [ResponseType(typeof(prd_inventory_stock))]
        public IHttpActionResult Postprd_inventory_stock(prd_inventory_stock prd_inventory_stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.prd_inventory_stock.Add(prd_inventory_stock);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prd_inventory_stock.id }, prd_inventory_stock);
        }

        // DELETE: api/prd_inventory_stock/5
        [ResponseType(typeof(prd_inventory_stock))]
        public IHttpActionResult Deleteprd_inventory_stock(int id)
        {
            prd_inventory_stock prd_inventory_stock = db.prd_inventory_stock.Find(id);
            if (prd_inventory_stock == null)
            {
                return NotFound();
            }

            db.prd_inventory_stock.Remove(prd_inventory_stock);
            db.SaveChanges();

            return Ok(prd_inventory_stock);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool prd_inventory_stockExists(int id)
        {
            return db.prd_inventory_stock.Count(e => e.id == id) > 0;
        }
    }
}