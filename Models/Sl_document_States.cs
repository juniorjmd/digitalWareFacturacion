namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sl_document_States
    {
        public int id { get; set; }

        [StringLength(10)]
        public string nombre { get; set; }

        [StringLength(150)]
        public string descripcion { get; set; }
    }
}
