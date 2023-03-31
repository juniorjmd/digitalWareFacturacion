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
    public class Cl_typeIdController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Cl_typeId
        public IQueryable<Cl_typeId> GetCl_typeId()
        {
            return db.Cl_typeId;
        }

        // GET: api/Cl_typeId/5
        [ResponseType(typeof(Cl_typeId))]
        public IHttpActionResult GetCl_typeId(int id)
        {
            Cl_typeId cl_typeId = db.Cl_typeId.Find(id);
            if (cl_typeId == null)
            {
                return NotFound();
            }

            return Ok(cl_typeId);
        }

        // PUT: api/Cl_typeId/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCl_typeId(int id, Cl_typeId cl_typeId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cl_typeId.id)
            {
                return BadRequest();
            }

            db.Entry(cl_typeId).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cl_typeIdExists(id))
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

        // POST: api/Cl_typeId
        [ResponseType(typeof(Cl_typeId))]
        public IHttpActionResult PostCl_typeId(Cl_typeId cl_typeId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cl_typeId.Add(cl_typeId);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cl_typeId.id }, cl_typeId);
        }

        // DELETE: api/Cl_typeId/5
        [ResponseType(typeof(Cl_typeId))]
        public IHttpActionResult DeleteCl_typeId(int id)
        {
            Cl_typeId cl_typeId = db.Cl_typeId.Find(id);
            if (cl_typeId == null)
            {
                return NotFound();
            }

            db.Cl_typeId.Remove(cl_typeId);
            db.SaveChanges();

            return Ok(cl_typeId);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Cl_typeIdExists(int id)
        {
            return db.Cl_typeId.Count(e => e.id == id) > 0;
        }
    }
}