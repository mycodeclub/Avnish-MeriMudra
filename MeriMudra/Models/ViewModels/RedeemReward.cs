using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeriMudra.Models.ViewModels
{
    public class RedeemReward
    {
        [Required]
        public string HeadingText { get; set; }
        [Required]
        public List<string> Points { get; set; }
    }
}