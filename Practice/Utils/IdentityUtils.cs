using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Practice.Models;
using System.Security.Claims;

namespace Practice.Utils
{
    public static class IdentityUtils
    {
        public static void addingClaimIdentity(LogInModel user,HttpContext httpContext)
        {
            //List of Claims
            var userClaims = new List<Claim>()
                {
                    new Claim("Username",user.UserName),
                    new Claim(ClaimTypes.Email,user.UserName),

                    
                    new Claim(ClaimTypes.Role,"admin")
                };

            //Create a identity claims
            var claimsIdentity = new ClaimsIdentity(
                userClaims, CookieAuthenticationDefaults.AuthenticationScheme);


            //httpcontext, current user is authentic user
            // Sign in user to httpcontext

            httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity)
                );
        }
    }
}
