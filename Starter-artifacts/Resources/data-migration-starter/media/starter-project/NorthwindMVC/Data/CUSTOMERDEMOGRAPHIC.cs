namespace NorthwindMVC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NW.CUSTOMERDEMOGRAPHICS")]
    public partial class CUSTOMERDEMOGRAPHIC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMERDEMOGRAPHIC()
        {
            CUSTOMERS = new HashSet<CUSTOMER>();
        }

        [Key]
        [StringLength(10)]
        public string CUSTOMERTYPEID { get; set; }

        [StringLength(200)]
        public string CUSTOMERDESC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUSTOMER> CUSTOMERS { get; set; }
    }
}
