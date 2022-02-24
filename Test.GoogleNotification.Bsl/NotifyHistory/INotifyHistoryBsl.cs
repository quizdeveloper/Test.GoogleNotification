using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Test.GoogleNotification.Bsl.NotifyHistory
{
    public interface INotifyHistoryBsl
    {
        Task<bool> Create(Dal.Entities.NotifyHistory model);
    }
}
