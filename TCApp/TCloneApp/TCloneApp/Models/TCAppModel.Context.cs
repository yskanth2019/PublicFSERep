﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyTwitterCloneApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TCAppEntities : DbContext
    {
        public TCAppEntities()
            : base("name=TCAppEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TweetDetail> TweetDetails { get; set; }
        public virtual DbSet<User_Following> User_Following { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual int DeleteTweet(Nullable<int> tweetID)
        {
            var tweetIDParameter = tweetID.HasValue ?
                new ObjectParameter("TweetID", tweetID) :
                new ObjectParameter("TweetID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteTweet", tweetIDParameter);
        }
    
        public virtual int EditTweet(Nullable<int> tweetID, string message)
        {
            var tweetIDParameter = tweetID.HasValue ?
                new ObjectParameter("TweetID", tweetID) :
                new ObjectParameter("TweetID", typeof(int));
    
            var messageParameter = message != null ?
                new ObjectParameter("Message", message) :
                new ObjectParameter("Message", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditTweet", tweetIDParameter, messageParameter);
        }
    
        public virtual ObjectResult<GetAllDetails_Result> GetAllDetails(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllDetails_Result>("GetAllDetails", idParameter);
        }
    
        public virtual ObjectResult<GetAllTweets_Result> GetAllTweets(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllTweets_Result>("GetAllTweets", idParameter);
        }
    
        public virtual ObjectResult<GetFollowersList_Result> GetFollowersList(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFollowersList_Result>("GetFollowersList", idParameter);
        }
    
        public virtual ObjectResult<GetFollowingList_Result> GetFollowingList(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFollowingList_Result>("GetFollowingList", idParameter);
        }
    
        public virtual int InsertTweet(Nullable<int> userID, string message)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var messageParameter = message != null ?
                new ObjectParameter("Message", message) :
                new ObjectParameter("Message", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertTweet", userIDParameter, messageParameter);
        }
    }
}
