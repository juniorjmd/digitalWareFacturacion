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
    public class V_sl_taxesController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/V_sl_taxes
        public IQueryable<V_sl_taxes> GetV_sl_taxes()
        {
            return db.V_sl_taxes;
        }



        // GET: api/V_sl_taxes
        [HttpGet]
        [Route("api/taxesFactura")] 
        public IQueryable<V_sl_taxes> Get_taxes_factura()
        {
            string consulta = "F";
            IQueryable<V_sl_taxes> v_sl_taxes = from datos in db.V_sl_taxes where
                                    datos.aplicaA == consulta select datos;
            return  v_sl_taxes;
        }
        // GET: api/V_sl_taxes
        [HttpGet]
        [Route("api/taxesProducto")]
        public IQueryable<V_sl_taxes> Get_taxes_producto()
        {
            return db.V_sl_taxes.Where(s => s.aplicaA.Trim().Contains("P")).AsQueryable();
        }
        // GET: api/V_sl_taxes/5
        [ResponseType(typeof(V_sl_taxes))]
        public IHttpActionResult GetV_sl_taxes(int id)
        {
            V_sl_taxes v_sl_taxes = db.V_sl_taxes.Find(id);
            if (v_sl_taxes == null)
            {
                return NotFound();
            }

            return Ok(v_sl_taxes);
        }

        // PUT: api/V_sl_taxes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutV_sl_taxes(int id, V_sl_taxes v_sl_taxes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != v_sl_taxes.iDimpuesto)
            {
                return BadRequest();
            }

            db.Entry(v_sl_taxes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!V_sl_taxesExists(id))
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

        // POST: api/V_sl_taxes
        [ResponseType(typeof(V_sl_taxes))]
        public IHttpActionResult PostV_sl_taxes(V_sl_taxes v_sl_taxes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.V_sl_taxes.Add(v_sl_taxes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = v_sl_taxes.iDimpuesto }, v_sl_taxes);
        }

        // DELETE: api/V_sl_taxes/5
        [ResponseType(typeof(V_sl_taxes))]
        public IHttpActionResult DeleteV_sl_taxes(int id)
        {
            V_sl_taxes v_sl_taxes = db.V_sl_taxes.Find(id);
            if (v_sl_taxes == null)
            {
                return NotFound();
            }

            db.V_sl_taxes.Remove(v_sl_taxes);
            db.SaveChanges();

            return Ok(v_sl_taxes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool V_sl_taxesExists(int id)
        {
            return db.V_sl_taxes.Count(e => e.iDimpuesto == id) > 0;
        }
    }
}