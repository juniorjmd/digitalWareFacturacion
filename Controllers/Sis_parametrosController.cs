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
    public class Sis_parametrosController : ApiController
    {
        private Model3 db = new Model3();

        // GET: api/Sis_parametros
        public IQueryable<Sis_parametros> GetSis_parametros()
        {
            return db.Sis_parametros;
        }

        // GET: api/Sis_parametros/5
        [ResponseType(typeof(Sis_parametros))]
        public IHttpActionResult GetSis_parametros(int id)
        {
            Sis_parametros sis_parametros = db.Sis_parametros.Find(id);
            if (sis_parametros == null)
            {
                return NotFound();
            }

            return Ok(sis_parametros);
        }

        // PUT: api/Sis_parametros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSis_parametros(int id, Sis_parametros sis_parametros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sis_parametros.idParametro)
            {
                return BadRequest();
            }

            db.Entry(sis_parametros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sis_parametrosExists(id))
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

        // POST: api/Sis_parametros
        [ResponseType(typeof(Sis_parametros))]
        public IHttpActionResult PostSis_parametros(Sis_parametros sis_parametros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sis_parametros.Add(sis_parametros);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sis_parametros.idParametro }, sis_parametros);
        }

        // DELETE: api/Sis_parametros/5
        [ResponseType(typeof(Sis_parametros))]
        public IHttpActionResult DeleteSis_parametros(int id)
        {
            Sis_parametros sis_parametros = db.Sis_parametros.Find(id);
            if (sis_parametros == null)
            {
                return NotFound();
            }

            db.Sis_parametros.Remove(sis_parametros);
            db.SaveChanges();

            return Ok(sis_parametros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sis_parametrosExists(int id)
        {
            return db.Sis_parametros.Count(e => e.idParametro == id) > 0;
        }
    }
}