using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeriMudra.Models
{
    [Table("CCBenefitsAndFeature")]
    public class BenefitsAndFeature
    {
        [Key]
        //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BenefitsAndFeatureId { get; set; }
        [Column("CardID")]
        public int CardId { get; set; }
        [Column("Heading")]
        public string HeadingText { get; set; }
        public string Point { get; set; }
    }
}