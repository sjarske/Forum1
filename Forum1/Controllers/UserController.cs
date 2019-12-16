﻿using DAL.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Forum1.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(IFormCollection formCollection)
        {
            User user = new User
            {
                Username = formCollection["Username"],
                Password = formCollection["Password"],
                Email = formCollection["Email"]
            };

            _user.Register(user);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([Bind("Username, Password")] User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_user.Login(user))
            {
                var getUser = _user.GetUser(user);
                InitUser(getUser);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [Authorize]
        public IActionResult Logout()
        {
            LogOut();
            return RedirectToAction("Index", "Home");
        }

        private async void InitUser(User user)
        {
            var claims = new List<Claim>();

            var roles = _user.GetUserRoles(user);

            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            claims.Add(new Claim(ClaimTypes.Sid, user.Id.ToString()));

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
            var authProp = new AuthenticationProperties
            {
                IsPersistent = false
            };

            await this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProp);
        }

        private async void LogOut()
        {
            RemoveSessionData();
            await this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private void RemoveSessionData()
        {
            var keys = this.HttpContext.Session.Keys;

            for (int x = 0; x < keys.Count(); x++)
            {
                this.HttpContext.Session.Remove(keys.ElementAt(x));
            }
        }
    }
}