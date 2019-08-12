using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTwitterCloneApp.Models;
using MyTwitterCloneApp.BusinessLayer;
using System.Windows.Forms;

namespace MyTwitterCloneApp.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult SearchPage(UserSearch usrSearch)
        {
            return View(usrSearch);
        }
        public ActionResult Follow(UserSearch usrSrch)
        {
            try
            {
                UserHomeModel um = new UserHomeModel();
                UsersHandler usrHandlr = new UsersHandler();
                IEnumerable<UserFollowing> uf = null;
                uf = usrHandlr.GetFollowingList(usrSrch.sourceUsrID);
                foreach (var usrFollow in uf)
                {
                    if (usrFollow.FollowingUser_ID == usrSrch.ID)
                        throw new Exception("You are already following this user");
                }
                if (usrHandlr.FollowUser(usrSrch.sourceUsrID, usrSrch.ID))
                {
                    User usr = new User();
                    usr = usrHandlr.GetUserDetails(usrSrch.sourceUsrID);
                    return RedirectToAction("Home", "UserHome", usr);
                }
                return Redirect(Request.UrlReferrer.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        public ActionResult MoveToHome(UserSearch usrSearch)
        {
            UsersHandler usrHandlr = new UsersHandler();
            User usr = new User();
            usr = usrHandlr.GetUserDetails(usrSearch.sourceUsrID);
            return RedirectToAction("Home", "UserHome", usr);
        }
    }
}