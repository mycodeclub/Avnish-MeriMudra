using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeriMudra.Areas.Admin.Models
{
    [Table("Login")]
    public class User
    {
        [Key]
        public int LoginId { get; set; }
        [Required]
        public string LoginName { get; set; }
        [Required]
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string EmailId { get; set; }
        public DateTime? LastLogin { get; set; }
        [NotMapped]
        public bool RememberPassword { get; set; }
    }
}