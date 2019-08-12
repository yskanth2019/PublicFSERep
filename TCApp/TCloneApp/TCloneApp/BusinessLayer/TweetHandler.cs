using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTwitterCloneApp.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace MyTwitterCloneApp.BusinessLayer
{
    public class TweetHandler
    {
        public IEnumerable<UserTweets> GetAllTweets(int id)
        {
            IEnumerable<UserTweets> usrTweets = null;
            using (var ctx = new TCAppEntities())
            {
                var idParam = new SqlParameter("@id", id);
                var TweetDetails = ctx.Database.SqlQuery<UserTweets>(
                "exec GetAllTweets @id", idParam).ToList<UserTweets>();
                usrTweets = TweetDetails;
            }
            return usrTweets;
        }
        public void PostTweet(int id, string tweetMsg)
        {
            using (var ctx = new TCAppEntities())
            {
                var idParam = new SqlParameter("@UserID", id);
                var messageParam = new SqlParameter("@Message", tweetMsg);
                ctx.Database.SqlQuery<UserHomeModel>(
                 "exec InsertTweet @UserID,@Message", idParam, messageParam).ToList();
            }
        }
        public void UpdateTweet(int id, string tweetMsg)
        {
            using (var ctx = new TCAppEntities())
            {
                var idParam = new SqlParameter("@TweetID", id);
                var messageParam = new SqlParameter("@Message", tweetMsg);
                ctx.Database.SqlQuery<UserHomeModel>(
                 "exec EditTweet @TweetID,@Message", idParam, messageParam).ToList();
            }
        }
        public void DeleteTweet(int id)
        {
            using (var ctx = new TCAppEntities())
            {
                var idParam = new SqlParameter("@TweetID", id);
                ctx.Database.SqlQuery<UserHomeModel>(
                 "exec DeleteTweet @TweetID", idParam).ToList();
            }
        }
    }
}