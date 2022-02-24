using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.GoogleNotification.App.Controllers
{
    public class NotifyHistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
