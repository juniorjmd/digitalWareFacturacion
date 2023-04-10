namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VSl_document_products
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDocProduct { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iDproducto { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal cantidad { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal precioUnitario { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal TotalImpuestos { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal TotalDescuentos { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalSinImpuestos { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalFinal { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDocumento { get; set; }

        [StringLength(201)]
        public string nombreProducto { get; set; }
    }
}
