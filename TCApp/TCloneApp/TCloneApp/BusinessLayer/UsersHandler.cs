using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTwitterCloneApp.Models;
using System.Data.Entity;
using System.Data.SqlClient;
namespace MyTwitterCloneApp.BusinessLayer
{
    public class UsersHandler
    {
        private TCAppEntities db = new TCAppEntities();
        public IEnumerable<UserFollowing> GetFollowersList(int ID)
        {
            IEnumerable<UserFollowing> usrFollowers = null;
            using (var ctx = new TCAppEntities())
            {
                var idParam = new SqlParameter("@id", ID);
                var FollowersList = ctx.Database.SqlQuery<UserFollowing>(
                 "exec GetFollowersList @id", idParam).ToList<UserFollowing>();
                usrFollowers = FollowersList;
            }
            return usrFollowers;
        }
        public IEnumerable<UserFollowing> GetFollowingList(int ID)
        {
            IEnumerable<UserFollowing> usrFollowing = null;
            using (var ctx = new TCAppEntities())
            {
                var idParam = new SqlParameter("@id", ID);
                var FollowingList = ctx.Database.SqlQuery<UserFollowing>(
                 "exec GetFollowingList @id", idParam).ToList<UserFollowing>();
                usrFollowing = FollowingList;
            }
            return usrFollowing;
        }
        public User GetUserDetails(int id)
        {
            List<User> users = new List<User>();
            foreach(var usr in db.Users)
            {
                User user = new User();
                user.ID = usr.ID;
                user.DisplayName = usr.DisplayName;
                user.Email = usr.Email;
                user.Password = usr.Password;
                users.Add(user);
            }
            return users.Find(x => x.ID == id);
        }
        public bool UpdateUser(User usr)
        {
            var selUsr = db.Users.Single(x => x.ID == usr.ID);
            if (selUsr != null)
            {
                selUsr.Password = usr.Password;
                selUsr.Email = usr.Email;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public bool FollowUser(int ID, int followUserID)
        {
            using (var ctx = new TCAppEntities())
            {
                var idParam = new SqlParameter("@ID", ID);
                var followUserIDParam = new SqlParameter("@FollowingUserID", followUserID);
                var FollowingList = ctx.Database.SqlQuery<UserFollowing>(
                 "exec InsertUserFollowing @ID,@FollowingUserID", idParam,followUserIDParam).ToList<UserFollowing>();
            }
            return true;
        }
        public UserSearch GetUserDetails(string srchString)
        {
            UserSearch usrSrch = new UserSearch();
            using (var ctx = new TCAppEntities())
            {
                var idParam = new SqlParameter("@displayName", srchString);
                var usr = ctx.Database.SqlQuery<UserSearch>(
                 "exec SearchUser @displayName", idParam).FirstOrDefault();
                if (usr!=null)
                {
                    usrSrch.DisplayName = usr.DisplayName;
                    usrSrch.Email = usr.Email;
                    usrSrch.FullName = usr.FullName;
                    usrSrch.ID = usr.ID;
                }
            }
            return usrSrch;
            
        }
        public bool RemoveUser(int usrID)
        {
            using (var ctx = new TCAppEntities())
            {
                var idParam = new SqlParameter("@UserID", usrID);
                var list = ctx.Database.SqlQuery<dynamic>("exec DeleteUser @UserID", idParam).ToList();
            }
            return true;
        }
    }
}