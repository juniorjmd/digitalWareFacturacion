namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class V_prd_inventory_warehouse
    {
        [Key]
        [Column(Order = 0)]
        public int idBodega { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }
    }
}
