using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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
        [Required]
        [RegularExpression(@"[A-Z]{5}\d{4}[A-Z]{1}", ErrorMessage = "Please Provide A Valid Pan Number")]
        public string PAN { get; set; }
        [Required]
        [RegularExpression(@"^\d{4}\s\d{4}\s\d{4}$", ErrorMessage = "Please Provide A Valid Aadhar Number")]
        public string Aadhar { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string City { get; set; }


        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

    }
}