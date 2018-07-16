using MeriMudra.Areas.Admin.Models;
using MeriMudra.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MeriMudra.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private MmDbContext db = new MmDbContext();
        // GET: Admin/Login  
        public ActionResult Login()
        {
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "LoginName,Password")] User login)
        {
            var users = db.UserLogin.ToList();
            var user = db.UserLogin.Where(l => l.LoginName == login.LoginName && l.Password == login.Password).FirstOrDefault();
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(login.LoginName, false);
                user.LastLogin = DateTime.Now;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Dashboard", "Home");
            }
            else { ModelState.AddModelError("Password", "Invalid User Name or Password"); }
            return View(login);
        }

        public ActionResult forgotpassword()
        {
            return View();
        }
    }
}