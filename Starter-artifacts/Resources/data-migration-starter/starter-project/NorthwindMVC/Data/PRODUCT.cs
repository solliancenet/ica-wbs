namespace NorthwindMVC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NW.PRODUCTS")]
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            ORDER_DETAILS = new HashSet<ORDER_DETAILS>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PRODUCTID { get; set; }

        [Required]
        [StringLength(40)]
        public string PRODUCTNAME { get; set; }

        public int? SUPPLIERID { get; set; }

        public int? CATEGORYID { get; set; }

        [StringLength(20)]
        public string QUANTITYPERUNIT { get; set; }

        public decimal? UNITPRICE { get; set; }

        public short? UNITSINSTOCK { get; set; }

        public short? UNITSONORDER { get; set; }

        public short? REORDERLEVEL { get; set; }

        public byte DISCONTINUED { get; set; }

        public virtual CATEGORy CATEGORy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_DETAILS> ORDER_DETAILS { get; set; }

        public virtual SUPPLIER SUPPLIER { get; set; }
    }
}
