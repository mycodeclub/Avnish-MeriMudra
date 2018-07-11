using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeriMudra.Models
{
    [Table("BusinessPartnerProgramme")]
    public class BusinessPartnerProgramme
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }


        [Required(ErrorMessage = "Pan number is required")]
        [Index("UQ_BPP_Pan", IsUnique = true)]
        public string PAN { get; set; }

        [Required(ErrorMessage = "Aadhar number is required")]
        // [RegularExpression("[0-9]{11,11}\\d)|([0-9]{9,9}+v", ErrorMessage = "Number Only")]
        //[Index("UQ_BPP_Aadhar", IsUnique = true)]
        [Index(IsUnique = true)]
        public string Aadhar { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string City { get; set; }


        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

    }
}