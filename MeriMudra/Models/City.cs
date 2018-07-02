
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MeriMudra.Models
{
    [Table("CityMaster")]
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "City")]
        [Column("City")]
        public string Name { get; set; }

        [Display(Name = "State Id")]
        public int StateId { get; set; }

        [ForeignKey("StateId")]
        public State State { get; set; }
    }
}