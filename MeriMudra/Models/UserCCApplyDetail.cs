using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MeriMudra.Models
{
    public class UserCCApplyDetail
    {
        [Key]
        public int Id { get; set; }

        public bool? EmployerType { get; set; }
        public string employed_radios { get; set; }
        public string CompanyName { get; set; }
        public decimal GrossIncomeOrNetSalary { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string CityName { get; set; }
        public string CityId { get; set; }
        public string PinCode { get; set; }
        public string MobileNumber { get; set; }
        public string email { get; set; }
        public List<string> AccountWith { get; set; }
        public List<string> CreditCardWith { get; set; }
        public decimal? CreditCardMaxLimit { get; set; }
        public string CurrentOrPrevLoan { get; set; }
        public bool? _CurrentOrPrevLoan { get; set; }
        public int OTP { get; set; }
        public bool isMobileNumberVerify { get; set; }
        public bool isEmailVerify { get; set; }
        public bool isUserActive { get; set; }
        public UserCCApplyDetail()
        {
            Id = 0;
            EmployerType =true;
            employed_radios = "";
            CompanyName = "";
            GrossIncomeOrNetSalary = 0;
            Name = "";
            DOB = "";
            CityName = "";
            CityId = "";
            PinCode = "";
            MobileNumber = "";
            email = "";
            AccountWith = new List<string>();
            CreditCardWith = new List<string>();
            CreditCardMaxLimit = 0;
            CurrentOrPrevLoan = "";
            _CurrentOrPrevLoan = false;
            OTP = 0;
            isMobileNumberVerify = false;
            isEmailVerify = false;
            isUserActive = false;
        }

    }

    public class detailsForApplyCard
    {
        public List<Bank> Banks { get; set; }
        public List<CreditCard> CreditCards { get; set; }
        public List<City> Citys { get; set; }
    }
}