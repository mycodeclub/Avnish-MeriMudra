using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeriMudra.Models;
using MeriMudra.Models.CreditCardViewModel;
using System.IO;

namespace MeriMudra.Areas.Admin.Controllers
{
    public class CreditCardsController : Controller
    {
        private MmDbContext db = new MmDbContext();
        private string validImageFormets = @"bmp, jpg, jpeg, gif, png";
        // GET: Admin/CreditCards
        public ActionResult Index()
        {
            var creditCards = db.CreditCards.Include(c => c.Bank);
            return View(creditCards.ToList());
        }

        // GET: Admin/CreditCards/Details/5
        public ActionResult Details(int id = 0)
        {
            CreditCardViewModel Card;
            if (id > 0) Card = new CreditCardViewModel(id);
            else Card = new CreditCardViewModel();
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "Name");
            return View(Card);


        }

        // GET: Admin/CreditCards/Create
        public ActionResult Create(int id = 1)
        {
            CreditCardViewModel Card;
            if (id > 0) Card = new CreditCardViewModel(id);
            else Card = new CreditCardViewModel();
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "Name");
            return View("CreateOld", Card);
        }

        // POST: Admin/CreditCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CardId,BankId,CardName,CardDescription,CardImageUrl,ReasonsToGetThisCard")] CreditCardViewModel ccVm, FormCollection collection)
        //        public ActionResult Create(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                //if (creditCard.CardId > 0) db.Entry(creditCard).State = EntityState.Modified;
                //else db.CreditCards.Add(creditCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BankId = new SelectList(db.Banks, "BankId", "Name", ccVm.BankId);
            return View(ccVm);
        }

        // GET: Admin/CreditCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditCard = db.CreditCards.Find(id);
            if (creditCard == null)
            {
                return HttpNotFound();
            }
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "Name", creditCard.BankId);
            return View(creditCard);
        }

        // POST: Admin/CreditCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CardId,BankId,CardName,CardDescription,CardImageUrl")] CreditCard creditCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creditCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "Name", creditCard.BankId);
            return View(creditCard);
        }

        // GET: Admin/CreditCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditCard = db.CreditCards.Find(id);
            if (creditCard == null)
            {
                return HttpNotFound();
            }
            return View(creditCard);
        }

        // POST: Admin/CreditCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreditCardViewModel ccvm = new CreditCardViewModel();
            ccvm.DeleteCreditCard(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //----------------------------------------------------------------------

        public ActionResult SaveCcBasic(int id)
        {
            CreditCardViewModel ccVm;
            if (id > 0) ccVm = new CreditCardViewModel(id);
            else ccVm = new CreditCardViewModel();
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "Name");
            return View(ccVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCcBasic([Bind(Include = "CardId,BankId,CardName,CardDescription,CardImageUrl,ReasonsToGetThisCard,CardImageUpload")] CreditCardViewModel ccVm, FormCollection fc)
        {
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "Name");
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(ccVm.CardImageUrl) || (ccVm.CardImageUpload != null && ccVm.CardImageUpload.ContentLength > 0))
                {
                    if ((ccVm.CardImageUpload != null && ccVm.CardImageUpload.ContentLength > 0))
                    {
                        if (!validImageFormets.Contains(ccVm.CardImageUpload?.FileName.Split('.').Last()))
                        {
                            ModelState.AddModelError("CardImageUpload", "Upload Card Image in a valid image format, allowed formats are : " + validImageFormets);
                            return View(ccVm);
                        }
                        else
                        {
                            ccVm.CardImageUrl = SaveImageAndGetUrl(ccVm.CardImageUpload);
                        }
                    }
                    ccVm.CardId = ccVm.SaveBasic();
                    if (ccVm.CardId > 0)
                        return RedirectToAction("Details", new { id = ccVm.CardId });
                    return RedirectToAction("Details", "creditcards", ccVm.CardId);
                    //                   return RedirectToAction("Details", ccVm.CardId);
                }
                else
                {
                    ModelState.AddModelError("CardImageUpload", "This field is required");
                    return View(ccVm);
                }
            }
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "Name", ccVm.BankId);
            return View(ccVm);
        }

        public ActionResult SaveCcBenefitsAndFeature(int id)
        {
            CreditCardViewModel ccVm;
            if (id > 0) ccVm = new CreditCardViewModel(id);
            else ccVm = new CreditCardViewModel();
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "Name");
            return View(ccVm);
        }
        [HttpPost]
        public ActionResult SaveCcBenefitsAndFeature(CreditCardViewModel ccVm, FormCollection fc)
        {
            ccVm = new CreditCardViewModel(ccVm.CardId);
            ccVm._BenefitsAndFeature = new List<BenefitsAndFeature>();
            foreach (var key in fc.AllKeys)
            {
                if (key.Equals("CardId")) continue;
                if (key.Contains("Point"))
                {
                    if (ccVm._BenefitsAndFeature.Last().Points == null)
                        ccVm._BenefitsAndFeature.Last().Points = new List<string>() { };
                    ccVm._BenefitsAndFeature.Last().Points.Add(fc[key].ToString());
                }
                else { ccVm._BenefitsAndFeature.Add(new BenefitsAndFeature() { HeadingText = fc[key] }); }
            }

            if (ccVm.SaveCcDetails(CcInfoSection.BenefitsAndFeatures))
                return RedirectToAction("Details", new { id = ccVm.CardId });
            return View(ccVm);
        }
        public ActionResult SaveCcFeesAndCharges(int id)
        {
            CreditCardViewModel ccVm;
            if (id > 0) ccVm = new CreditCardViewModel(id);
            else ccVm = new CreditCardViewModel();
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "Name");
            return View(ccVm);
        }
        public ActionResult SaveCcRedeemReward(int id)
        {
            CreditCardViewModel ccVm;
            if (id > 0) ccVm = new CreditCardViewModel(id);
            else ccVm = new CreditCardViewModel();
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "Name");
            return View(ccVm);
        }
        public ActionResult SaveCcBorrowPrivilege(int id)
        {
            CreditCardViewModel ccVm;
            if (id > 0) ccVm = new CreditCardViewModel(id);
            else ccVm = new CreditCardViewModel();
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "Name");
            return View(ccVm);
        }
        private string SaveImageAndGetUrl(HttpPostedFileBase cardImage)
        {
            {
                var fileName = DateTime.UtcNow.ToString().Replace(" ", string.Empty).Replace(":", string.Empty).Replace("/", string.Empty) + cardImage.FileName.Replace(" ", string.Empty);
               // var fileName = "abc";
                var imgUrl = @"\images\cards\" + fileName;
                string path = Server.MapPath("/images/cards/");
                //                cardImage.SaveAs(Server.MapPath("~/images/cards" + fileName));
                // cardImage.SaveAs(path);
                //var productPath = Server.MapPath("~/App_Upload/Product");
                cardImage.SaveAs(Path.Combine(path, fileName));
                return imgUrl;// @"\images\" + fileName;
            }
        }


        [HttpPost]
        public ActionResult SaveCcRedeemReward(CreditCardViewModel ccVm, FormCollection fc)
        {
            ccVm = new CreditCardViewModel(ccVm.CardId);
            ccVm._RedeemReward = new List<RedeemReward>() { };
            foreach (var key in fc.AllKeys)
            {
                if (key.Equals("CardId")) continue;
                if (key.Contains("Point"))
                {
                    if (ccVm._RedeemReward.Last().Points == null)
                        ccVm._RedeemReward.Last().Points = new List<string>() { };
                    ccVm._RedeemReward.Last().Points.Add(fc[key].ToString());
                }
                else { ccVm._RedeemReward.Add(new RedeemReward() { HeadingText = fc[key] }); }
            }
            if (ccVm.SaveCcDetails(CcInfoSection.RedeemRewards))
                return RedirectToAction("Details", new { id = ccVm.CardId });
            return View(ccVm);
        }



        [HttpPost]
        public ActionResult SaveCcFeesAndCharges(CreditCardViewModel ccVm, FormCollection fc)
        {
            ccVm = new CreditCardViewModel(ccVm.CardId);
            ccVm._FeesAndCharge = new List<FeesAndCharge>() { };
            foreach (var key in fc.AllKeys)
            {
                if (key.Equals("CardId")) continue;
                if (key.Contains("Key") || key.Contains("Value"))
                {
                    if (ccVm._FeesAndCharge.Last().Points == null)
                        ccVm._FeesAndCharge.Last().Points = new List<KeyValuePair<string, string>> { };
                    if (key.Contains("Key"))
                    {
                        int keyValueOrPointId = GetkeyValueOrPointId(key);
                        int HeadingId = GetHeadingId(key, keyValueOrPointId.ToString().Length);
                        ccVm._FeesAndCharge.Last().Points.Add(new KeyValuePair<string, string>(fc[key], fc["Heading" + HeadingId + "Value" + keyValueOrPointId]));
                    }
                }
                else { ccVm._FeesAndCharge.Add(new FeesAndCharge() { HeadingText = fc[key] }); }
            }
            if (ccVm.SaveCcDetails(CcInfoSection.FeesAndCharges))
                return RedirectToAction("Details", new { id = ccVm.CardId });
            return View(ccVm);
        }


        [HttpPost]
        public ActionResult SaveCcBorrowPrivilege(CreditCardViewModel ccVm, FormCollection fc)
        {
            ccVm = new CreditCardViewModel(ccVm.CardId);
            ccVm._BorrowPrivilege = new List<BorrowPrivilege>() { };
            foreach (var key in fc.AllKeys)
            {
                if (key.Equals("CardId")) continue;
                if (key.Contains("Key") || key.Contains("Value"))
                {
                    if (ccVm._BorrowPrivilege.Last().Points == null)
                        ccVm._BorrowPrivilege.Last().Points = new List<KeyValuePair<string, string>> { };
                    if (key.Contains("Key"))
                    {
                        int keyValueOrPointId = GetkeyValueOrPointId(key);
                        int HeadingId = GetHeadingId(key, keyValueOrPointId.ToString().Length);
                        ccVm._BorrowPrivilege.Last().Points.Add(new KeyValuePair<string, string>(fc[key], fc["Heading" + HeadingId + "Value" + keyValueOrPointId]));
                    }
                }
                else { ccVm._BorrowPrivilege.Add(new BorrowPrivilege() { HeadingText = fc[key] }); }
            }

            //            if (ccVm.SaveCcBorrowPrivilege())
            if (ccVm.SaveCcDetails(CcInfoSection.BorrowPriviledges))
                return RedirectToAction("Details", new { id = ccVm.CardId });
            return View(ccVm);
        }

        private int GetkeyValueOrPointId(string str)
        {
            if (!int.TryParse(str.Substring(str.Length - 3), out int id))
            {
                if (!int.TryParse(str.Substring(str.Length - 2), out id))
                    int.TryParse(str.Substring(str.Length - 1), out id);
            }
            return id;
        }

        private int GetHeadingId(string str, int keyValueOrPointIdLength)
        {
            if (!int.TryParse(str.Substring(str.Length - (6 + keyValueOrPointIdLength), 3), out int id))
            {
                if (!int.TryParse(str.Substring(str.Length - (5 + keyValueOrPointIdLength), 2), out id))
                    int.TryParse(str.Substring(str.Length - (4 + keyValueOrPointIdLength), 1), out id);
            }
            return id;
        }
    }
}
