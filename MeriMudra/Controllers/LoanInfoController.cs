using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeriMudra.Controllers
{
    public class LoanInfoController : Controller
    {
        // GET: LoanInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Personal_Loan()
        {
            return View();
        }
        public ActionResult Home_Loan()
        {
            return View();
        }
        public ActionResult Business_Loan()
        {
            return View();
        }
        public ActionResult Car_Loan()
        {
            return View();
        }
        public ActionResult Loan_Against_Property()
        {
            return View();
        }
    }
}