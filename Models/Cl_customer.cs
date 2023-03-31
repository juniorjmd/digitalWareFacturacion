namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cl_customer
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string lastname { get; set; }

        [Column(TypeName = "date")]
        public DateTime birthdate { get; set; }

        [Required]
        [StringLength(50)]
        public string idNumber { get; set; }

        public int typeId { get; set; }
    }
}
