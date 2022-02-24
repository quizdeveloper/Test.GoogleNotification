using System;
using System.Collections.Generic;
using System.Text;

namespace Test.GoogleNotification.Bsl.Models
{
    public class UserModel
    {
        public UserModel() { }

        public UserModel(Dal.Entities.User model)
        {
            if (model == null) return;
            this.UserId = model.UserId;
            this.IpAddress = model.IpAddress;
            this.SubscribeToken = model.SubscribeToken;
            this.CreatedDate = model.CreatedDate;
        }

        public int UserId { get; set; }
        public string IpAddress { get; set; }
        public string SubscribeToken { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedDateFormat
        {
            get
            {
                if (!CreatedDate.HasValue) return "";
                return CreatedDate.Value.ToString("MMM dd yyyy");
            }
        }
    }
}
