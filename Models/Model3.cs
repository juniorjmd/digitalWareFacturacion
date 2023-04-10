using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace apiFacturacionPrb.Models
{
    public partial class Model3 : DbContext
    {
        public Model3()
            : base("name=Model3")
        {
        }

        public virtual DbSet<Sis_parametros> Sis_parametros { get; set; }
        public virtual DbSet<Sis_usuario> Sis_usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sis_parametros>()
                .Property(e => e.codParametro)
                .IsFixedLength();

            modelBuilder.Entity<Sis_parametros>()
                .Property(e => e.tipoParametro)
                .IsFixedLength();

            modelBuilder.Entity<Sis_parametros>()
                .Property(e => e.strParametro)
                .IsFixedLength();

            modelBuilder.Entity<Sis_parametros>()
                .Property(e => e.intParametro)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sis_usuario>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Sis_usuario>()
                .Property(e => e.pass)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<apiFacturacionPrb.Models.VSl_document_products> VSl_document_products { get; set; }
    }
}
