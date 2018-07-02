using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MeriMudra.Models
{
    [Table("StateMaster")]
    public class State
    {
        [Key]
        public int StateId { get; set; }

        [Display(Name = "State")]
        [Column("State")]
        public string Name { get; set; }

        public ICollection<City> Cityes { get; set; }

    }
}