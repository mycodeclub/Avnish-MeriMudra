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
    public class UserLoanApplyDetailsController : Controller
    {
        private MmDbContext db = new MmDbContext();

        // GET: Admin/UserLoanApplyDetails
        public ActionResult Index()
        {
            ViewData["city"] = db.Citys.ToList();
            return View(db.UserLoanApplyDetail.ToList());
        }

        // GET: Admin/UserLoanApplyDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLoanApplyDetail userLoanApplyDetail = db.UserLoanApplyDetail.Find(id);
            if (userLoanApplyDetail == null)
            {
                return HttpNotFound();
            }
            ViewData["city"] = db.Citys.ToList();
            ViewBag.ApplicationStatus = db.ApplicationStatus.Find(userLoanApplyDetail.ApplicationStatusId);
            return View(userLoanApplyDetail);
        }

        // GET: Admin/UserLoanApplyDetails/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationStatus = db.ApplicationStatus.ToList();
            ViewData["city"] = db.Citys.ToList();
            return View();
        }

        // POST: Admin/UserLoanApplyDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployerType,CompanyName,GrossIncomeOrNetSalary,Name,DOB,CityName,MobileNumber,email,CreditCardMaxLimit,OTP,isMobileNumberVerify,isEmailVerify,isUserActive,Intended_loan_amount,ApplicationStatusId")] UserLoanApplyDetail userLoanApplyDetail)
        {
            if (ModelState.IsValid)
            {
                db.UserLoanApplyDetail.Add(userLoanApplyDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationStatus = db.ApplicationStatus.ToList();
            ViewData["city"] = db.Citys.ToList();
            return View(userLoanApplyDetail);
        }

        // GET: Admin/UserLoanApplyDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLoanApplyDetail userLoanApplyDetail = db.UserLoanApplyDetail.Find(id);
            if (userLoanApplyDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationStatus = db.ApplicationStatus.ToList();
            ViewData["city"] = db.Citys.ToList();
            return View(userLoanApplyDetail);
        }

        // POST: Admin/UserLoanApplyDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployerType,CompanyName,GrossIncomeOrNetSalary,Name,DOB,CityName,MobileNumber,email,CreditCardMaxLimit,OTP,isMobileNumberVerify,isEmailVerify,isUserActive,Intended_loan_amount,ApplicationStatusId")] UserLoanApplyDetail userLoanApplyDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userLoanApplyDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationStatus = db.ApplicationStatus.ToList();
            ViewData["city"] = db.Citys.ToList();
            return View(userLoanApplyDetail);
        }

        // GET: Admin/UserLoanApplyDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLoanApplyDetail userLoanApplyDetail = db.UserLoanApplyDetail.Find(id);
            if (userLoanApplyDetail == null)
            {
                return HttpNotFound();
            }
            return View(userLoanApplyDetail);
        }

        // POST: Admin/UserLoanApplyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public void DeleteConfirmed(int id)
        {
            UserLoanApplyDetail userLoanApplyDetail = db.UserLoanApplyDetail.Find(id);
            db.UserLoanApplyDetail.Remove(userLoanApplyDetail);
            db.SaveChanges();
            //return RedirectToAction("Index");
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
