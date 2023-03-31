using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using apiFacturacionPrb.Models;

namespace apiFacturacionPrb.Controllers
{
    public class Cl_customerController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Cl_customer
        public IQueryable<Vw_customer> GetCl_customer()
        {
            return db.Vw_customer;
        }

        // GET: api/Cl_customer/5
        [ResponseType(typeof(Vw_customer))]
        public IHttpActionResult GetCl_customer(int id)
        {
            string query = "select * from Vw_customer where id = " + id.ToString();
            Vw_customer cl_customer = db.Vw_customer.SqlQuery(query).FirstOrDefault<Vw_customer>();
               
            if (cl_customer == null)
            {
                return NotFound();
            }

            return Ok(cl_customer);
        }

        // PUT: api/Cl_customer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCl_customer(int id, Cl_customer cl_customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cl_customer.id)
            {
                return BadRequest();
            }

            db.Entry(cl_customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cl_customerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // return StatusCode(HttpStatusCode.NoContent);
            return CreatedAtRoute("DefaultApi", new { id = cl_customer.id }, cl_customer);
        }

        // POST: api/Cl_customer
        [ResponseType(typeof(Cl_customer))]
        public IHttpActionResult PostCl_customer(Cl_customer cl_customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cl_customer.Add(cl_customer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cl_customer.id }, cl_customer);
        }

        // DELETE: api/Cl_customer/5
        [ResponseType(typeof(Cl_customer))]
        public IHttpActionResult DeleteCl_customer(int id)
        {
            Cl_customer cl_customer = db.Cl_customer.Find(id);
            if (cl_customer == null)
            {
                return NotFound();
            }

            db.Cl_customer.Remove(cl_customer);
            db.SaveChanges();

            return Ok(cl_customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Cl_customerExists(int id)
        {
            return db.Cl_customer.Count(e => e.id == id) > 0;
        }
    }
}