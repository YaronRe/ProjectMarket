using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMarket.Models;
using ProjectMarket.ViewModels;

namespace ProjectMarket.Controllers
{
    public class AccountController : Controller
    {
        private readonly ProjectMarketContext _context;

        public AccountController(ProjectMarketContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Logoff()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        private User Login(AuthenticationDetails details)
        {
            var matchingUsers = _context.User.Where(user => user.UserName == details.UserName && user.Password == details.Password).ToArray();
            if (matchingUsers.Length == 1)
            {
                return matchingUsers[0];
            }
            return null;
        }

        private User Register(RegistrationDetails details)
        {

            return new User(){
                UserName = details.UserName,
                Password = details.Password,
                FirstName = details.FirstName,
                LastName =details.LastName,
                EMail = details.EMail,
                IsAdmin = false
            };
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("UserName,Password,IsPersistent")] AuthenticationDetails authDetails,string returnUrl)
        {
            try
            {
                var authenticatedUser = Login(authDetails);
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
                    new Claim(ClaimTypes.Email,authenticatedUser.EMail),
                    new Claim(ClaimsExtension.UserId, authenticatedUser.Id.ToString())
                };

                if (authenticatedUser.IsAdmin)
                {
                    claims.Add(new Claim(ClaimTypes.Role, ClaimsExtension.Admin));
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

                    IsPersistent = authDetails.IsPersistent,
                    // Whether the authentication session is persisted across 
                    // multiple requests. Required when setting the 
                    // ExpireTimeSpan option of CookieAuthenticationOptions 
                    // set with AddCookie. Also required when setting 
                    ExpiresUtc= DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(10.0)),

                    IssuedUtc = DateTimeOffset.UtcNow,
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
                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Internal error at login.");
                //log failure
            }

            // Something failed. Redisplay the form.
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Password,EMail,FirstName,LastName")] RegistrationDetails regDetails, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = Register(regDetails);
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                }
                return View("Login");
            }
            catch
            {
                return View("Login");
            }
        }
        public IActionResult Login(bool? failedToAuthenticate,string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == ClaimsExtension.GetUserId(HttpContext));
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
    }
}