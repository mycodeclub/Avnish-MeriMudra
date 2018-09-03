using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeriMudra.Models
{
    [Table("ApplicationStatusMaster")]
    public class ApplicationStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string Status { get; set; }
    }
}