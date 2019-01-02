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

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("UserName,Password")] User user,string returnUrl)
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
    }
}