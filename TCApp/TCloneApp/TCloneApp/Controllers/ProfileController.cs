using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTwitterCloneApp.Models;
using System.Security.Cryptography;
using MyTwitterCloneApp.BusinessLayer;

namespace MyTwitterCloneApp.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult EditProfile(User usr)
        {
            usr.Password = string.Empty;
            return View(usr);
        }
        [HttpPost]
        public ActionResult ChangeUser(FormCollection frmCollection, string submitButton)
        {
            int ID = Convert.ToInt32(frmCollection["UsrID"]);
            User usr = new User();
            UsersHandler usrHandlr = new UsersHandler();
            usr = usrHandlr.GetUserDetails(ID);
            if (submitButton == "Save")
            {
                string pwd = frmCollection["pwdVal"];
                string email = frmCollection["Email"];
                if (!(string.IsNullOrEmpty(pwd)))
                    pwd = Encryptor.MD5Hash(pwd);
                if (!(string.IsNullOrEmpty(pwd)))
                    usr.Password = pwd;
                usr.Email = email;
                usrHandlr.UpdateUser(usr);
                return RedirectToAction("Home", "UserHome", usr);
            }
            else if(submitButton == "Exit from Application")
            {
                usrHandlr.RemoveUser(Convert.ToInt32(frmCollection["UsrID"]));
                return RedirectToAction("Login", "TCLogin");
            }
            return RedirectToAction("Home", "UserHome", usr);
        }
    }
}