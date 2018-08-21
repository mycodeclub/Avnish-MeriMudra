using MeriMudra.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeriMudra.Models
{
    [Table("CcEligibilityCriteria")]
    public class EligibilityCriteria
    {
        [Key]
        public int EligibilityCriteriaId { get; set; }
        public int CardId { get; set; }
        public int CityGroupId { get; set; }
        [DisplayName("Allowed Min Salary ")]
        public decimal MinSalary { get; set; }
        [DisplayName("Allowed Min ITR ")]
        public decimal MinItr { get; set; }
        public CityGroupViewModel CityGroup { get { return new CityGroupViewModel(CityGroupId); } }

    }
}