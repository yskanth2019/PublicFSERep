using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTwitterCloneApp.Models
{
    public class UserHomeModel
    {
        public User user;
        public IEnumerable<UserTweets> tweetDetails;
        public IEnumerable<UserFollowing> FollowingList;
        public IEnumerable<UserFollowing> FollowersList;
        public string tweetMessage { get; set; }
    }
}