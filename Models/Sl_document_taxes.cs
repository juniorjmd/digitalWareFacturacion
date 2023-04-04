namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sl_document_taxes
    {
        [Key]
        public int idTaxeDocumento { get; set; }

        public int idDocumento { get; set; }

        public int iDimpuesto { get; set; }

        [Column(TypeName = "money")]
        public decimal valorTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal baseImpuesto { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cantidad { get; set; }

        public virtual Sl_document Sl_document { get; set; }

        public virtual Sl_taxes Sl_taxes { get; set; }
    }
}
