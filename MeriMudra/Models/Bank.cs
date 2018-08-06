using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeriMudra.Models
{
    [Table("Bank")]
    public class Bank
    {
        [DisplayName("Bank")]
        public int BankId { get; set; }
        public string Name { get; set; }
        [DisplayName("Bank Logo Url")]
        public string LogoUrl { get; set; }
        [NotMapped]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase BankLogoUpload { get; set; }
    }
}