namespace NorthwindMVC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NW.ORDER_DETAILS")]
    public partial class ORDER_DETAILS
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ORDERID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PRODUCTID { get; set; }

        public decimal UNITPRICE { get; set; }

        public int QUANTITY { get; set; }

        [Column(TypeName = "float")]
        public decimal DISCOUNT { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
