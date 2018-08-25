using MeriMudra.Models;
using MeriMudra.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
                var sc = db.CcEligibilityCriterias.ToList();
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
        public ActionResult CreditCard(int id = 0)
        {
            ViewBag.id = id;
            //sendsms.run("9140764725", "run");
            var model = new detailsForApplyCard { Banks = db.Banks.ToList(), CreditCards = db.CreditCards.ToList(), Citys = db.Citys.ToList(), Companys = db.Companys.ToList() };
            return View(model);
        }
        [HttpPost]
        public int savestep(object convertedJSON, int isfinish = 0)
        {
            var a = (string[])convertedJSON;
            //string []a1 = (string[])convertedJSON;
            var userdata = new UserCCApplyDetail();
            foreach (var item in a)
            {
                userdata = JsonConvert.DeserializeObject<UserCCApplyDetail>(item);

            }
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MmDbConnectionString"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("SampleTransaction");
                command.Connection = connection;
                command.Transaction = transaction;
                try
                {
                    if (userdata.CurrentOrPrevLoan == "1")
                        userdata._CurrentOrPrevLoan = true;
                    else if (userdata.CurrentOrPrevLoan == "0")
                        userdata._CurrentOrPrevLoan = false;
                    command.Parameters.Clear();
                    command.CommandText = "Insert_UserCCApplyDetail";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", userdata.Id);
                    command.Parameters.AddWithValue("@CompanyName", userdata.CompanyName);
                    command.Parameters.AddWithValue("@GrossIncomeOrNetSalary", userdata.GrossIncomeOrNetSalary);
                    command.Parameters.AddWithValue("@Name", userdata.Name);
                    command.Parameters.AddWithValue("@DOB", userdata.DOB);
                    command.Parameters.AddWithValue("@CityId", userdata.CityId);
                    command.Parameters.AddWithValue("@CityName", userdata.CityName);
                    command.Parameters.AddWithValue("@PinCode", userdata.PinCode);
                    command.Parameters.AddWithValue("@MobileNumber", userdata.MobileNumber);
                    command.Parameters.AddWithValue("@OTP", userdata.OTP);
                    command.Parameters.AddWithValue("@email", userdata.email);
                    string accountWith = string.Join(",", userdata.AccountWith);
                    accountWith = accountWith.Length > 4 ? accountWith.Substring(4, accountWith.Length - 4) : "";
                    string CreditCardWith = string.Join(",", userdata.CreditCardWith);
                    CreditCardWith = CreditCardWith.Length > 4 ? CreditCardWith.Substring(4, CreditCardWith.Length - 4) : "";
                    command.Parameters.AddWithValue("@AccountWith", accountWith);
                    command.Parameters.AddWithValue("@CreditCardWith", CreditCardWith);
                    command.Parameters.AddWithValue("@CreditCardMaxLimit", userdata.CreditCardMaxLimit);
                    command.Parameters.AddWithValue("@CurrentOrPrevLoan", userdata._CurrentOrPrevLoan);
                    command.Parameters.AddWithValue("@EmployerType", userdata.EmployerType);
                    command.Parameters.AddWithValue("@CreditCardId", userdata.CreditCardId);
                    command.Parameters.AddWithValue("@PanCard", userdata.PanCard);
                    if (isfinish == 1)
                        command.Parameters.AddWithValue("@isUserActive", true);
                    else
                        command.Parameters.AddWithValue("@isUserActive", false);
                    var id = command.ExecuteScalar();
                    transaction.Commit();
                    connection.Close();
                    return Convert.ToInt32(id);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    connection.Close();
                }
            }
            System.Threading.Thread.Sleep(1000);
            return 0;
            // var d=  JsonConvert.DeserializeObject<detailsForApplyCard>(convertedJSON);
        }
    }
}