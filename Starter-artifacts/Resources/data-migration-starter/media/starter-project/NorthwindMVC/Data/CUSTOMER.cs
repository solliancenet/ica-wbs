namespace NorthwindMVC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NW.CUSTOMERS")]
    public partial class CUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER()
        {
            ORDERS = new HashSet<ORDER>();
            CUSTOMERDEMOGRAPHICS = new HashSet<CUSTOMERDEMOGRAPHIC>();
        }

        [StringLength(5)]
        public string CUSTOMERID { get; set; }

        [Required]
        [StringLength(40)]
        public string COMPANYNAME { get; set; }

        [StringLength(30)]
        public string CONTACTNAME { get; set; }

        [StringLength(30)]
        public string CONTACTTITLE { get; set; }

        [StringLength(60)]
        public string ADDRESS { get; set; }

        [StringLength(30)]
        public string CITY { get; set; }

        [StringLength(15)]
        public string REGION { get; set; }

        [StringLength(10)]
        public string POSTALCODE { get; set; }

        [StringLength(15)]
        public string COUNTRY { get; set; }

        [StringLength(24)]
        public string PHONE { get; set; }

        [StringLength(24)]
        public string FAX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUSTOMERDEMOGRAPHIC> CUSTOMERDEMOGRAPHICS { get; set; }
    }
}
