using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeriMudra.Models.ViewModels
{
    public class CityGroupViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string CityIds { get; set; }
        public List<City> IncludedCitys { get; set; }
        public CityGroupViewModel(int id)
        {
            var db = new MmDbContext();
            var cg = db.CityGroups.Where(g => g.GroupId == id).FirstOrDefault();
            this.GroupId = cg.GroupId;
            this.GroupName = cg.GroupName;
            this.CityIds = cg.CityIds;
            this.IncludedCitys = new List<City>();
            this.IncludedCitys = db.Citys.SqlQuery("SELECT Id, City as Name, StateId FROM dbo.CityMaster where id in (" + CityIds + ")").ToList<City>();
            IncludedCitys.ForEach(city => { city.State = db.States.Find(city.StateId); });
        }
    }
}