﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeriMudra.Models.ViewModels;
using MeriMudra.Models;


namespace MeriMudra.Areas.Admin.Controllers
{
    public class CityGroupsController : Controller
    {
        private MmDbContext db = new MmDbContext();

        // GET: Admin/CityGroups
        public ActionResult Index()
        {
            return View(db.CityGroups.ToList());
        }

        // GET: Admin/CityGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cityGroup = new CityGroupViewModel(id.Value);
            if (cityGroup == null)
            {
                return HttpNotFound();
            }
            cityGroup.IncludedCitys.OrderBy(c => c.State.Name);
            return View(cityGroup);
        }

        // GET: Admin/CityGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CityGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,GroupName,CityIds")] CityGroup cityGroup)
        {
            if (ModelState.IsValid)
            {
                db.CityGroups.Add(cityGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cityGroup);
        }

        // GET: Admin/CityGroups/Edit/5
        public ActionResult Edit(int? id, int stateId = 32)
        {
            ViewBag.StateList = db.States.Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.StateId.ToString()
            }).ToList();
            ViewBag.CitiList = db.Citys.Where(c => c.StateId == stateId).ToList();
            return View(new CityGroupViewModel(id.Value));
        }

        // POST: Admin/CityGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,GroupName,CityIds")] CityGroup cityGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cityGroup);
        }

        // GET: Admin/CityGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityGroup cityGroup = db.CityGroups.Find(id);
            if (cityGroup == null)
            {
                return HttpNotFound();
            }
            return View(cityGroup);
        }

        // POST: Admin/CityGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CityGroup cityGroup = db.CityGroups.Find(id);
            db.CityGroups.Remove(cityGroup);
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


        /// <param name="id">  state Id</param>
        /// <returns></returns>
        public PartialViewResult GetCitiesByState(int stateId, string selctedCitysList = "")
        {
            ViewBag.selctedCitysList = selctedCitysList;
            return PartialView(db.Citys.Where(c => c.StateId == stateId).OrderBy(c => c.Name).ToList());
        }
    }
}
