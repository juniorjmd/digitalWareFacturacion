namespace apiFacturacionPrb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class prd_product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public prd_product()
        {
            prd_inventory_stock = new HashSet<prd_inventory_stock>();
            Sl_document_products = new HashSet<Sl_document_products>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iDproducto { get; set; }

        [Required]
        [StringLength(50)]
        public string codigo { get; set; }

        [Required]
        [StringLength(150)]
        public string codigoBarras { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre1 { get; set; }

        [StringLength(100)]
        public string nombre2 { get; set; }

        public int iDcategoria { get; set; }

        public int iDmarca { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaCreacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaEdicion { get; set; }

        [Column(TypeName = "date")]
        public DateTime usuarioCreacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? usuarioEdicion { get; set; }

        [Column(TypeName = "money")]
        public decimal precio { get; set; }

        public int iDimpuesto { get; set; }

        public int iDdescuento { get; set; }

        public virtual prd_brands prd_brands { get; set; }

        public virtual prd_groups prd_groups { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prd_inventory_stock> prd_inventory_stock { get; set; }

        public virtual Sl_discounts Sl_discounts { get; set; }

        public virtual Sl_taxes Sl_taxes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sl_document_products> Sl_document_products { get; set; }
    }
}
