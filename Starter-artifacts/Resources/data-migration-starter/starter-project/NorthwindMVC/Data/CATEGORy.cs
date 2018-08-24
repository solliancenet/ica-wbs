namespace NorthwindMVC.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NW.CATEGORIES")]
    public partial class CATEGORy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORy()
        {
            PRODUCTS = new HashSet<PRODUCT>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CATEGORYID { get; set; }

        [Required]
        [StringLength(15)]
        public string CATEGORYNAME { get; set; }

        [StringLength(500)]
        public string DESCRIPTION { get; set; }

        public byte[] PICTURE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT> PRODUCTS { get; set; }
    }
}
