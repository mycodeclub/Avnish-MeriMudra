﻿using MeriMudra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeriMudra.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private MmDbContext db = new MmDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreditCard()
        {
            var model = new detailsForApplyCard { Banks = db.Banks.ToList(), CreditCards = db.CreditCards.ToList(),Citys=db.Citys.ToList() };
            return View(model);
        }
       
    }
}