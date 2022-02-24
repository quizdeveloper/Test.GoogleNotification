using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.GoogleNotification.Dal.Entities
{
    public partial class NotifyHistory
    {
        public int NotifyHistoryId { get; set; }
        public int? UserId { get; set; }
        public DateTime? PushDate { get; set; }
        public bool? Status { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
    }
}
