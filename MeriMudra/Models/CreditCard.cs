
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace MeriMudra.Models
{
    [Table("CreditCard")]
    public class CreditCard
    {
        [Key]
        public int CardId { get; set; }

        [DisplayName("Bank")]
        public int BankId { get; set; }

        [DisplayName("Bank")]
        [ForeignKey("BankId")]
        public virtual Bank Bank { get; set; }

        [DisplayName("Card Name")]
        public string CardName { get; set; }

        [DisplayName("Card Description")]
        public string CardDescription { get; set; }

        [DisplayName("Card Image Url")]
        public string CardImageUrl { get; set; }
    }
}