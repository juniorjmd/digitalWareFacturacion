namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class V_prd_groups
    {
        [Key]
        public int iDcategoria { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(150)]
        public string descripcion { get; set; }
    }
}
