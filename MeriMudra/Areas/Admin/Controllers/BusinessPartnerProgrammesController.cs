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
    public class BusinessPartnerProgrammesController : Controller
    {
        private MmDbContext db = new MmDbContext();

        // GET: Admin/BusinessPartnerProgrammes
        public ActionResult Index()
        {
            return View(db.BusinessPartnerProgrammes.ToList());
        }

        // GET: Admin/BusinessPartnerProgrammes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessPartnerProgramme businessPartnerProgramme = db.BusinessPartnerProgrammes.Find(id);
            if (businessPartnerProgramme == null)
            {
                return HttpNotFound();
            }
            return View(businessPartnerProgramme);
        }

        // GET: Admin/BusinessPartnerProgrammes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BusinessPartnerProgrammes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,Mobile,Email,PAN,Aadhar,Company,City,CreatedDate")] BusinessPartnerProgramme businessPartnerProgramme)
        {
            if (ModelState.IsValid)
            {
                db.BusinessPartnerProgrammes.Add(businessPartnerProgramme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(businessPartnerProgramme);
        }

        // GET: Admin/BusinessPartnerProgrammes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessPartnerProgramme businessPartnerProgramme = db.BusinessPartnerProgrammes.Find(id);
            if (businessPartnerProgramme == null)
            {
                return HttpNotFound();
            }
            return View(businessPartnerProgramme);
        }

        // POST: Admin/BusinessPartnerProgrammes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Mobile,Email,PAN,Aadhar,Company,City,CreatedDate")] BusinessPartnerProgramme businessPartnerProgramme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessPartnerProgramme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(businessPartnerProgramme);
        }

        // GET: Admin/BusinessPartnerProgrammes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessPartnerProgramme businessPartnerProgramme = db.BusinessPartnerProgrammes.Find(id);
            if (businessPartnerProgramme == null)
            {
                return HttpNotFound();
            }
            return View(businessPartnerProgramme);
        }

        // POST: Admin/BusinessPartnerProgrammes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public void DeleteConfirmed(int id)
        {
            BusinessPartnerProgramme businessPartnerProgramme = db.BusinessPartnerProgrammes.Find(id);
            db.BusinessPartnerProgrammes.Remove(businessPartnerProgramme);
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
