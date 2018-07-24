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

            ViewBag.BankId = new SelectList(db.Banks, "BankId", "Name", ccVm.creditCard.BankId);
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
            CreditCard creditCard = db.CreditCards.Find(id);
            db.CreditCards.Remove(creditCard);
            db.SaveChanges();
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
        public ActionResult SaveCcBasic([Bind(Include = "BankId,CardName,CardDescription,CardImageUrl,ReasonsToGetThisCard,CardImageUpload")] CreditCardViewModel ccVm, FormCollection fc)
        {
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "Name");
            if (ModelState.IsValid)
            {
                var value = fc["creditCard.CardId"];
                if (!string.IsNullOrEmpty(ccVm.CardImageUrl) || (ccVm.CardImageUpload != null && ccVm.CardImageUpload.ContentLength > 0))
                {
                    if ((ccVm.CardImageUpload != null || ccVm.CardImageUpload.ContentLength > 0) && validImageFormets.Contains(ccVm.CardImageUpload.FileName.Split('.').Last()))
                    {
                        ccVm.CardImageUrl = SaveImageAndGetUrl(ccVm.CardImageUpload);
                    }
                    else
                    {
                        ModelState.AddModelError("CardImageUpload", "Upload Card Image in a valid image format, allowed formats are : " + validImageFormets);
                        return View(ccVm);
                    }
                }
                else
                {
                    ModelState.AddModelError("CardImageUpload", "This field is required");
                    return View(ccVm);
                }
                if (ccVm.creditCard.CardId > 0)
                {
                    db.CreditCards.Add(ccVm.creditCard);
                    db.SaveChanges();
                }
                if (ccVm.creditCard.CardId > 0)
                    db.Entry(ccVm.creditCard).State = EntityState.Modified;
                else db.CreditCards.Add(ccVm.creditCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "Name", ccVm.creditCard.BankId);
            return View(ccVm);
        }

        private string SaveImageAndGetUrl(HttpPostedFileBase cardImage)
        {
            {
                var fileName = DateTime.UtcNow.ToString().Replace(" ", string.Empty).Replace(":", string.Empty).Replace("/", string.Empty) + cardImage.FileName.Replace(" ", string.Empty);
                var imgUrl = @"\images\cards\" + fileName;
                //                cardImage.SaveAs(Server.MapPath("~/images/cards" + fileName));
                cardImage.SaveAs(Server.MapPath(imgUrl));
                return imgUrl;// @"\images\" + fileName;
            }
        }
    }
}
