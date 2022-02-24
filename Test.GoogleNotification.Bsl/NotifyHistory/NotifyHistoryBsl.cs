using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.GoogleNotification.Dal.NotifyHistory;

namespace Test.GoogleNotification.Bsl.NotifyHistory
{
    public class NotifyHistoryBsl : INotifyHistoryBsl
    {
        private readonly INotifyHistoryDal _notifyHistoryDal;

        public NotifyHistoryBsl(INotifyHistoryDal notifyHistoryDal)
        {
            _notifyHistoryDal = notifyHistoryDal;
        }

        public async Task<bool> Create(Dal.Entities.NotifyHistory model)
        {
            return await _notifyHistoryDal.Create(model);
        }
    }
}
