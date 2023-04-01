namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class prd_inventory_stock
    {
        public int id { get; set; }

        public int? idProducto { get; set; }

        public int? idBodega { get; set; }

        public decimal? cntInicial { get; set; }

        public decimal? cntVendida { get; set; }

        public decimal? cntComprada { get; set; }

        public decimal? cntDevuelta { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? cntTotalActual { get; set; }
    }
}
