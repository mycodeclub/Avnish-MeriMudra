
namespace MeriMudra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CcDetails")]
    public partial class CcDetail
    {
        [Key]
        [Column("CcDetailId")]
        public int CcDetailId { get; set; }
        public Nullable<int> CardId { get; set; }
        public Nullable<int> CcInfoSectionMasterId { get; set; }
        public string Heading { get; set; }
        public string Point { get; set; }
        public string Key_ { get; set; }
        public string Value { get; set; }

        [ForeignKey("CcInfoSectionMasterId")]
        public virtual CcInfoSectionMaster CcInfoSectionMaster { get; set; }
        [ForeignKey("CcDetailId")]
        public virtual CreditCard CreditCard { get; set; }
    }
}
