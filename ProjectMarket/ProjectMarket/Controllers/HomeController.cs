using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectMarket.Models;
using Microsoft.AspNetCore.Http.Extensions;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

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
        public async Task<IActionResult> Login([Bind("UserName,Password")] User user)
        {
            try
            {
                
                var authenticatedUser = user.Login(_context);
                if (authenticatedUser == null)
                {
                    // TODO send to login with failedToAuthenticate=true
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }

                #region snippet1
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, authenticatedUser.UserName),
                    new Claim(ClaimTypes.Email,authenticatedUser.EMail)
                };

                if (authenticatedUser.IsAdmin)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
                }
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. Required when setting the 
                    // ExpireTimeSpan option of CookieAuthenticationOptions 
                    // set with AddCookie. Also required when setting 
                    // ExpiresUtc.

                    IssuedUtc = DateTimeOffset.Now,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                #endregion
                return RedirectToAction("Index","Home");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Internal error at login.");
                //log failure
            }

            // Something failed. Redisplay the form.
            return View();
        }

        public async Task<IActionResult> Logoff()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
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
