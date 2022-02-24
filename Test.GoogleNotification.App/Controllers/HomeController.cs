using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test.GoogleNotification.App.Models;
using Test.GoogleNotification.Bsl.Models;
using Test.GoogleNotification.Bsl.User;
using Test.GoogleNotification.Core;

namespace Test.GoogleNotification.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserBsl _userBsl;

        public HomeController(ILogger<HomeController> logger, IUserBsl userBsl)
        {
            _logger = logger;
            _userBsl = userBsl;
        }

        public async Task<IActionResult> Index()
        {
            string myIp = IPAddressHelper.GetClientIPAddress(HttpContext);
            myIp = myIp == "::1" ? "localhost" : myIp;
            var userObj = await _userBsl.GetByIP(myIp);
            if(userObj == null || userObj.UserId <= 0) {
                userObj = new UserModel();
                userObj.IpAddress = myIp;
            }
            return View(userObj);
        }

    }
}
