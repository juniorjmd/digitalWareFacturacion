namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class V_sl_taxes
    {
        [Key]
        public int iDimpuesto { get; set; }

        [StringLength(1)]
        public string aplicaA { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(1)]
        public string tipoValor { get; set; }

        public decimal? valor { get; set; }

        [StringLength(1)]
        public string esIncluido { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [StringLength(1)]
        public string esVariable { get; set; }
    }
}
