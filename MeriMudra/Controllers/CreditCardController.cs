using MeriMudra.Models;
using MeriMudra.Models.CreditCardViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeriMudra.Controllers
{
    public class CreditCardController : Controller
    {
        private MmDbContext db = new MmDbContext();
        // GET: CreditCard
        public ActionResult Index()
        {

            return View(db.CreditCards.ToList());
        }

        public ActionResult CardDetail(int id = 1)
        {
            var ccViewModel = new CreditCardViewModel(id);
            return View(ccViewModel);
        }
    }
}