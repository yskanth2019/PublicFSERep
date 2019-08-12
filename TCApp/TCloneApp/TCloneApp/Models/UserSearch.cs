using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTwitterCloneApp.Models
{
    public class UserSearch
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public System.DateTime Joined { get; set; }
        public bool Active { get; set; }
        public string usrSearch { get; set; }
        public int sourceUsrID { get; set; }
    }
}