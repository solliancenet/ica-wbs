namespace NorthwindMVC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NW.EMPLOYEES")]
    public partial class EMPLOYEE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLOYEE()
        {
            EMPLOYEES1 = new HashSet<EMPLOYEE>();
            ORDERS = new HashSet<ORDER>();
            TERRITORIES = new HashSet<TERRITORy>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EMPLOYEEID { get; set; }

        [Required]
        [StringLength(20)]
        public string LASTNAME { get; set; }

        [Required]
        [StringLength(10)]
        public string FIRSTNAME { get; set; }

        [StringLength(30)]
        public string TITLE { get; set; }

        [StringLength(25)]
        public string TITLEOFCOURTESY { get; set; }

        public DateTime? BIRTHDATE { get; set; }

        public DateTime? HIREDATE { get; set; }

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
        public string HOMEPHONE { get; set; }

        [StringLength(4)]
        public string EXTENSION { get; set; }

        public byte[] PHOTO { get; set; }

        public byte[] NOTES { get; set; }

        public int? REPORTSTO { get; set; }

        [StringLength(255)]
        public string PHOTOPATH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLOYEE> EMPLOYEES1 { get; set; }

        public virtual EMPLOYEE EMPLOYEE1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TERRITORy> TERRITORIES { get; set; }
    }
}
