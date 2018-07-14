using MeriMudra.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            var model = new detailsForApplyCard { Banks = db.Banks.ToList(), CreditCards = db.CreditCards.ToList(), Citys = db.Citys.ToList() };
            return View(model);
        }
        [HttpPost]
        public int savestep(object convertedJSON,int isfinish=0)
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
                    accountWith = accountWith.Length > 4 ? accountWith.Substring(4,accountWith.Length-4) : "";
                    string CreditCardWith = string.Join(",", userdata.CreditCardWith);
                    CreditCardWith = CreditCardWith.Length > 4 ? CreditCardWith.Substring(4, CreditCardWith.Length-4) : "";
                    command.Parameters.AddWithValue("@AccountWith", accountWith);
                    command.Parameters.AddWithValue("@CreditCardWith", CreditCardWith);
                    command.Parameters.AddWithValue("@CreditCardMaxLimit", userdata.CreditCardMaxLimit);
                    command.Parameters.AddWithValue("@CurrentOrPrevLoan", userdata._CurrentOrPrevLoan);                   
                    command.Parameters.AddWithValue("@EmployerType", userdata.EmployerType);
                    if(isfinish==1)
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