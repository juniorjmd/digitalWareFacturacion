using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace apiFacturacionPrb.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Cl_customer> Cl_customer { get; set; }
        public virtual DbSet<Cl_typeId> Cl_typeId { get; set; }
        public virtual DbSet<prd_brands> prd_brands { get; set; }
        public virtual DbSet<prd_groups> prd_groups { get; set; }
        public virtual DbSet<prd_inventory_stock> prd_inventory_stock { get; set; }
        public virtual DbSet<prd_inventory_warehouse> prd_inventory_warehouse { get; set; }
        public virtual DbSet<prd_product> prd_product { get; set; }
        public virtual DbSet<Sl_discounts> Sl_discounts { get; set; }
        public virtual DbSet<Sl_document> Sl_document { get; set; }
        public virtual DbSet<Sl_document_products> Sl_document_products { get; set; }
        public virtual DbSet<Sl_document_States> Sl_document_States { get; set; }
        public virtual DbSet<Sl_document_taxes> Sl_document_taxes { get; set; }
        public virtual DbSet<Sl_taxes> Sl_taxes { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cl_customer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Cl_customer>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Cl_customer>()
                .Property(e => e.idNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Cl_typeId>()
                .Property(e => e.label)
                .IsFixedLength();

            modelBuilder.Entity<Cl_typeId>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<prd_brands>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<prd_brands>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<prd_brands>()
                .HasMany(e => e.prd_product)
                .WithRequired(e => e.prd_brands)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<prd_groups>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<prd_groups>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<prd_groups>()
                .HasMany(e => e.prd_product)
                .WithRequired(e => e.prd_groups)
                .WillCascadeOnDelete(false);

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
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<prd_inventory_warehouse>()
                .HasMany(e => e.prd_inventory_stock)
                .WithRequired(e => e.prd_inventory_warehouse)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<prd_product>()
                .HasMany(e => e.prd_inventory_stock)
                .WithRequired(e => e.prd_product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<prd_product>()
                .HasMany(e => e.Sl_document_products)
                .WithRequired(e => e.prd_product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sl_discounts>()
                .Property(e => e.aplicaA)
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

            modelBuilder.Entity<Sl_discounts>()
                .HasMany(e => e.prd_product)
                .WithRequired(e => e.Sl_discounts)
                .HasForeignKey(e => e.iDimpuesto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sl_document>()
                .Property(e => e.Sub_total)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Sl_document>()
                .Property(e => e.Impuestos)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Sl_document>()
                .Property(e => e.Descuento)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Sl_document>()
                .HasMany(e => e.Sl_document_products)
                .WithRequired(e => e.Sl_document)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sl_document>()
                .HasMany(e => e.Sl_document_taxes)
                .WithRequired(e => e.Sl_document)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<Sl_document_States>()
                .HasMany(e => e.Sl_document)
                .WithRequired(e => e.Sl_document_States)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sl_document_taxes>()
                .Property(e => e.valorTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Sl_document_taxes>()
                .Property(e => e.baseImpuesto)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Sl_document_taxes>()
                .Property(e => e.cantidad)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Sl_taxes>()
                .Property(e => e.aplicaA)
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

            modelBuilder.Entity<Sl_taxes>()
                .Property(e => e.esVariable)
                .IsFixedLength();

            modelBuilder.Entity<Sl_taxes>()
                .HasMany(e => e.prd_product)
                .WithRequired(e => e.Sl_taxes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sl_taxes>()
                .HasMany(e => e.Sl_document_taxes)
                .WithRequired(e => e.Sl_taxes)
                .WillCascadeOnDelete(false);
        }
    }
}
