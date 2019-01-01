using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMarket
{
    public class ClaimsExtension
    {
        public const string UserId = "UserId";
        public const string Admin = "Administrator";

        public static int GetUserId(HttpContext httpContext)
        {
            try
            {
                return int.Parse(httpContext.User.Claims.First(x => x.Type == ClaimsExtension.UserId).Value);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static bool IsAdmin(HttpContext httpContext)
        {
            return httpContext.User.IsInRole(Admin);
        }

    }
}
