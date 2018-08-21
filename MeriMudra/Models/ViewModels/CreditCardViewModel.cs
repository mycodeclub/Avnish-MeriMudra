using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeriMudra.Models.ViewModels
{

    public enum CcInfoSection { CCHighLights, BenefitsAndFeatures, FeesAndCharges, RedeemRewards, BorrowPriviledges };

    public class CreditCardViewModel
    {
        public CreditCardViewModel()
        {
            MmDbContext db = new MmDbContext();
            ReasonsToGetThisCard = new List<string>() { string.Empty };
            BanksSelectList = db.Banks.Select(x => new SelectListItem
            {
                Value = x.BankId.ToString(),
                Text = x.Name,
            }).ToList();
            _BenefitsAndFeature = new List<BenefitsAndFeature>() { new BenefitsAndFeature() { HeadingText = string.Empty, Points = new List<string>(), } };
            _RedeemReward = new List<RedeemReward>() { new RedeemReward() { HeadingText = string.Empty, Points = new List<string>(), } };
            _FeesAndCharge = new List<FeesAndCharge>() { new FeesAndCharge() { HeadingText = string.Empty, Points = new List<KeyValuePair<string, string>>(), } };
            _BorrowPrivilege = new List<BorrowPrivilege>() { new BorrowPrivilege() { HeadingText = string.Empty, SubHeadingText = string.Empty, Points = new List<KeyValuePair<string, string>>(), } };
            EligibilityCriteria = new List<EligibilityCriteria> { new EligibilityCriteria() };
        }
        public CreditCardViewModel(int CardId)
        {
            MmDbContext db = new MmDbContext();
            var cCard = db.CreditCards.Where(cc => cc.CardId == CardId).SingleOrDefault();
            BankId = cCard.BankId;
            this.CardId = cCard.CardId;
            BanksSelectList = db.Banks.Select(x => new SelectListItem
            {
                Value = x.BankId.ToString(),
                Text = x.Name,
                Selected = (x.BankId == BankId) ? true : false,
            }).ToList();
            CardName = cCard.CardName;
            CardDescription = cCard.CardDescription;
            CardImageUrl = cCard.CardImageUrl;
            BankName = cCard.Bank.Name;
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
            if (db.CcEligibilityCriterias.Any(ec => ec.CardId == cCard.CardId))
            {
                EligibilityCriteria = db.CcEligibilityCriterias.Where(ec => ec.CardId == cCard.CardId).ToList();

            }

        }
        private MmDbContext db = new MmDbContext();
        public int BankId { get; set; }
        public int CardId { get; set; }
        [DisplayName("Credit Card Name")]
        public string CardName { get; set; }
        [DisplayName("Card Description")]
        public string CardDescription { get; set; }
        public string CardImageUrl { get; set; }
        public string BankName { get; set; }
        public string BankLogoUrl { get; set; }
        public List<SelectListItem> BanksSelectList { get; set; }
        public string ServiceProvider { get; set; }
        public List<CityGroupViewModel> CcFilter { get; set; }
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
        [DisplayName("Card Image")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase CardImageUpload { get; set; }

        public List<EligibilityCriteria> EligibilityCriteria { get; set; }
        public int SaveBasic()
        {
            #region Save / Update Credit Card 
            CreditCard cc = new CreditCard
            {
                CardName = CardName,
                CardImageUrl = CardImageUrl,
                CardDescription = CardDescription,
                CardId = CardId,
                BankId = BankId
            };
            if (CardId > 0) { db.Entry(cc).State = EntityState.Modified; }
            else { db.CreditCards.Add(cc); }
            #endregion Save / Update Credit Card End

            db.CcDetails.RemoveRange(db.CcDetails.Where(ccd => ccd.CardId == CardId && ccd.CcInfoSectionMasterId == 1).ToList());
            ReasonsToGetThisCard.ForEach(r =>
            {
                var ccdetail = new CcDetail() { Point = r, CcInfoSectionMasterId = 1, Heading = "Top Reasion To Get The Card", CardId = CardId };
                db.CcDetails.Add(ccdetail);
            });
            db.SaveChanges();
            if (CardId == 0) CardId = db.CreditCards.Max(ccc => (int)ccc.CardId);
            return CardId;
        }
        private bool SaveBenefitsAndFeature()
        {
            db.CcDetails.RemoveRange(db.CcDetails.Where(ccd => ccd.CardId == CardId && ccd.CcInfoSectionMasterId == 2).ToList());
            foreach (var benefit in _BenefitsAndFeature)
                if (benefit.Points != null && benefit.Points.Any())
                    foreach (var point in benefit.Points)
                        db.CcDetails.Add(new CcDetail() { CardId = CardId, CcInfoSectionMasterId = 2, Heading = benefit.HeadingText, Point = point });
            return db.SaveChanges() > 0 ? true : false;
        }
        private bool SaveRedeemReward()
        {
            db.CcDetails.RemoveRange(db.CcDetails.Where(ccd => ccd.CardId == CardId && ccd.CcInfoSectionMasterId == 4).ToList());
            foreach (var rr in _RedeemReward)
                if (rr.Points != null && rr.Points.Any())
                    foreach (var point in rr.Points)
                        db.CcDetails.Add(new CcDetail() { CardId = CardId, CcInfoSectionMasterId = 4, Heading = rr.HeadingText, Point = point });
            return db.SaveChanges() > 0 ? true : false;
        }
        private bool SaveCcFeesAndCharges()
        {
            db.CcDetails.RemoveRange(db.CcDetails.Where(ccd => ccd.CardId == CardId && ccd.CcInfoSectionMasterId == 3).ToList());
            foreach (var rr in _FeesAndCharge)
                if (rr.Points != null && rr.Points.Any())
                    foreach (var point in rr.Points)
                        db.CcDetails.Add(new CcDetail() { CardId = CardId, CcInfoSectionMasterId = 3, Heading = rr.HeadingText, Key_ = point.Key, Value = point.Value });
            return db.SaveChanges() > 0 ? true : false;
        }
        private bool SaveCcBorrowPrivilege()
        {
            db.CcDetails.RemoveRange(db.CcDetails.Where(ccd => ccd.CardId == CardId && ccd.CcInfoSectionMasterId == 5).ToList());
            foreach (var bp in _BorrowPrivilege)
                if (bp.Points != null && bp.Points.Any())
                    foreach (var point in bp.Points)
                        db.CcDetails.Add(new CcDetail() { CardId = CardId, CcInfoSectionMasterId = 5, Heading = bp.HeadingText, Key_ = point.Key, Value = point.Value });
            return db.SaveChanges() > 0 ? true : false;
        }
        public bool SaveCcDetails(CcInfoSection section)
        {
            bool restult = false;
            switch (section)
            {
                case CcInfoSection.BenefitsAndFeatures:
                    restult = SaveBenefitsAndFeature();
                    break;
                case CcInfoSection.FeesAndCharges:
                    restult = SaveCcFeesAndCharges();
                    break;
                case CcInfoSection.RedeemRewards:
                    restult = SaveRedeemReward();
                    break;
                case CcInfoSection.BorrowPriviledges:
                    restult = SaveCcBorrowPrivilege();
                    break;
            }
            return restult;
        }
        public void DeleteCreditCard(int cardId)
        {
            db.CcDetails.RemoveRange(db.CcDetails.Where(ccd => ccd.CardId == cardId).ToList());
            db.CreditCards.Remove(db.CreditCards.Find(cardId));
            db.SaveChanges();
        }

    }




}