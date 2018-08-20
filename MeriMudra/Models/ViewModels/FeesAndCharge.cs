using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeriMudra.Models.ViewModels
{
    public class FeesAndCharge
    {
        [Required]
        public string HeadingText { get; set; }

        [Required]
        public List<KeyValuePair<string, string>> Points { get; set; }
    }
}