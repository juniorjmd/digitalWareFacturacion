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
    public class V_prd_inventory_warehouseController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/V_prd_inventory_warehouse
        public IQueryable<V_prd_inventory_warehouse> GetV_prd_inventory_warehouse()
        {
            return db.V_prd_inventory_warehouse;
        }

        // GET: api/V_prd_inventory_warehouse/5
        [ResponseType(typeof(V_prd_inventory_warehouse))]
        public IHttpActionResult GetV_prd_inventory_warehouse(int id)
        {
            V_prd_inventory_warehouse v_prd_inventory_warehouse = db.V_prd_inventory_warehouse.Find(id);
            if (v_prd_inventory_warehouse == null)
            {
                return NotFound();
            }

            return Ok(v_prd_inventory_warehouse);
        }

        // PUT: api/V_prd_inventory_warehouse/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutV_prd_inventory_warehouse(int id, V_prd_inventory_warehouse v_prd_inventory_warehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != v_prd_inventory_warehouse.idBodega)
            {
                return BadRequest();
            }

            db.Entry(v_prd_inventory_warehouse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!V_prd_inventory_warehouseExists(id))
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

        // POST: api/V_prd_inventory_warehouse
        [ResponseType(typeof(V_prd_inventory_warehouse))]
        public IHttpActionResult PostV_prd_inventory_warehouse(V_prd_inventory_warehouse v_prd_inventory_warehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.V_prd_inventory_warehouse.Add(v_prd_inventory_warehouse);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (V_prd_inventory_warehouseExists(v_prd_inventory_warehouse.idBodega))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = v_prd_inventory_warehouse.idBodega }, v_prd_inventory_warehouse);
        }

        // DELETE: api/V_prd_inventory_warehouse/5
        [ResponseType(typeof(V_prd_inventory_warehouse))]
        public IHttpActionResult DeleteV_prd_inventory_warehouse(int id)
        {
            V_prd_inventory_warehouse v_prd_inventory_warehouse = db.V_prd_inventory_warehouse.Find(id);
            if (v_prd_inventory_warehouse == null)
            {
                return NotFound();
            }

            db.V_prd_inventory_warehouse.Remove(v_prd_inventory_warehouse);
            db.SaveChanges();

            return Ok(v_prd_inventory_warehouse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool V_prd_inventory_warehouseExists(int id)
        {
            return db.V_prd_inventory_warehouse.Count(e => e.idBodega == id) > 0;
        }
    }
}