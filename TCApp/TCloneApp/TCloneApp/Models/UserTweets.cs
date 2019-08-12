using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTwitterCloneApp.Models
{
    public class UserTweets
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        
    }
}