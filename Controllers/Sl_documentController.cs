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
    public class Sl_documentController : ApiController
    {
        private Model1 db = new Model1();
        private Model2 db2 = new Model2();

        // GET: api/Sl_document
        public IQueryable<Sl_document> GetSl_document()
        {
            return db.Sl_document;
        }

        // GET: api/Sl_document/5
        [ResponseType(typeof(Sl_document))]
        public IHttpActionResult GetSl_document(int id)
        {
            Sl_document sl_document = db.Sl_document.Find(id);
            if (sl_document == null)
            {
                return NotFound();
            }

            return Ok(sl_document);
        }

        // GET: api/V_Sl_discounts
        [HttpGet]
        [Route("api/documentosActivos")]
        public IQueryable<VSl_document> Get_documentos_estado_cero()
        {
            return db2.VSl_document.Where(s => s.idEstado.Equals(0)).AsQueryable();
        }


        // put: api/eliminarDocumento/2
        [HttpPut]
        [Route("api/eliminarDocumento/{idDocumento}")]
        public IHttpActionResult Put_EliminarDocumentos( int idDocumento)
        {
            Sl_document sl_document = new Sl_document()  ;
            Sl_document_States Sl_document_States = new Sl_document_States();

            

            if (!Sl_documentExists(idDocumento))
            {
                return NotFound();
            }


            Sl_document_States = (from s in db.Sl_document_States
                           where s.nombre == "eliminado"
                           select s).FirstOrDefault<Sl_document_States>();
             
             
            if (Sl_document_States == null) {
                throw new Exception("no exite el estado eliminado en la lista de estado documento "); 
            }

            sl_document = db.Sl_document.Find(idDocumento);

            sl_document.idEstado = Sl_document_States.idEstado;
            db.Entry(sl_document);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
                 
            }


            return StatusCode(HttpStatusCode.NoContent);
        }


        // put: api/cerrarDocumento/2
        [HttpPut]
        [Route("api/cerrarDocumento/{idDocumento}")]
        public IHttpActionResult Put_CerrarDocumentos(int idDocumento)
        {
            Sl_document sl_document = new Sl_document();
            Sl_document_States Sl_document_States = new Sl_document_States();



            if (!Sl_documentExists(idDocumento))
            {
                return NotFound();
            }


            Sl_document_States = (from s in db.Sl_document_States
                                  where s.nombre == "factura"
                                  select s).FirstOrDefault<Sl_document_States>();


            if (Sl_document_States == null)
            {
                throw new Exception("no exite el estado factura en la lista de estado documento ");
            }

            sl_document = db.Sl_document.Find(idDocumento);


            if (sl_document.Sl_document_products.Count <= 0) {
                throw new Exception("El documento no tiene Productos a facturar");
            }

            sl_document.idEstado = Sl_document_States.idEstado;
            db.Entry(sl_document);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;

            }


            return StatusCode(HttpStatusCode.NoContent);
        }



        // PUT: api/Sl_document/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSl_document(int id, Sl_document sl_document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sl_document.idDocumento)
            {
                return BadRequest();
            }

            db.Entry(sl_document).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sl_documentExists(id))
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

        // POST: api/Sl_document
        [ResponseType(typeof(Sl_document))]
        public IHttpActionResult PostSl_document(Sl_document sl_document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sl_document.Add(sl_document);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sl_document.idDocumento }, sl_document);
        }

        // DELETE: api/Sl_document/5
        [ResponseType(typeof(Sl_document))]
        public IHttpActionResult DeleteSl_document(int id)
        {
            Sl_document sl_document = db.Sl_document.Find(id);
            if (sl_document == null)
            {
                return NotFound();
            }

            db.Sl_document.Remove(sl_document);
            db.SaveChanges();

            return Ok(sl_document);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sl_documentExists(int id)
        {
            return db.Sl_document.Count(e => e.idDocumento == id) > 0;
        }
    }
}