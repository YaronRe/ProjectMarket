using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ProjectMarket.Services;

using Microsoft.AspNetCore.Mvc;
using ProjectMarket.Models;
using Microsoft.AspNetCore.Http.Extensions;

namespace ProjectMarket.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ProjectMarketContext _context;
        private IUserService _userService;
        
        
        public void UsersController(IUserService userService)
        {
            _userService = userService;
        }

        
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

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]User userParam)
        {
            var user = await _userService.Authenticate(userParam.UserName, userParam.Password);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            
            return Ok(user);
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
