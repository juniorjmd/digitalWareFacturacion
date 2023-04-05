namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class V_prd_brands
    {
        [Key]
        [Column(Order = 0)]
        public int iDmarca { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(150)]
        public string nombre { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "text")]
        public string descripcion { get; set; }
    }
}
