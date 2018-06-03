using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MeriMudra.Models
{
    public class MmDbContext : DbContext
    {
        public MmDbContext() : base("name=MmDbConnectionString") { }
        public virtual DbSet<City> Citys { get; set; }
        public virtual DbSet<State> States { get; set; }

        public System.Data.Entity.DbSet<MeriMudra.Models.BusinessPartnerProgramme> BusinessPartnerProgrammes { get; set; }
    }
}