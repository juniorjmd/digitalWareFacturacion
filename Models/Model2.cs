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

        public virtual DbSet<V_prd_brands> V_prd_brands { get; set; }
        public virtual DbSet<V_prd_groups> V_prd_groups { get; set; }
        public virtual DbSet<V_prd_inventory_stock> V_prd_inventory_stock { get; set; }
        public virtual DbSet<V_prd_inventory_warehouse> V_prd_inventory_warehouse { get; set; }
        public virtual DbSet<V_prd_product> V_prd_product { get; set; }
        public virtual DbSet<V_Sl_discounts> V_Sl_discounts { get; set; }
        public virtual DbSet<V_sl_taxes> V_sl_taxes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<V_prd_brands>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_brands>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_groups>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_groups>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_inventory_stock>()
                .Property(e => e.cntInicial)
                .HasPrecision(18, 0);

            modelBuilder.Entity<V_prd_inventory_stock>()
                .Property(e => e.cntVendida)
                .HasPrecision(16, 2);

            modelBuilder.Entity<V_prd_inventory_stock>()
                .Property(e => e.cntComprada)
                .HasPrecision(16, 2);

            modelBuilder.Entity<V_prd_inventory_stock>()
                .Property(e => e.cntDevuelta)
                .HasPrecision(16, 2);

            modelBuilder.Entity<V_prd_inventory_stock>()
                .Property(e => e.cntTotalActual)
                .HasPrecision(23, 2);

            modelBuilder.Entity<V_prd_inventory_stock>()
                .Property(e => e.nombreBodega)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_inventory_stock>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_inventory_stock>()
                .Property(e => e.nombreProducto)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_inventory_stock>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_inventory_stock>()
                .Property(e => e.codigoBarras)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_inventory_stock>()
                .Property(e => e.nombreProducto2)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_inventory_stock>()
                .Property(e => e.precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<V_prd_inventory_warehouse>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_inventory_warehouse>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_product>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_product>()
                .Property(e => e.codigoBarras)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_product>()
                .Property(e => e.nombre1)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_product>()
                .Property(e => e.nombre2)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_product>()
                .Property(e => e.usuarioCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_product>()
                .Property(e => e.usuarioEdicion)
                .IsUnicode(false);

            modelBuilder.Entity<V_prd_product>()
                .Property(e => e.precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<V_Sl_discounts>()
                .Property(e => e.aplicaA)
                .IsFixedLength();

            modelBuilder.Entity<V_Sl_discounts>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<V_Sl_discounts>()
                .Property(e => e.tipoValor)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<V_Sl_discounts>()
                .Property(e => e.valor)
                .HasPrecision(16, 2);

            modelBuilder.Entity<V_Sl_discounts>()
                .Property(e => e.esIncluido)
                .IsFixedLength();

            modelBuilder.Entity<V_Sl_discounts>()
                .Property(e => e.estado)
                .IsFixedLength();

            modelBuilder.Entity<V_sl_taxes>()
                .Property(e => e.aplicaA)
                .IsFixedLength();

            modelBuilder.Entity<V_sl_taxes>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<V_sl_taxes>()
                .Property(e => e.tipoValor)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<V_sl_taxes>()
                .Property(e => e.valor)
                .HasPrecision(16, 2);

            modelBuilder.Entity<V_sl_taxes>()
                .Property(e => e.esIncluido)
                .IsFixedLength();

            modelBuilder.Entity<V_sl_taxes>()
                .Property(e => e.estado)
                .IsFixedLength();

            modelBuilder.Entity<V_sl_taxes>()
                .Property(e => e.esVariable)
                .IsFixedLength();
        }
    }
}
