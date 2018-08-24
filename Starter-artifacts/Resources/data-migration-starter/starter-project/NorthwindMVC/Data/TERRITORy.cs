namespace NorthwindMVC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NW.TERRITORIES")]
    public partial class TERRITORy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TERRITORy()
        {
            EMPLOYEES = new HashSet<EMPLOYEE>();
        }

        [StringLength(20)]
        public string TERRITORYID { get; set; }

        [Required]
        [StringLength(50)]
        public string TERRITORYDESCRIPTION { get; set; }

        public decimal REGIONID { get; set; }

        public virtual REGION REGION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLOYEE> EMPLOYEES { get; set; }
    }
}
