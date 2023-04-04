namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cl_typeId
    {
        [Key]
        public int idTypeId { get; set; }

        [Required]
        [StringLength(10)]
        public string label { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }
    }
}
