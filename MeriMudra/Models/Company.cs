using System.ComponentModel.DataAnnotations;

namespace MeriMudra.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }
    }
}