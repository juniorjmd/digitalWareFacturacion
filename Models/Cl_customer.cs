namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cl_customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cl_customer()
        {
            Sl_document = new HashSet<Sl_document>();
        }

        [Key]
        public int idCliente { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string lastname { get; set; }

        [Column(TypeName = "date")]
        public DateTime birthdate { get; set; }

        [Required]
        [StringLength(50)]
        public string idNumber { get; set; }

        public int idTypeId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sl_document> Sl_document { get; set; }
    }
}
