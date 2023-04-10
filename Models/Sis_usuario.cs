namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sis_usuario
    {
        [Key]
        public int idUsuario { get; set; }

        [StringLength(16)]
        public string usuario { get; set; }

        [Column(TypeName = "text")]
        public string pass { get; set; }

        public int? idCliente { get; set; }
    }
}
