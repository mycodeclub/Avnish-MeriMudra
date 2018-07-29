
namespace MeriMudra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CcInfoSectionMaster")]
    public partial class CcInfoSectionMaster
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public CcInfoSectionMaster()
        //{
        //    this.CcDetails = new HashSet<CcDetail>();
        //}
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CcInfoSectionMasterId { get; set; }
        public string CcMasterPoint { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CcDetail> CcDetails { get; set; }
    }
}
