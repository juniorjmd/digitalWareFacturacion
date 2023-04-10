namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VSl_document
    {
        [Key]
        [Column(Order = 0)]
        public int idDocumento { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idEstado { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal Sub_total { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal Impuestos { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal Descuento { get; set; }

        public decimal? totalFactura { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "datetime2")]
        public DateTime doc_date { get; set; }

        public int? idCliente { get; set; }
    }
}
