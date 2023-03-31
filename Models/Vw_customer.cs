namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vw_customer
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string lastname { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime birthdate { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string idNumber { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int typeId { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(10)]
        public string label { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string name_typ_id { get; set; }
    }
}
