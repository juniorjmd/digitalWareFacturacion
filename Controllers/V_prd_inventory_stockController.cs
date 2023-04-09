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
    public class V_prd_inventory_stockController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/V_prd_inventory_stock
        public IQueryable<V_prd_inventory_stock> GetV_prd_inventory_stock()
        {
            return db.V_prd_inventory_stock;
        }

        // GET: api/V_prd_inventory_stock/5
        [ResponseType(typeof(V_prd_inventory_stock))]
        public IHttpActionResult GetV_prd_inventory_stock(int id)
        {
            V_prd_inventory_stock v_prd_inventory_stock = db.V_prd_inventory_stock.Find(id);
            if (v_prd_inventory_stock == null)
            {
                return NotFound();
            }

            return Ok(v_prd_inventory_stock);
        }

        // GET: api/ExistenciasPorProducto
        [HttpGet]
        [Route("api/ExistenciasPorProducto/{idProducto}")]
        public IQueryable<V_prd_inventory_stock> GetExistenciasPorProducto(int idProducto)
        { 
            IQueryable<V_prd_inventory_stock> V_prd_inventory_stock = 
                from datos in db.V_prd_inventory_stock 
                where datos.iDproducto == idProducto
                select datos;
            return V_prd_inventory_stock;
        }


        // GET: api/ExistenciasPorProducto
        [HttpGet]
        [Route("api/ExistenciasPorBodega/{idBodega}")]
        public IQueryable<V_prd_inventory_stock> GetExistenciasPorBodega(int idBodega)
        {
            IQueryable<V_prd_inventory_stock> V_prd_inventory_stock = 
                from datos in db.V_prd_inventory_stock
                where datos.idBodega == idBodega
                select datos;
            return V_prd_inventory_stock;
        }

        // PUT: api/V_prd_inventory_stock/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutV_prd_inventory_stock(int id, V_prd_inventory_stock v_prd_inventory_stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != v_prd_inventory_stock.id)
            {
                return BadRequest();
            }

            db.Entry(v_prd_inventory_stock).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!V_prd_inventory_stockExists(id))
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

        // POST: api/V_prd_inventory_stock
        [ResponseType(typeof(V_prd_inventory_stock))]
        public IHttpActionResult PostV_prd_inventory_stock(V_prd_inventory_stock v_prd_inventory_stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.V_prd_inventory_stock.Add(v_prd_inventory_stock);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (V_prd_inventory_stockExists(v_prd_inventory_stock.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = v_prd_inventory_stock.id }, v_prd_inventory_stock);
        }

        // DELETE: api/V_prd_inventory_stock/5
        [ResponseType(typeof(V_prd_inventory_stock))]
        public IHttpActionResult DeleteV_prd_inventory_stock(int id)
        {
            V_prd_inventory_stock v_prd_inventory_stock = db.V_prd_inventory_stock.Find(id);
            if (v_prd_inventory_stock == null)
            {
                return NotFound();
            }

            db.V_prd_inventory_stock.Remove(v_prd_inventory_stock);
            db.SaveChanges();

            return Ok(v_prd_inventory_stock);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool V_prd_inventory_stockExists(int id)
        {
            return db.V_prd_inventory_stock.Count(e => e.id == id) > 0;
        }
    }
}