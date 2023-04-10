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
    public class Sl_document_productsController : ApiController
    {
        private Model1 db = new Model1();
        private Model2 db2 = new Model2();

        // GET: api/Sl_document_products
        public IQueryable<Sl_document_products> GetSl_document_products()
        {
            return db.Sl_document_products;
        }

        // GET: api/Sl_document_products/5
        [ResponseType(typeof(Sl_document_products))]
        public IHttpActionResult GetSl_document_products(int id)
        {
            Sl_document_products sl_document_products = db.Sl_document_products.Find(id);
            if (sl_document_products == null)
            {
                return NotFound();
            }

            return Ok(sl_document_products);
        }

        // PUT: api/Sl_document_products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSl_document_products(int id, Sl_document_products sl_document_products)
        {
            Sl_taxes prd_taxes;
            Sl_discounts Sl_discounts;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sl_document_products.idDocProduct)
            {
                return BadRequest();
            }
            prd_product prd_product = db.prd_product.Find(sl_document_products.iDproducto);
            if (prd_product == null)
            {
                throw new Exception("El producto a ingresar no Existe");
            }

            if (sl_document_products.cantidad <= 0)
            {
                throw new Exception("La cantidad debe ser mayor a cero");
            }
            Sl_discounts = db.Sl_discounts.Find(prd_product.iDdescuento);
                  
            prd_taxes = prd_product.Sl_taxes;
            sl_document_products.precioUnitario = prd_product.precio ;

            if (Sl_discounts != null && Sl_discounts.aplicaA.Trim().Equals("P"))
            {
                    decimal valorTotal = (decimal)Sl_discounts.valor;
                if (  valorTotal> 0)
                {
                    if (Sl_discounts.tipoValor.Trim().Equals("P"))
                    {
                        valorTotal = sl_document_products.precioUnitario * valorTotal / 100;
                    }

                    if (Sl_discounts.esIncluido.Trim().Equals("S")) {
                        sl_document_products.precioUnitario = sl_document_products.precioUnitario +
                                   valorTotal;
                    }

                    sl_document_products.TotalDescuentos = valorTotal * sl_document_products.cantidad;

                }
            } 

            if (prd_taxes != null && prd_taxes.aplicaA.Trim().Equals("P"))
            {
                decimal valorTotal = (decimal)prd_taxes.valor;
                if (valorTotal > 0)
                {
                    if (prd_taxes.tipoValor.Trim().Equals("P"))
                    {
                        valorTotal = sl_document_products.precioUnitario * valorTotal / 100;
                    }

                    if (prd_taxes.esIncluido.Trim().Equals("S"))
                    {
                        sl_document_products.precioUnitario -= valorTotal;
                    }
                    sl_document_products.TotalImpuestos  = valorTotal * sl_document_products.cantidad;
                }
            } 

            db.Entry(sl_document_products).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sl_document_productsExists(id))
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

        // POST: api/Sl_document_products
        [ResponseType(typeof(Sl_document_products))]
        public IHttpActionResult PostSl_document_products(Sl_document_products sl_document_products)
        {
            Sl_taxes prd_taxes;
            Sl_discounts Sl_discounts;
            VSl_document_products VSl_document_products = new VSl_document_products();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            prd_product prd_product = db.prd_product.Find(sl_document_products.iDproducto);
            if (prd_product == null)
            {
                throw new Exception("El producto a ingresar no Existe");
            }

            if (sl_document_products.cantidad <= 0)
            {
                throw new Exception("La cantidad debe ser mayor a cero");
            }
            Sl_discounts = db.Sl_discounts.Find(prd_product.iDdescuento);
            prd_taxes = prd_product.Sl_taxes;
            sl_document_products.precioUnitario = prd_product.precio ;

            if (Sl_discounts != null && Sl_discounts.aplicaA.Trim().Equals("P"))
            {
                    decimal valorTotal = (decimal)Sl_discounts.valor;
                if (  valorTotal> 0)
                {
                    if (Sl_discounts.tipoValor.Trim().Equals("P"))
                    {
                        valorTotal = sl_document_products.precioUnitario * valorTotal / 100;
                    }

                    if (Sl_discounts.esIncluido.Trim().Equals("S")) {
                        sl_document_products.precioUnitario = sl_document_products.precioUnitario +
                                   valorTotal;
                    }

                    sl_document_products.TotalDescuentos =  valorTotal * sl_document_products.cantidad;

                }
            } 
            if (prd_taxes != null && prd_taxes.aplicaA.Trim().Equals("P"))
            {
                decimal valorTotal = (decimal)prd_taxes.valor;
                if (valorTotal > 0)
                {
                    if (prd_taxes.tipoValor.Trim().Equals("P"))
                    {
                        valorTotal = sl_document_products.precioUnitario * valorTotal / 100;
                    }

                    if (prd_taxes.esIncluido.Trim().Equals("S"))
                    {
                        sl_document_products.precioUnitario -= valorTotal;
                    }
                    sl_document_products.TotalImpuestos  = valorTotal * sl_document_products.cantidad;
                }
            } 

            db.Sl_document_products.Add(sl_document_products);
            db.SaveChanges();
            
            VSl_document_products.idDocProduct = sl_document_products.idDocProduct;
            VSl_document_products.iDproducto = sl_document_products.iDproducto;
            VSl_document_products.cantidad = sl_document_products.cantidad;
            VSl_document_products.precioUnitario = sl_document_products.precioUnitario;
            VSl_document_products.TotalImpuestos = sl_document_products.TotalImpuestos;
            VSl_document_products.TotalDescuentos = sl_document_products.TotalDescuentos;
            VSl_document_products.TotalSinImpuestos = sl_document_products.TotalSinImpuestos;
            VSl_document_products.TotalFinal = sl_document_products.TotalFinal;
            VSl_document_products.idDocumento = sl_document_products.idDocumento;

            return CreatedAtRoute("DefaultApi", new { id = sl_document_products.idDocProduct }, VSl_document_products);
        }

        // DELETE: api/Sl_document_products/5
        [ResponseType(typeof(Sl_document_products))]
        public IHttpActionResult DeleteSl_document_products(int id)
        {
            Sl_document_products sl_document_products = db.Sl_document_products.Find(id);
            if (sl_document_products == null)
            {
                return NotFound();
            }

            db.Sl_document_products.Remove(sl_document_products);
            db.SaveChanges();

            return Ok(sl_document_products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sl_document_productsExists(int id)
        {
            return db.Sl_document_products.Count(e => e.idDocProduct == id) > 0;
        }
    }
}