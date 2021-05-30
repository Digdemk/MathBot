using MathBot.Models.ORM.Context;
using MathBot.Models.ORM.Entities;
using MathBot.Models.VM;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MathBot.Controllers
{
    public class UserController : Controller
    {
        private readonly MathBotContext _mathBotContext;

        public UserController(MathBotContext mathBotContext)
        {
            _mathBotContext = mathBotContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                User user = _mathBotContext.Users.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
                if (user != null) 
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.UserName)
                    };

                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);

                    ViewBag.User = model.UserName;
                    //_mathBotContext.SaveChanges();

                    //return RedirectToAction("Index", "Home");
                    return Redirect("~/Home");

                }
                else
                {
                    ViewBag.error = "The Username or Password is Incorrect";
                    return View();
                }


            }

            else
            {
                ViewBag.error = "The Username or Password is Incorrect";

                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignupVM model)
        {
            if (ModelState.IsValid)
            {
                User user = new User();

                user.Name = model.Name;
                user.Surname = model.Surname;
                user.UserName = model.UserName;
                user.BirthDate = model.Birthdate;
                user.Password = user.Password;

                _mathBotContext.Users.Add(user);
                _mathBotContext.SaveChanges();
            }

            else
            {
                return View();
            }

            return RedirectToAction("Login", "User");
        }
    }
}
