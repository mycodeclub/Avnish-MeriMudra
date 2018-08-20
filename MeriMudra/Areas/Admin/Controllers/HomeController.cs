using MeriMudra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeriMudra.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private MmDbContext db = new MmDbContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            var data = db.UserCCApplyDetail.ToList();
            ViewData["loan_data"] = db.UserLoanApplyDetail.ToList();
            return View(data);
        }
    }
}