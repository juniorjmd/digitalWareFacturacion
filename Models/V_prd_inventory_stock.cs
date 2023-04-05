namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class V_prd_inventory_stock
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iDproducto { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idBodega { get; set; }

        public decimal? cntInicial { get; set; }

        public decimal? cntVendida { get; set; }

        public decimal? cntComprada { get; set; }

        public decimal? cntDevuelta { get; set; }

        public decimal? cntTotalActual { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string nombreBodega { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(100)]
        public string nombreProducto { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string codigo { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(150)]
        public string codigoBarras { get; set; }

        [StringLength(100)]
        public string nombreProducto2 { get; set; }

        public int? iDcategoria { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iDmarca { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "money")]
        public decimal precio { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iDimpuesto { get; set; }

        public int? iDdescuento { get; set; }
    }
}
