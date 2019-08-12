using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTwitterCloneApp.Models
{
    public class UserFollowing
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public int FollowingUser_ID { get; set; }

        public string DisplayName { get; set; }
    }
}