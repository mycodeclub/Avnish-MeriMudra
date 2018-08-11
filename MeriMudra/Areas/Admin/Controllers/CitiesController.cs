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
    public class CitiesController : Controller
    {
        private MmDbContext db = new MmDbContext();


        public ActionResult Index(int id = 32)
        {
            List<SelectListItem> states = new List<SelectListItem>();
            foreach (var state in db.States.ToList())
            {
                states.Add(new SelectListItem
                {
                    Text = state.Name,
                    Value = state.StateId.ToString()

                });
                if (state.StateId == id)
                    states.Last().Selected = true;
            }
            ViewBag.StateList = states;
            var citys = db.Citys.Where(c => c.StateId == id).OrderBy(c => c.Name).ToList();
            return View(citys);
        }
        // GET: Admin/Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Citys.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: Admin/Cities/Create
        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(db.States, "StateId", "Name");
            return View();
        }

        // POST: Admin/Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StateId")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Citys.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateId = new SelectList(db.States, "StateId", "Name", city.StateId);
            return View(city);
        }

        // GET: Admin/Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Citys.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateId = new SelectList(db.States, "StateId", "Name", city.StateId);
            return View(city);
        }

        // POST: Admin/Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StateId")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateId = new SelectList(db.States, "StateId", "Name", city.StateId);
            return View(city);
        }

        // GET: Admin/Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Citys.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Admin/Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public void DeleteConfirmed(int id)
        {
            City city = db.Citys.Find(id);
            db.Citys.Remove(city);
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
