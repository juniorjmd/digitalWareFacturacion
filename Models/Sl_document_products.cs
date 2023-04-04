namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sl_document_products
    {
        [Key]
        public int idDocProduct { get; set; }

        public int iDproducto { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cantidad { get; set; }

        public decimal precioUnitario { get; set; }

        public decimal TotalImpuestos { get; set; }

        public decimal TotalDescuentos { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? TotalSinImpuestos { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? TotalFinal { get; set; }

        public int IdDocumento { get; set; }

        public virtual prd_product prd_product { get; set; }

        public virtual Sl_document Sl_document { get; set; }
    }
}
