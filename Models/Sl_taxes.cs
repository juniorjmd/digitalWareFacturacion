namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sl_taxes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sl_taxes()
        {
            prd_product = new HashSet<prd_product>();
            Sl_document_taxes = new HashSet<Sl_document_taxes>();
        }

        [Key]
        public int iDimpuesto { get; set; }

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

        [StringLength(1)]
        public string esVariable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prd_product> prd_product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sl_document_taxes> Sl_document_taxes { get; set; }
    }
}
