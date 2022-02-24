using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.GoogleNotification.Bsl.NotifyHistory;
using Test.GoogleNotification.Bsl.User;
using Test.GoogleNotification.Core;
using Test.GoogleNotification.Dal.Entities;

namespace Test.GoogleNotification.App.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBsl _userBsl;
        private readonly INotifyHistoryBsl _notifyHistory;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserBsl userBsl, ILogger<UserController> logger, INotifyHistoryBsl notifyHistory)
        {
            _userBsl = userBsl;
            _logger = logger;
            _notifyHistory = notifyHistory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                int top = 1000;
                var lstUser = await _userBsl.Gets(top);
                return View(lstUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Dal.Entities.User model)
        {
            try
            {
                if (model == null) return Json(null);
                if (string.IsNullOrEmpty(model.SubscribeToken)) return Json(null);

                string myIp = IPAddressHelper.GetClientIPAddress(HttpContext);
                model.CreatedDate = DateTime.Now;
                model.IpAddress = myIp == "::1" ? "localhost" : myIp;
                await _userBsl.Create(model);
                return Json(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Json(null);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Push(string token, string message)
        {
            try
            {
                // 1. get user by token
                if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(message)) return Json(null);
                var userObj = await _userBsl.GetByToken(token);
                if (userObj == null) return Json(null);

                // 2. Push notify to user 
                string title = "Google Notifycation App";
                string[] tokens = new string[] { token };
                await PushNotificationHelper.SendPushNotification(tokens, title, message, null);

                // 3. Create Notify object
                var notifyHis = new NotifyHistory();
                notifyHis.PushDate = DateTime.Now;
                notifyHis.UserId = userObj.UserId;
                notifyHis.Status = true;

                // 4. Save notify history & return
                await _notifyHistory.Create(notifyHis);
                return Json(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return Json(null);
            }
        }

    }
}
