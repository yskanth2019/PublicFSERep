using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTwitterCloneApp.Models;
using System.Data.Entity;
using System.Security.Cryptography;

namespace MyTwitterCloneApp.Controllers
{
    public class TCLoginController : Controller
    {
        private TCAppEntities db = new TCAppEntities();
        // GET: TCLogin
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register(User user)
        {
            return View();
        }
        public RedirectToRouteResult InsertUser(User user)
        {
            user.Password = Encryptor.MD5Hash(user.Password);
            user.Active = true;
            user.Joined = DateTime.Now;
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Home", "UserHome", user);
        }
        [HttpPost]
        public ActionResult MovetoHome(User user)
        {
            user.Password = Encryptor.MD5Hash(user.Password);
            var usr = db.Users.Where(x => x.DisplayName == user.DisplayName && x.Password == user.Password
            && x.Active==true).ToList();
            if (usr.Count > 0)
                return RedirectToAction("Home", "UserHome", usr[0]);
            else
                return RedirectToAction("Login", "TCLogin");
            
        }
    }
}