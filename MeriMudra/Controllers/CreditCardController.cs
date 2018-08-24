using MeriMudra.Models;
using MeriMudra.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        // Pass CreditCard Application Id
        public ActionResult AvilableCreditCardsAsPerApplication(int? id)
        {
            var avilableCreditCards = new List<CreditCard> { };
            var avilableCardids = new List<int> { };
            var avilableCityGroupId = new List<int> { };
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var userCcApplication = db.UserCCApplyDetail.Find(id);
            if (userCcApplication == null) return HttpNotFound();
            var cGrp = (from cg in db.CityGroups select new { cg.GroupId, cg.CityIds }).AsEnumerable().Select(item => new KeyValuePair<int, string>(item.GroupId, item.CityIds)).ToList();
            foreach (var item in cGrp)
            {
                if (item.Value.Split(',').Any(cid => cid.Equals(userCcApplication.CityId.ToString())))
                {
                    avilableCityGroupId.Add(item.Key);
                }
            }
            foreach (var cgId in avilableCityGroupId)
            {
                avilableCardids.AddRange(db.CcEligibilityCriterias.Where(ec => ec.CityGroupId == cgId).Select(ec => ec.CardId).ToList());
                var ecs = db.CcEligibilityCriterias.Where(ec => ec.CityGroupId == cgId).ToList();
                foreach (var ec in ecs)
                {
                    if (userCcApplication.EmployerType.Value)
                    {
                        if (userCcApplication.GrossIncomeOrNetSalary.Value >= ec.MinSalary)
                        {
                            userCcApplication.CreditCardId = ec.CardId;
                            db.SaveChanges(); break;
                        }
                    }
                    else
                    {
                        if (userCcApplication.GrossIncomeOrNetSalary.Value >= ec.MinItr)
                        {
                            userCcApplication.CreditCardId = ec.CardId;
                            db.SaveChanges(); break;
                        }
                    }
                }
            }
            avilableCardids = avilableCardids.Distinct().ToList();
            foreach (var cardId in avilableCardids) avilableCreditCards.Add(db.CreditCards.Find(cardId));
            ViewBag.userCcApplication = userCcApplication;
            return View(avilableCreditCards);
        }


        public int InterestedFor(int CcApplicationId, int Cardid)
        {
            var updateFlag = 0;
            var ccApplication = db.UserCCApplyDetail.Find(CcApplicationId);
            if (ccApplication != null)
            {
                ccApplication.CreditCardId = Cardid;
                db.Entry(ccApplication).State = System.Data.Entity.EntityState.Modified;
                updateFlag = db.SaveChanges();
            }
            return updateFlag;

        }
    }
}