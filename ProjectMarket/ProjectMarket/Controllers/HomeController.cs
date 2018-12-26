using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectMarket.Models;
using Microsoft.AspNetCore.Http.Extensions;

namespace ProjectMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProjectMarketContext _context;

        public HomeController(ProjectMarketContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(bool? failedToAuthenticate)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("UserName,Password")] User user)
        {
            var authenticatedUser = user.Login(_context);
            if (authenticatedUser == null)
            {
                // TODO send to login with failedToAuthenticate=true
            }
           
            // TODO save the user in session somehow
            return null;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
