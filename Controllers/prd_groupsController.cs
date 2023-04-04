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
    public class prd_groupsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/prd_groups
        public IQueryable<prd_groups> Getprd_groups()
        {
            return db.prd_groups;
        }

        // GET: api/prd_groups/5
        [ResponseType(typeof(prd_groups))]
        public IHttpActionResult Getprd_groups(int id)
        {
            prd_groups prd_groups = db.prd_groups.Find(id);
            if (prd_groups == null)
            {
                return NotFound();
            }

            return Ok(prd_groups);
        }

        // PUT: api/prd_groups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprd_groups(int id, prd_groups prd_groups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prd_groups.iDcategoria)
            {
                return BadRequest();
            }

            db.Entry(prd_groups).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!prd_groupsExists(id))
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

        // POST: api/prd_groups
        [ResponseType(typeof(prd_groups))]
        public IHttpActionResult Postprd_groups(prd_groups prd_groups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.prd_groups.Add(prd_groups);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prd_groups.iDcategoria }, prd_groups);
        }

        // DELETE: api/prd_groups/5
        [ResponseType(typeof(prd_groups))]
        public IHttpActionResult Deleteprd_groups(int id)
        {
            prd_groups prd_groups = db.prd_groups.Find(id);
            if (prd_groups == null)
            {
                return NotFound();
            }

            db.prd_groups.Remove(prd_groups);
            db.SaveChanges();

            return Ok(prd_groups);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool prd_groupsExists(int id)
        {
            return db.prd_groups.Count(e => e.iDcategoria == id) > 0;
        }
    }
}