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
    public class prd_productController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/prd_product
        public IQueryable<V_prd_product> Getprd_product()
        {
            return db.V_prd_product;
        }

        // GET: api/prd_product/5
        [ResponseType(typeof(V_prd_product))]
        public IHttpActionResult Getprd_product(int id)
        {
            V_prd_product prd_product = db.V_prd_product.Find(id);
            if (prd_product == null)
            {
                return NotFound();
            }

            return Ok(prd_product);
        }

        // PUT: api/prd_product/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprd_product(int id, prd_product prd_product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prd_product.iDproducto)
            {
                return BadRequest();
            }

            db.Entry(prd_product).State = EntityState.Modified;

            if (!prd_codigoExists(id,prd_product.codigo))
            {
                throw new DbUpdateConcurrencyException("el codigo a insertar ya existe en la base de datos") ;
            }
            if (!prd_codigoBarraExists(id,prd_product.codigoBarras))
            {
                throw new DbUpdateConcurrencyException("el codigo a insertar ya existe en la base de datos") ;
            }
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!prd_productExists(id))
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

        // POST: api/prd_product
        [ResponseType(typeof(prd_product))]
        public IHttpActionResult Postprd_product(prd_product prd_product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (prd_codigoNewExists(prd_product.codigo)) {
                throw new Exception("El codigo a insertar ya existe en la base de datos");
            }

             if (prd_codigoBarraNewExists(prd_product.codigoBarras))
            {
                throw new Exception("El codigo a insertar ya existe en la base de datos");
            } 
            db.prd_product.Add(prd_product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prd_product.iDproducto }, prd_product);
        }

        // DELETE: api/prd_product/5
        [ResponseType(typeof(prd_product))]
        public IHttpActionResult Deleteprd_product(int id)
        {
            prd_product prd_product = db.prd_product.Find(id);
            if (prd_product == null)
            {
                return NotFound();
            }

            db.prd_product.Remove(prd_product);
            db.SaveChanges();

            return Ok(prd_product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool prd_productExists(int id)
        {
            return db.prd_product.Count(e => e.iDproducto == id) > 0;
        }
        private bool prd_codigoExists(int idProducto, string codigo)
        {
            IQueryable<prd_product> prd_product = from datos in db.prd_product
                where datos.iDproducto != idProducto
                select datos;
            return prd_product.Count( e => e.codigo == codigo) > 0;
        }
        private bool prd_codigoNewExists(  string codigo)
        {
            IQueryable<prd_product> prd_product = db.prd_product;
            return prd_product.Count(e => e.codigo == codigo) > 0;
        }
        private bool prd_codigoBarraExists(int idProducto, string codigo)
        {
            IQueryable<prd_product> prd_product = from datos in db.prd_product
                                                  where datos.iDproducto != idProducto
                                                  select datos;
            return prd_product.Count(e => e.codigoBarras == codigo) > 0;
        }
        private bool prd_codigoBarraNewExists(string codigo)
        {
            IQueryable<prd_product> prd_product = db.prd_product;
            return prd_product.Count(e => e.codigoBarras == codigo) > 0;
        }
    }
}