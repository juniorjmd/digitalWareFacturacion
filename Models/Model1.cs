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
        public virtual DbSet<Vw_customer> Vw_customer { get; set; }

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

            modelBuilder.Entity<Vw_customer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Vw_customer>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Vw_customer>()
                .Property(e => e.idNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Vw_customer>()
                .Property(e => e.label)
                .IsFixedLength();

            modelBuilder.Entity<Vw_customer>()
                .Property(e => e.name_typ_id)
                .IsUnicode(false);
        }
    }
}
