using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MeriMudra.Models
{
    [Table("CityMaster")]
    public class UserCCApplyDetail
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "AmployerType")]
        [Column("AmployerType")]
        public bool EmployerType { get; set; }

        [Column("CompanyName")]
        public string CompanyName { get; set; }

        [Column("GrossIncomeOrNetSalary")]
        public decimal GrossIncomeOrNetSalary { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Column("CityName")]
        public string CityName { get; set; }

        [Column("CityId")]
        public int CityId { get; set; }

        [Column("PinCode")]
        public int PinCode { get; set; }

        [Column("MobileNumber")]
        public int MobileNumber { get; set; }

        [Column("OTP")]
        public int OTP { get; set; }

        [Column("email")]
        public string email { get; set; }

        [Column("AccountWith")]
        public int AccountWith { get; set; }

        [Column("CreditCardWith")]
        public int CreditCardWith { get; set; }

        [Column("CreditCardMaxLimit")]
        public decimal CreditCardMaxLimit { get; set; }

        [Column("CurrentOrPrevLoan")]
        public bool CurrentOrPrevLoan { get; set; }
    }
    public class detailsForApplyCard
    {
        public List<Bank> Banks { get; set; }
        public List<CreditCard> CreditCards { get; set; }
        public List<City> Citys { get; set; }
    }
}