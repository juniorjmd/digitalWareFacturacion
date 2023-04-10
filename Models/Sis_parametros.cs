namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sis_parametros
    {
        [Key]
        public int idParametro { get; set; }

        [StringLength(10)]
        public string codParametro { get; set; }

        [StringLength(1)]
        public string tipoParametro { get; set; }

        [StringLength(15)]
        public string strParametro { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? intParametro { get; set; }
    }
}
