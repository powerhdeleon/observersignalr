using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObserverSignalr.Controllers
{
    public class SubscriptionController : Controller
    {
        public static List<int> account = new List<int>();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Followers(string room)
        {
            return View("Followers",room);
        }
    }
}
