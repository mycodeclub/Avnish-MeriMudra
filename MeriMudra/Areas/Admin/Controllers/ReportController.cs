using MeriMudra.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeriMudra.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {
        private MmDbContext db = new MmDbContext();
        // GET: Admin/Report
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult userCreditCardApplyDetail()
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult prtUsercreditcardapplydetail(string fromdate, string todate)
        {
            DateTime fromDate;
            DateTime toDate;
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                fromdate = DateTime.Now.AddYears(-5).ToString();
                todate = DateTime.Now.ToString();
            }
            fromDate = Convert.ToDateTime(DateTime.ParseExact(fromdate, "MM/dd/yyyy", CultureInfo.InvariantCulture));
            toDate = Convert.ToDateTime(DateTime.ParseExact(todate, "MM/dd/yyyy", CultureInfo.InvariantCulture));
            var data = (from a in db.UserCCApplyDetail.ToList() where a.CreatedDate >= fromDate && a.CreatedDate <= Convert.ToDateTime(toDate) select a);
            return PartialView(data);
        }
        public ActionResult userLoanApplyDetail()
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult prtuserLoanApplyDetail(string fromdate, string todate)
        {
            DateTime fromDate;
            DateTime toDate;
            if (string.IsNullOrEmpty(fromdate) && string.IsNullOrEmpty(todate))
            {
                fromdate = DateTime.Now.AddYears(-5).ToString();
                todate = DateTime.Now.ToString();
            }
            fromDate = Convert.ToDateTime(DateTime.ParseExact(fromdate, "MM/dd/yyyy", CultureInfo.InvariantCulture));
            toDate = Convert.ToDateTime(DateTime.ParseExact(todate, "MM/dd/yyyy", CultureInfo.InvariantCulture));
            var data = (from a in db.UserLoanApplyDetail.ToList() where a.CreatedDate >= Convert.ToDateTime(fromDate) && a.CreatedDate <= Convert.ToDateTime(toDate) select a);
            return PartialView(data);
        }
        public ActionResult BusinessPartnerProgrammes()
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult prtBusinessPartnerProgrammes(string fromdate, string todate)
        {
            var data = (from a in db.BusinessPartnerProgrammes.ToList() where a.CreatedDate >= Convert.ToDateTime(fromdate) && a.CreatedDate <= Convert.ToDateTime(todate) select a);
            return PartialView(data);
        }

    }
}