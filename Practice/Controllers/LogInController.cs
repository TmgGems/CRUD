﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practice.Data;
using Practice.DI;
using Practice.Models;
using Practice.Utils;
using System.Drawing.Text;
using System.Security.Claims;

namespace Practice.Controllers
{
    [AllowAnonymous]
    public class LogInController : Controller
    {
        //private readonly ApplicationDbContext _context;
        //public LogInController(ApplicationDbContext context) 
        //{ 
        //    _context = context;
        //}

        IUserService _userService;

        public LogInController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult LogIn(LogInModel modeldata)
        {
            if (ModelState.IsValid)
            {
                bool user = _userService.validateLogin(modeldata.UserName, modeldata.Password);
                if (user)
                {
                    IdentityUtils.addingClaimIdentity(modeldata, HttpContext);
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid UserName or Password");

                }

            }
            {
                return View("Index");
            }
        }

        
       
        public IActionResult LogOut()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpmodel modeldata)
        {
            if (ModelState.IsValid)
            {
                UserModel uModel = new UserModel()
                {
                    UserName = modeldata.UserName,
                    Password = modeldata.Password
                };

                bool result = _userService.RegisterUser(uModel);
                if (result)
                {
                    RedirectToAction("Index");
                }
                return View();
            }
            return View();
        }
    }
}
