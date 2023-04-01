namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class prd_product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string codigo { get; set; }

        [StringLength(150)]
        public string codigoBarras { get; set; }

        [StringLength(100)]
        public string nombre1 { get; set; }

        [StringLength(100)]
        public string nombre2 { get; set; }

        public int? categoria { get; set; }

        public int? marca { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaCreacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaEdicion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? usuarioCreacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? usuarioEdicion { get; set; }

        [Column(TypeName = "money")]
        public decimal precio { get; set; }

        public int? impuesto { get; set; }

        public int? descuento { get; set; }
    }
}
