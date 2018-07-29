using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeriMudra.Models.CreditCardViewModel
{

    public enum CcInfoSection { CCHighLights, BenefitsAndFeatures, FeesAndCharges, RedeemRewards, BorrowPriviledges };
    public class CreditCardViewModel
    {
        public CreditCard creditCard { get; set; }

        [Required]
        public string ServiceProvider { get; set; }

        [Required]
        public List<string> ReasonsToGetThisCard { get; set; }

        [Required]
        public List<BenefitsAndFeature> _BenefitsAndFeature { get; set; }

        [Required]
        public List<RedeemReward> _RedeemReward { get; set; }

        [Required]
        public List<FeesAndCharge> _FeesAndCharge { get; set; }

        [Required]
        public List<BorrowPrivilege> _BorrowPrivilege { get; set; }

        [DisplayName("Card Image Url")]
        public string CardImageUrl { get; set; }

        [NotMapped]
        [DisplayName("Card Image")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase CardImageUpload { get; set; }

        public CreditCardViewModel()
        {
            creditCard = new CreditCard();
            ReasonsToGetThisCard = new List<string>() { string.Empty };
            _BenefitsAndFeature = new List<BenefitsAndFeature>() { new BenefitsAndFeature() { HeadingText = string.Empty, Points = new List<string>(), } };
            _RedeemReward = new List<RedeemReward>() { new RedeemReward() { HeadingText = string.Empty, Points = new List<string>(), }
};
            _FeesAndCharge = new List<FeesAndCharge>() { new FeesAndCharge() { HeadingText = string.Empty, Points = new List<KeyValuePair<string, string>>(), } };
            _BorrowPrivilege = new List<BorrowPrivilege>() { new BorrowPrivilege() { HeadingText = string.Empty, SubHeadingText = string.Empty, Points = new List<KeyValuePair<string, string>>(), } };
        }

        public CreditCardViewModel(int CardId)
        {
            MmDbContext db = new MmDbContext();
            creditCard = db.CreditCards.Where(cc => cc.CardId == CardId).SingleOrDefault();
            var CcDetail = db.CcDetails.Where(cc => cc.CardId == CardId).OrderBy(cc => cc.CcInfoSectionMasterId).ThenBy(cc => cc.Heading);
            _BenefitsAndFeature = new List<BenefitsAndFeature>() { };
            _FeesAndCharge = new List<FeesAndCharge>() { };
            _RedeemReward = new List<RedeemReward>() { };
            _BorrowPrivilege = new List<BorrowPrivilege>() { };
            ReasonsToGetThisCard = new List<string>() { };

            foreach (var r in CcDetail.Where(ccd => ccd.CcInfoSectionMaster.CcInfoSectionMasterId == 1))
            {
                ReasonsToGetThisCard.Add(r.Point);
            }
            foreach (var bf in CcDetail.Where(ccd => ccd.CcInfoSectionMaster.CcInfoSectionMasterId == 2))
            {
                if (_BenefitsAndFeature.Count == 0 || _BenefitsAndFeature.Last().HeadingText != bf.Heading)
                { _BenefitsAndFeature.Add(new BenefitsAndFeature() { HeadingText = bf.Heading, Points = new List<string>() { bf.Point } }); }
                else _BenefitsAndFeature.LastOrDefault().Points.Add(bf.Point);
            }
            foreach (var bf in CcDetail.Where(ccd => ccd.CcInfoSectionMaster.CcInfoSectionMasterId == 3))
            {
                if (_FeesAndCharge.Count == 0 || _FeesAndCharge.Last().HeadingText != bf.Heading)
                {
                    _FeesAndCharge.Add(new FeesAndCharge()
                    {
                        HeadingText = bf.Heading,
                        Points = new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>(bf.Key_, bf.Value) }
                    });
                }
                else _FeesAndCharge.LastOrDefault().Points.Add(new KeyValuePair<string, string>(bf.Key_, bf.Value));
            }
            foreach (var bf in CcDetail.Where(ccd => ccd.CcInfoSectionMaster.CcInfoSectionMasterId == 4))
            {
                if (_RedeemReward.Count == 0 || _RedeemReward.Last().HeadingText != bf.Heading)
                { _RedeemReward.Add(new RedeemReward() { HeadingText = bf.Heading, Points = new List<string>() { bf.Point } }); }
                else _RedeemReward.LastOrDefault().Points.Add(bf.Point);
            }
            foreach (var bf in CcDetail.Where(ccd => ccd.CcInfoSectionMaster.CcInfoSectionMasterId == 5))
            {
                if (_BorrowPrivilege.Count == 0 || _BorrowPrivilege.Last().HeadingText != bf.Heading)
                {
                    _BorrowPrivilege.Add(new BorrowPrivilege()
                    {
                        HeadingText = bf.Heading,
                        SubHeadingText = bf.Point,
                        Points = new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>(bf.Key_, bf.Value) }
                    });
                }
                else _BorrowPrivilege.LastOrDefault().Points.Add(new KeyValuePair<string, string>(bf.Key_, bf.Value));
            }
        }


        public bool Save()
        {
            return true;
        }
    }


    public class BenefitsAndFeature
    {
        public string HeadingText { get; set; }
        public List<string> Points { get; set; }
    }
    public class RedeemReward
    {
        [Required]
        public string HeadingText { get; set; }
        [Required]
        public List<string> Points { get; set; }
    }
    public class FeesAndCharge
    {
        [Required]
        public string HeadingText { get; set; }

        [Required]
        public List<KeyValuePair<string, string>> Points { get; set; }
    }
    public class BorrowPrivilege
    {
        [Required]
        public string HeadingText { get; set; }

        [Required]
        public string SubHeadingText { get; set; }

        [Required]
        public List<KeyValuePair<string, string>> Points { get; set; }
    }
}