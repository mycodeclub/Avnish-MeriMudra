using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeriMudra.Models.ViewModels
{
    public class BenefitsAndFeature
    {
        public int CardId { get; set; }
        public string HeadingText { get; set; }
        public List<string> Points { get; set; }
    }
}