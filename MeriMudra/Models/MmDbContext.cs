using System.Data.Entity;

namespace MeriMudra.Models
{
    public class MmDbContext : DbContext
    {
        public MmDbContext() : base("name=MmDbConnectionString") { }
        public virtual DbSet<City> Citys { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<BusinessPartnerProgramme> BusinessPartnerProgrammes { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }

        public virtual DbSet<CcDetail> CcDetails { get; set; }
        public virtual DbSet<CcInfoSectionMaster> CcInfoSectionMasters { get; set; }

    }
}