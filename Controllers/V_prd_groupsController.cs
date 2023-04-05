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
    public class V_prd_groupsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/V_prd_groups
        public IQueryable<V_prd_groups> GetV_prd_groups()
        {
            return db.V_prd_groups;
        }

        // GET: api/V_prd_groups/5
        [ResponseType(typeof(V_prd_groups))]
        public IHttpActionResult GetV_prd_groups(int id)
        {
            V_prd_groups v_prd_groups = db.V_prd_groups.Find(id);
            if (v_prd_groups == null)
            {
                return NotFound();
            }

            return Ok(v_prd_groups);
        }

        // PUT: api/V_prd_groups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutV_prd_groups(int id, V_prd_groups v_prd_groups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != v_prd_groups.iDcategoria)
            {
                return BadRequest();
            }

            db.Entry(v_prd_groups).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!V_prd_groupsExists(id))
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

        // POST: api/V_prd_groups
        [ResponseType(typeof(V_prd_groups))]
        public IHttpActionResult PostV_prd_groups(V_prd_groups v_prd_groups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.V_prd_groups.Add(v_prd_groups);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = v_prd_groups.iDcategoria }, v_prd_groups);
        }

        // DELETE: api/V_prd_groups/5
        [ResponseType(typeof(V_prd_groups))]
        public IHttpActionResult DeleteV_prd_groups(int id)
        {
            V_prd_groups v_prd_groups = db.V_prd_groups.Find(id);
            if (v_prd_groups == null)
            {
                return NotFound();
            }

            db.V_prd_groups.Remove(v_prd_groups);
            db.SaveChanges();

            return Ok(v_prd_groups);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool V_prd_groupsExists(int id)
        {
            return db.V_prd_groups.Count(e => e.iDcategoria == id) > 0;
        }
    }
}