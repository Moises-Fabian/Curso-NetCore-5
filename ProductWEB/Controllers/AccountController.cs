﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWEB.Models;
using ProductWEB.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductWEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly Util<User> util;
        public AccountController(IHttpClientFactory httpClientFactory)
        {
            util = new Util<User>(httpClientFactory);
        }
        public IActionResult Login()
        {
            return View(new User());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Login (User user)
        {
            if (ModelState.IsValid)
            {
                var modelStateError = await util.LoginAsync(Resource.LoginAPIUrl, user);
                if (modelStateError.Response.Errors.Count > 0)
                {
                    foreach (var item in modelStateError.Response.Errors)
                    {
                        user.Errors.Add(item);
                    }
                    return View(user);
                }

                if (modelStateError.Token == null) return View(user);

                HttpContext.Session.SetString("Token", modelStateError.Token);
                HttpContext.Session.SetString("UserName", modelStateError.UserName);
                return RedirectToAction("Index", "Home");

            }
            return View(user);
        }
    }
}