using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MeriMudra.Models
{
    [Table("UserCCApplyDetail")]
    public class UserCCApplyDetail
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Employer Type")]
        public bool? EmployerType { get; set; }
        [NotMapped]
        public string employed_radios { get; set; }
        public string CompanyName { get; set; }
        [DisplayName("Total Income")]
        public decimal? GrossIncomeOrNetSalary { get; set; }
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
        [DisplayName("City")]
        public string CityName { get; set; }

        public int CityId { get; set; }
        [NotMapped]
        public string PinCode { get; set; }
        [DisplayName("Mobile")]
        public string MobileNumber { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        public List<string> AccountWith { get; set; }
        public List<string> CreditCardWith { get; set; }
        public decimal? CreditCardMaxLimit { get; set; }
        [NotMapped]
        public string CurrentOrPrevLoan { get; set; }
        [NotMapped]
        public bool? _CurrentOrPrevLoan { get; set; }
        public int OTP { get; set; }
        public bool isMobileNumberVerify { get; set; }
        public bool isEmailVerify { get; set; }
        public bool isUserActive { get; set; }
        [DisplayName("Apply Date")]
        public DateTime? CreatedDate { get; set; }
        public int CreditCardId { get; set; }
        public string PanCard { get; set; }
        public int ApplicationStatusId { get; set; }
        public UserCCApplyDetail()
        {
            Id = 0;
            EmployerType = true;
            PanCard = employed_radios = "";
            CompanyName = "";
            GrossIncomeOrNetSalary = 0;
            Name = "";
            DOB = DateTime.Now;
            CityName = "";
            CityId = 0;
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
            isUserActive = false; ApplicationStatusId = 1;
        }

    }
    [Table("UserLoanApplyDetail")]
    public class UserLoanApplyDetail
    {
        [Key]
        public int Id { get; set; }

        public bool? EmployerType { get; set; }
        [NotMapped]
        public string employed_radios { get; set; }
        public string CompanyName { get; set; }
        [DisplayName("Income")]
        public decimal? GrossIncomeOrNetSalary { get; set; }
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
        [DisplayName("City")]
        public string CityName { get; set; }
        [NotMapped]
        public string CityId { get; set; }
        [NotMapped]
        public string PinCode { get; set; }
        public string MobileNumber { get; set; }
        public string email { get; set; }
        public List<string> AccountWith { get; set; }
        public List<string> CreditCardWith { get; set; }
        public decimal? CreditCardMaxLimit { get; set; }
        [NotMapped]
        public string CurrentOrPrevLoan { get; set; }
        [NotMapped]
        public bool? _CurrentOrPrevLoan { get; set; }
        public int OTP { get; set; }
        public bool isMobileNumberVerify { get; set; }
        public bool isEmailVerify { get; set; }
        public bool isUserActive { get; set; }
        [DisplayName("Amount")]
        public decimal? Intended_loan_amount { get; set; }
        [DisplayName("Created On")]
        public DateTime? CreatedDate { get; set; }
        public int LoanType { get; set; }
        public string PanCard { get; set; }
        public int ApplicationStatusId { get; set; }
        public UserLoanApplyDetail()
        {
            Intended_loan_amount = 0;
            LoanType = Id = 0;
            EmployerType = true;
            PanCard = employed_radios = "";
            CompanyName = "";
            GrossIncomeOrNetSalary = 0;
            Name = "";
            CreatedDate = DOB = DateTime.Now;
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
            ApplicationStatusId = 1;
        }
    }
    public class detailsForApplyCard
    {
        public List<Bank> Banks { get; set; }
        public List<CreditCard> CreditCards { get; set; }
        public List<City> Citys { get; set; }
        public List<Company> Companys { get; set; }
    }
}