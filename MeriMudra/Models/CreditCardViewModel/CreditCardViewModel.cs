using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeriMudra.Models.CreditCardViewModel
{


    public class CreditCardViewModel
    {

        public string CardName { get; set; }
        public string BankName { get; set; }
        public string CardDescription { get; set; }
        public string ServiceProvider { get; set; }
        public List<string> ReasonsToGetThisCard { get; set; }
        public BenefitsAndFeature _BenefitsAndFeature { get; set; }
        public RedeemReward _RedeemReward { get; set; }
        public FeesAndCharge _FeesAndCharge { get; set; }
        public BorrowPrivilege _BorrowPrivilege { get; set; }

        public CreditCardViewModel()
        {
            CardName = string.Empty;
            BankName = string.Empty;
            CardDescription = string.Empty;
            _BenefitsAndFeature = new BenefitsAndFeature()
            {
                HeadingText = string.Empty,
                Points = new List<string>(),
            };
            _RedeemReward = new RedeemReward()
            {
                HeadingText = string.Empty,
                Points = new List<string>(),
            };
            _FeesAndCharge = new FeesAndCharge()
            {
                HeadingText = string.Empty,
                Points = new List<KeyValuePair<string, string>>(),
            };
            _BorrowPrivilege = new BorrowPrivilege()
            {
                HeadingText = string.Empty,
                Points = new List<KeyValuePair<string, string>>(),
            };
        }

        public CreditCardViewModel(int CardId)
        {
            MmDbContext db = new MmDbContext();
            var card = db.CreditCards.Where(cc => cc.CardId == CardId).SingleOrDefault();
            var CcDetail = db.CcDetails.Where(cc => cc.CardId == CardId).ToList();
            CardName = card.CardName;
            BankName = card.Bank.Name;
            CardDescription = card.CardDescription;
            _BenefitsAndFeature = new BenefitsAndFeature()
            {
                HeadingText = CcDetail.Where(ccd => ccd.CcInfoSectionMasterId == 1).FirstOrDefault().Heading,
                Points = new List<string>(),
            }; CcDetail.ForEach(ccd => { if (ccd.CcInfoSectionMasterId == 1) _BenefitsAndFeature.Points.Add(ccd.Point); });
            _RedeemReward = new RedeemReward()
            {
                HeadingText = CcDetail.Where(ccd => ccd.CcInfoSectionMasterId == 3).FirstOrDefault().Heading,
                Points = new List<string>(),
            }; CcDetail.ForEach(ccd => { if (ccd.CcInfoSectionMasterId == 3) _RedeemReward.Points.Add(ccd.Point); });
            _FeesAndCharge = new FeesAndCharge()
            {
                HeadingText = CcDetail.Where(ccd => ccd.CcInfoSectionMasterId == 2).FirstOrDefault().Heading,
                Points = new List<KeyValuePair<string, string>>(),
            }; CcDetail.ForEach(ccd => { if (ccd.CcInfoSectionMasterId == 2) { _FeesAndCharge.Points.Add(new KeyValuePair<string, string>(ccd.Key_, ccd.Value)); } });
            _BorrowPrivilege = new BorrowPrivilege()
            {
                HeadingText = CcDetail.Where(ccd => ccd.CcInfoSectionMasterId == 4).FirstOrDefault().Heading,
                Points = new List<KeyValuePair<string, string>>(),
            }; CcDetail.ForEach(ccd => { if (ccd.CcInfoSectionMasterId == 4) { _FeesAndCharge.Points.Add(new KeyValuePair<string, string>(ccd.Key_, ccd.Value)); } });
        }
    }


    public class BenefitsAndFeature
    {
        public string HeadingText { get; set; }
        public List<string> Points { get; set; }
    }
    public class RedeemReward
    {
        public string HeadingText { get; set; }
        public List<string> Points { get; set; }
    }
    public class FeesAndCharge
    {
        public string HeadingText { get; set; }
        public List<KeyValuePair<string, string>> Points { get; set; }
    }
    public class BorrowPrivilege
    {
        public string HeadingText { get; set; }
        public List<KeyValuePair<string, string>> Points { get; set; }
    }
}