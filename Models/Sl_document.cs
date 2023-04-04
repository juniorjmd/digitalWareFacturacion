namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sl_document
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sl_document()
        {
            Sl_document_products = new HashSet<Sl_document_products>();
            Sl_document_taxes = new HashSet<Sl_document_taxes>();
        }

        [Key]
        public int idDocumento { get; set; }

        public int idEstado { get; set; }

        public decimal Sub_total { get; set; }

        public decimal Impuestos { get; set; }

        public decimal Descuento { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? totalFactura { get; set; }

        [Column(TypeName = "datetime2")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime doc_date { get; set; }

        public int? idCliente { get; set; }

        public virtual Cl_customer Cl_customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sl_document_products> Sl_document_products { get; set; }

        public virtual Sl_document_States Sl_document_States { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sl_document_taxes> Sl_document_taxes { get; set; }
    }
}
