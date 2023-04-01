using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace apiFacturacionPrb.Models
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<prd_brands> prd_brands { get; set; }
        public virtual DbSet<prd_groups> prd_groups { get; set; }
        public virtual DbSet<prd_inventory_stock> prd_inventory_stock { get; set; }
        public virtual DbSet<prd_inventory_warehouse> prd_inventory_warehouse { get; set; }
        public virtual DbSet<prd_product> prd_product { get; set; }
        public virtual DbSet<Sl_discounts> Sl_discounts { get; set; }
        public virtual DbSet<Sl_document> Sl_document { get; set; }
        public virtual DbSet<Sl_document_products> Sl_document_products { get; set; }
        public virtual DbSet<Sl_document_States> Sl_document_States { get; set; }
        public virtual DbSet<Sl_taxes> Sl_taxes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<prd_brands>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<prd_brands>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<prd_groups>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<prd_groups>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<prd_inventory_stock>()
                .Property(e => e.cntInicial)
                .HasPrecision(18, 0);

            modelBuilder.Entity<prd_inventory_stock>()
                .Property(e => e.cntVendida)
                .HasPrecision(16, 2);

            modelBuilder.Entity<prd_inventory_stock>()
                .Property(e => e.cntComprada)
                .HasPrecision(16, 2);

            modelBuilder.Entity<prd_inventory_stock>()
                .Property(e => e.cntDevuelta)
                .HasPrecision(16, 2);

            modelBuilder.Entity<prd_inventory_stock>()
                .Property(e => e.cntTotalActual)
                .HasPrecision(23, 2);

            modelBuilder.Entity<prd_inventory_warehouse>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<prd_inventory_warehouse>()
                .Property(e => e.descripcon)
                .IsUnicode(false);

            modelBuilder.Entity<prd_product>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<prd_product>()
                .Property(e => e.codigoBarras)
                .IsUnicode(false);

            modelBuilder.Entity<prd_product>()
                .Property(e => e.nombre1)
                .IsUnicode(false);

            modelBuilder.Entity<prd_product>()
                .Property(e => e.nombre2)
                .IsUnicode(false);

            modelBuilder.Entity<prd_product>()
                .Property(e => e.precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Sl_discounts>()
                .Property(e => e.apricaA)
                .IsFixedLength();

            modelBuilder.Entity<Sl_discounts>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Sl_discounts>()
                .Property(e => e.tipoValor)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Sl_discounts>()
                .Property(e => e.valor)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Sl_discounts>()
                .Property(e => e.esIncluido)
                .IsFixedLength();

            modelBuilder.Entity<Sl_discounts>()
                .Property(e => e.estado)
                .IsFixedLength();

            modelBuilder.Entity<Sl_document>()
                .Property(e => e.Sub_total)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Sl_document>()
                .Property(e => e.Impuestos)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Sl_document>()
                .Property(e => e.Descuento)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Sl_document_products>()
                .Property(e => e.cantidad)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Sl_document_products>()
                .Property(e => e.precioUnitario)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Sl_document_products>()
                .Property(e => e.TotalImpuestos)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Sl_document_products>()
                .Property(e => e.TotalDescuentos)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Sl_document_products>()
                .Property(e => e.TotalSinImpuestos)
                .HasPrecision(28, 2);

            modelBuilder.Entity<Sl_document_products>()
                .Property(e => e.TotalFinal)
                .HasPrecision(29, 2);

            modelBuilder.Entity<Sl_document_States>()
                .Property(e => e.nombre)
                .IsFixedLength();

            modelBuilder.Entity<Sl_document_States>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Sl_taxes>()
                .Property(e => e.apricaA)
                .IsFixedLength();

            modelBuilder.Entity<Sl_taxes>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Sl_taxes>()
                .Property(e => e.tipoValor)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Sl_taxes>()
                .Property(e => e.valor)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Sl_taxes>()
                .Property(e => e.esIncluido)
                .IsFixedLength();

            modelBuilder.Entity<Sl_taxes>()
                .Property(e => e.estado)
                .IsFixedLength();
        }
    }
}
