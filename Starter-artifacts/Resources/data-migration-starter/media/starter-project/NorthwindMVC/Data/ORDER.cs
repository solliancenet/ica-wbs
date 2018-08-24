namespace NorthwindMVC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NW.ORDERS")]
    public partial class ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER()
        {
            ORDER_DETAILS = new HashSet<ORDER_DETAILS>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ORDERID { get; set; }

        [StringLength(5)]
        public string CUSTOMERID { get; set; }

        public int? EMPLOYEEID { get; set; }

        public DateTime? ORDERDATE { get; set; }

        public DateTime? REQUIREDDATE { get; set; }

        public DateTime? SHIPPEDDATE { get; set; }

        public int? SHIPVIA { get; set; }

        public decimal? FREIGHT { get; set; }

        [StringLength(40)]
        public string SHIPNAME { get; set; }

        [StringLength(60)]
        public string SHIPADDRESS { get; set; }

        [StringLength(30)]
        public string SHIPCITY { get; set; }

        [StringLength(15)]
        public string SHIPREGION { get; set; }

        [StringLength(10)]
        public string SHIPPOSTALCODE { get; set; }

        [StringLength(15)]
        public string SHIPCOUNTRY { get; set; }

        public virtual CUSTOMER CUSTOMER { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_DETAILS> ORDER_DETAILS { get; set; }

        public virtual SHIPPER SHIPPER { get; set; }
    }
}
