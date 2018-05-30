using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeriMudra.Models
{
    public class BusinessPartnerProgramme
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"[A-Z]{5}\d{4}[A-Z]{1}", ErrorMessage = "Please Provide A Valid Pan Number")]
        public string PAN { get; set; }
        [RegularExpression(@"^\d{4}\s\d{4}\s\d{4}$", ErrorMessage = "Please Provide A Valid Aadhar Number")]
        public string Aadhar { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
    }
}