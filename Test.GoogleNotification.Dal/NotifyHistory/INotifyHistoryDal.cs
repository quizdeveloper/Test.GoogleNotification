using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Test.GoogleNotification.Dal.NotifyHistory
{
    public interface INotifyHistoryDal
    {
        Task<bool> Create(Dal.Entities.NotifyHistory model);
    }
}
