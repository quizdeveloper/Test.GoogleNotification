using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.GoogleNotification.Dal.Entities;

namespace Test.GoogleNotification.Dal.NotifyHistory
{
    public class NotifyHistoryDal : INotifyHistoryDal
    {
        private GoogleNotificationContext _db;
        public NotifyHistoryDal(GoogleNotificationContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Entities.NotifyHistory model)
        {
            if (model == null) return false;
            if (model.UserId <= 0) return false;
            if (!model.PushDate.HasValue) model.PushDate = DateTime.Now;
            if (!model.Status.HasValue) model.Status = false;

            await _db.AddAsync(model);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
