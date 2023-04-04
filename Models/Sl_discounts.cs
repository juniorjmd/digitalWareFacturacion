namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sl_discounts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sl_discounts()
        {
            prd_product = new HashSet<prd_product>();
        }

        [Key]
        public int iDdescuento { get; set; }

        [StringLength(1)]
        public string aplicaA { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(1)]
        public string tipoValor { get; set; }

        public decimal? valor { get; set; }

        [StringLength(1)]
        public string esIncluido { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prd_product> prd_product { get; set; }
    }
}
