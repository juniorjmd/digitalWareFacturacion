namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class prd_brands
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public prd_brands()
        {
            prd_product = new HashSet<prd_product>();
        }

        [Key]
        public int iDmarca { get; set; }

        [Required]
        [StringLength(150)]
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prd_product> prd_product { get; set; }
    }
}
