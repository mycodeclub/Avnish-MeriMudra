using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeriMudra.Models;

namespace MeriMudra.Areas.Admin.Controllers
{
    public class BanksController : Controller
    {
        private MmDbContext db = new MmDbContext();

        private string validImageFormets = @"bmp, jpg, jpeg, gif, png";
        // GET: Admin/Banks
        public ActionResult Index()
        {
            return View(db.Banks.ToList());
        }

        // GET: Admin/Banks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = db.Banks.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        // GET: Admin/Banks/Create
        public ActionResult Create()
        {
            return View(new Bank());
        }

        // POST: Admin/Banks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BankId,Name,LogoUrl")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(bank.LogoUrl) || (bank.BankLogoUpload != null && bank.BankLogoUpload.ContentLength > 0))
                {
                    if ((bank.BankLogoUpload != null && bank.BankLogoUpload.ContentLength > 0))
                    {
                        if (!validImageFormets.Contains(bank.BankLogoUpload?.FileName.Split('.').Last()))
                        {
                            ModelState.AddModelError("CardImageUpload", "Upload Card Image in a valid image format, allowed formats are : " + validImageFormets);
                            return View(bank);
                        }
                        else
                        {
                            bank.LogoUrl = SaveImageAndGetUrl(bank.BankLogoUpload);
                        }
                    }
                    bank.LogoUrl = SaveImageAndGetUrl(bank.BankLogoUpload);
                    db.Banks.Add(bank);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("BankLogoUpload", "This field is required");
                    return View(bank);
                }




                bank.LogoUrl = SaveImageAndGetUrl(bank.BankLogoUpload);
                db.Banks.Add(bank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bank);
        }

        private string SaveImageAndGetUrl(HttpPostedFileBase bankImage)
        {
            var fileName = DateTime.UtcNow.ToString().Replace(" ", string.Empty).Replace(":", string.Empty).Replace("/", string.Empty) + bankImage.FileName.Replace(" ", string.Empty);
            var imgUrl = @"\images\cards\" + fileName;
            bankImage.SaveAs(Server.MapPath(imgUrl));
            return imgUrl;
        }
        // GET: Admin/Banks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = db.Banks.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        // POST: Admin/Banks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BankId,Name,LogoUrl")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bank);
        }

        // GET: Admin/Banks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = db.Banks.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        // POST: Admin/Banks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public void DeleteConfirmed(int id)
        {
            Bank bank = db.Banks.Find(id);
            db.Banks.Remove(bank);
            db.SaveChanges();
           // return RedirectToAction("Index");
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
