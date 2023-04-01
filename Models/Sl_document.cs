namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sl_document
    {
        public int id { get; set; }

        public int id_estado { get; set; }

        public decimal Sub_total { get; set; }

        public decimal Impuestos { get; set; }

        public decimal Descuento { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? totalFactura { get; set; }

        [Column(TypeName = "datetime2")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime date_doc { get; set; }

        [Column(TypeName = "datetime2")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime doc_date { get; set; }
    }
}
