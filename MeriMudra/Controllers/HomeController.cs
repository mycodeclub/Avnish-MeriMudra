using MeriMudra.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

    }
}