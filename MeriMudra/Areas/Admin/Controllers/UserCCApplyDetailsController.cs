using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeriMudra.Models;

namespace MeriMudra.Areas.Admin.Controllers
{
    public class UserCCApplyDetailsController : Controller
    {
        private MmDbContext db = new MmDbContext();

        // GET: Admin/UserCCApplyDetails
        public ActionResult Index()
        {
            ViewData["city"] = db.Citys.ToList();
            return View(db.UserCCApplyDetail.ToList());
        }

        // GET: Admin/UserCCApplyDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCCApplyDetail userCCApplyDetail = db.UserCCApplyDetail.Find(id);
            if (userCCApplyDetail == null)
            {
                return HttpNotFound();
            }
            ViewData["city"] = db.Citys.ToList();
            ViewBag.ApplicationStatus = db.ApplicationStatus.Find(userCCApplyDetail.ApplicationStatusId);
            return View(userCCApplyDetail);
        }

        // GET: Admin/UserCCApplyDetails/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationStatus = db.ApplicationStatus.ToList();
            ViewData["city"] = db.Citys.ToList();
            return View();
        }

        // POST: Admin/UserCCApplyDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployerType,CompanyName,GrossIncomeOrNetSalary,Name,DOB,CityName,MobileNumber,email,CreditCardMaxLimit,OTP,isMobileNumberVerify,isEmailVerify,isUserActive,ApplicationStatusId")] UserCCApplyDetail userCCApplyDetail)
        {
            if (ModelState.IsValid)
            {
                db.UserCCApplyDetail.Add(userCCApplyDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationStatus = db.ApplicationStatus.ToList();
            ViewData["city"] = db.Citys.ToList();
            return View(userCCApplyDetail);
        }

        // GET: Admin/UserCCApplyDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCCApplyDetail userCCApplyDetail = db.UserCCApplyDetail.Find(id);
            if (userCCApplyDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationStatus = db.ApplicationStatus.ToList();
            ViewData["city"] = db.Citys.ToList();
            return View(userCCApplyDetail);
        }

        // POST: Admin/UserCCApplyDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployerType,CompanyName,GrossIncomeOrNetSalary,Name,DOB,CityId,CreatedDate,CityName,MobileNumber,email,CreditCardMaxLimit,OTP,isMobileNumberVerify,isEmailVerify,isUserActive,ApplicationStatusId")] UserCCApplyDetail userCCApplyDetail)
        {
            if (ModelState.IsValid)
            {
                userCCApplyDetail.CityName = db.Citys.Find(userCCApplyDetail.CityId).Name;
                db.Entry(userCCApplyDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationStatus = db.ApplicationStatus.ToList();
            ViewData["city"] = db.Citys.ToList();
            return View(userCCApplyDetail);
        }

        // GET: Admin/UserCCApplyDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCCApplyDetail userCCApplyDetail = db.UserCCApplyDetail.Find(id);
            if (userCCApplyDetail == null)
            {
                return HttpNotFound();
            }
            return View(userCCApplyDetail);
        }

        // POST: Admin/UserCCApplyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public void DeleteConfirmed(int id)
        {
            UserCCApplyDetail userCCApplyDetail = db.UserCCApplyDetail.Find(id);
            db.UserCCApplyDetail.Remove(userCCApplyDetail);
            db.SaveChanges();
            // return Redirect("Admin/UserCCAppyDetails/Index");
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
