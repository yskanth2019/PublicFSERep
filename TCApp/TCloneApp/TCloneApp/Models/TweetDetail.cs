//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class TweetDetail
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public string Message { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
    
        public virtual User User { get; set; }
    }
}
