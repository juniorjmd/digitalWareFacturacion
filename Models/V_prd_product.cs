namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class V_prd_product
    {
        [Key]
        [Column(Order = 0)]
        public int iDproducto { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string codigo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(150)]
        public string codigoBarras { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string nombre1 { get; set; }

        [StringLength(100)]
        public string nombre2 { get; set; }

        public int? iDcategoria { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iDmarca { get; set; }

        public DateTimeOffset? fechaCreacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaEdicion { get; set; }

        [StringLength(100)]
        public string usuarioCreacion { get; set; }

        [StringLength(100)]
        public string usuarioEdicion { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "money")]
        public decimal precio { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iDimpuesto { get; set; }

        public int? iDdescuento { get; set; }
    }
}
