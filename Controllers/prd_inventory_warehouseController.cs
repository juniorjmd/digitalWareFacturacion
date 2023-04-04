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
    public class prd_inventory_warehouseController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/prd_inventory_warehouse
        public IQueryable<prd_inventory_warehouse> Getprd_inventory_warehouse()
        {
            return db.prd_inventory_warehouse;
        }

        // GET: api/prd_inventory_warehouse/5
        [ResponseType(typeof(prd_inventory_warehouse))]
        public IHttpActionResult Getprd_inventory_warehouse(int id)
        {
            prd_inventory_warehouse prd_inventory_warehouse = db.prd_inventory_warehouse.Find(id);
            if (prd_inventory_warehouse == null)
            {
                return NotFound();
            }

            return Ok(prd_inventory_warehouse);
        }

        // PUT: api/prd_inventory_warehouse/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprd_inventory_warehouse(int id, prd_inventory_warehouse prd_inventory_warehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prd_inventory_warehouse.idBodega)
            {
                return BadRequest();
            }

            db.Entry(prd_inventory_warehouse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!prd_inventory_warehouseExists(id))
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

        // POST: api/prd_inventory_warehouse
        [ResponseType(typeof(prd_inventory_warehouse))]
        public IHttpActionResult Postprd_inventory_warehouse(prd_inventory_warehouse prd_inventory_warehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.prd_inventory_warehouse.Add(prd_inventory_warehouse);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prd_inventory_warehouse.idBodega }, prd_inventory_warehouse);
        }

        // DELETE: api/prd_inventory_warehouse/5
        [ResponseType(typeof(prd_inventory_warehouse))]
        public IHttpActionResult Deleteprd_inventory_warehouse(int id)
        {
            prd_inventory_warehouse prd_inventory_warehouse = db.prd_inventory_warehouse.Find(id);
            if (prd_inventory_warehouse == null)
            {
                return NotFound();
            }

            db.prd_inventory_warehouse.Remove(prd_inventory_warehouse);
            db.SaveChanges();

            return Ok(prd_inventory_warehouse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool prd_inventory_warehouseExists(int id)
        {
            return db.prd_inventory_warehouse.Count(e => e.idBodega == id) > 0;
        }
    }
}