using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.GoogleNotification.Dal.Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        public string IpAddress { get; set; }
        public string SubscribeToken { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
