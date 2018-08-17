using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeriMudra.Models
{
    [Table("CityGroup")]
    public class CityGroup
    {
        [Key]
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public string CityIds { get; set; }
    }
}