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
    public class V_Sl_discountsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/V_Sl_discounts
        public IQueryable<V_Sl_discounts> GetV_Sl_discounts()
        {
            return db.V_Sl_discounts;
        }

        // GET: api/V_Sl_discounts
        [HttpGet]
        [Route("api/descuentosFactura")]
        public IQueryable<V_Sl_discounts> Get_descuentos_factura()
        {
            string consulta = "F";
            IQueryable<V_Sl_discounts> V_Sl_discounts = from datos in db.V_Sl_discounts
                                                where
                                    datos.aplicaA == consulta
                                                select datos;
            return V_Sl_discounts;
        }
        // GET: api/V_Sl_discounts
        [HttpGet]
        [Route("api/descuentosProducto")]
        public IQueryable<V_Sl_discounts> Get_descuentos_producto()
        {
            return db.V_Sl_discounts.Where(s => s.aplicaA.Trim().Contains("P")).AsQueryable();
        }
        // GET: api/V_Sl_discounts/5
        [ResponseType(typeof(V_Sl_discounts))]
        public IHttpActionResult GetV_Sl_discounts(int id)
        {
            V_Sl_discounts v_Sl_discounts = db.V_Sl_discounts.Find(id);
            if (v_Sl_discounts == null)
            {
                return NotFound();
            }

            return Ok(v_Sl_discounts);
        }

        // PUT: api/V_Sl_discounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutV_Sl_discounts(int id, V_Sl_discounts v_Sl_discounts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != v_Sl_discounts.iDdescuento)
            {
                return BadRequest();
            }

            db.Entry(v_Sl_discounts).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!V_Sl_discountsExists(id))
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

        // POST: api/V_Sl_discounts
        [ResponseType(typeof(V_Sl_discounts))]
        public IHttpActionResult PostV_Sl_discounts(V_Sl_discounts v_Sl_discounts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.V_Sl_discounts.Add(v_Sl_discounts);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = v_Sl_discounts.iDdescuento }, v_Sl_discounts);
        }

        // DELETE: api/V_Sl_discounts/5
        [ResponseType(typeof(V_Sl_discounts))]
        public IHttpActionResult DeleteV_Sl_discounts(int id)
        {
            V_Sl_discounts v_Sl_discounts = db.V_Sl_discounts.Find(id);
            if (v_Sl_discounts == null)
            {
                return NotFound();
            }

            db.V_Sl_discounts.Remove(v_Sl_discounts);
            db.SaveChanges();

            return Ok(v_Sl_discounts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool V_Sl_discountsExists(int id)
        {
            return db.V_Sl_discounts.Count(e => e.iDdescuento == id) > 0;
        }
    }
}