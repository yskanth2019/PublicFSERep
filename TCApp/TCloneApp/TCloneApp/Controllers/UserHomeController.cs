using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTwitterCloneApp.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using MyTwitterCloneApp.BusinessLayer;
using System.Windows.Forms;

namespace MyTwitterCloneApp.Controllers
{
    public class UserHomeController : Controller
    {
        // GET: UserHome
        public ActionResult Home(User user)
        {
            UserHomeModel um = new UserHomeModel();
            um.user = user;
            TweetHandler twtHandlr = new TweetHandler();
            um.tweetDetails = twtHandlr.GetAllTweets(user.ID);
            UsersHandler usrHandlr = new UsersHandler();
            um.FollowersList = usrHandlr.GetFollowersList(user.ID);
            um.FollowingList = usrHandlr.GetFollowingList(user.ID);
            return View(um);
        }
        [HttpPost]
        public ActionResult UserHomeOperations(System.Web.Mvc.FormCollection frmCollection, string submitButton)
        {
            try
            {
                int ID = 0;
                string tweetMsg;
                string errmsg = "";
                TweetHandler twtHandlr = new TweetHandler();
                if (submitButton == "share")
                {
                    ID = Convert.ToInt32(frmCollection["UsrID"]);
                    tweetMsg = frmCollection["msgTweet"];
                    if (ID != 0)
                        twtHandlr.PostTweet(ID, tweetMsg);
                    else
                        errmsg = "Could not read user properly";

                }
                else if (submitButton.Contains("Save"))
                {
                    ID = Convert.ToInt32(frmCollection["TweetID"].Split(',')[0]);
                    tweetMsg = frmCollection["msgEdtTweet"];
                    if (ID != 0)
                        twtHandlr.UpdateTweet(ID, tweetMsg);
                    else
                        errmsg = "Could not read tweet properly";
                }
                else if (submitButton == "Delete")
                {
                    ID = Convert.ToInt32(frmCollection["TweetID"].Split(',')[0]);
                    if (ID != 0)
                        twtHandlr.DeleteTweet(ID);
                    else
                        errmsg = "Could not read tweet properly";
                }
                else if (submitButton == "Cancel")
                    Redirect(Request.UrlReferrer.ToString());
                else if (submitButton == "Search")
                {
                    if (string.IsNullOrEmpty(frmCollection["txtSearch"]))
                        throw new Exception("Search criteria cannot by empty");
                    else
                    {
                        UserSearch srchUser = new UserSearch();
                        UsersHandler usrHandlr = new UsersHandler();
                        srchUser = usrHandlr.GetUserDetails(frmCollection["txtSearch"]);
                        if (srchUser != null)
                        {
                            srchUser.sourceUsrID = Convert.ToInt32(frmCollection["UsrID"]);
                            //SearchPage(srchUser);
                            return RedirectToAction("SearchPage", "Search", srchUser);
                        }
                    }
                }
                return Redirect(Request.UrlReferrer.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        public ActionResult FollowingPage(int ID)
        {
            UserHomeModel um = new UserHomeModel();
            UsersHandler usrHandlr = new UsersHandler();
            um.user = usrHandlr.GetUserDetails(ID);
            um.FollowersList = usrHandlr.GetFollowersList(ID);
            um.FollowingList = usrHandlr.GetFollowingList(ID);
            return View(um);
        }
        public ActionResult FollowerPage(int ID)
        {
            UserHomeModel um = new UserHomeModel();
            UsersHandler usrHandlr = new UsersHandler();
            um.user = usrHandlr.GetUserDetails(ID);
            um.FollowersList = usrHandlr.GetFollowersList(ID);
            um.FollowingList = usrHandlr.GetFollowingList(ID);
            return View(um);
        }
        public ActionResult SearchPage(UserSearch usrSrch)
        {
            return RedirectToAction("SearchPage","Search", usrSrch);
        }
    }
}