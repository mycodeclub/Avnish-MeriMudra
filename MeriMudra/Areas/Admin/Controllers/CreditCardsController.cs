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

        // GET: Admin/CreditCards
        public ActionResult Index()
        {
            var creditCards = db.CreditCards.Include(c => c.Bank);
            return View(creditCards.ToList());
        }

        // GET: Admin/CreditCards/Details/5
        public ActionResult Details(int? id)
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

        // GET: Admin/CreditCards/Create
        public ActionResult Create(int id = 0)
        {
            var Card = new CreditCardViewModel();
            if (id > 0) Card = new CreditCardViewModel(id);
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "Name");
            return View(Card);
        }

        // POST: Admin/CreditCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CardId,BankId,CardName,CardDescription,CardImageUrl,ReasonsToGetThisCard")] CreditCardViewModel ccVm)
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
    }
}
