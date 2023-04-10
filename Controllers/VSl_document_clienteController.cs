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
    public class VSl_document_clienteController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/VSl_document_cliente
        public IQueryable<VSl_document_cliente> GetVSl_document_cliente()
        {
            return db.VSl_document_cliente;
        }

        // GET: api/V_Sl_discounts
        [HttpGet]
        [Route("api/documentosClienteActivos")]
        public IQueryable<VSl_document_cliente> Get_documentos_estado_cero()
        {
            return db.VSl_document_cliente.Where(s => s.idEstado.Equals(1)).AsQueryable();
        }



        // GET: api/VSl_document_cliente/5
        [ResponseType(typeof(VSl_document_cliente))]
        public IHttpActionResult GetVSl_document_cliente(int id)
        {
            VSl_document_cliente vSl_document_cliente = db.VSl_document_cliente.Find(id);
            if (vSl_document_cliente == null)
            {
                return NotFound();
            }

            return Ok(vSl_document_cliente);
        }

        // PUT: api/VSl_document_cliente/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVSl_document_cliente(int id, VSl_document_cliente vSl_document_cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vSl_document_cliente.idDocumento)
            {
                return BadRequest();
            }

            db.Entry(vSl_document_cliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VSl_document_clienteExists(id))
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

        // POST: api/VSl_document_cliente
        [ResponseType(typeof(VSl_document_cliente))]
        public IHttpActionResult PostVSl_document_cliente(VSl_document_cliente vSl_document_cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VSl_document_cliente.Add(vSl_document_cliente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VSl_document_clienteExists(vSl_document_cliente.idDocumento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vSl_document_cliente.idDocumento }, vSl_document_cliente);
        }

        // DELETE: api/VSl_document_cliente/5
        [ResponseType(typeof(VSl_document_cliente))]
        public IHttpActionResult DeleteVSl_document_cliente(int id)
        {
            VSl_document_cliente vSl_document_cliente = db.VSl_document_cliente.Find(id);
            if (vSl_document_cliente == null)
            {
                return NotFound();
            }

            db.VSl_document_cliente.Remove(vSl_document_cliente);
            db.SaveChanges();

            return Ok(vSl_document_cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VSl_document_clienteExists(int id)
        {
            return db.VSl_document_cliente.Count(e => e.idDocumento == id) > 0;
        }
    }
}