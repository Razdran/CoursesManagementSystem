using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CourseLab.Web.Models;
using CourseLab.Services.Services.User;
using Microsoft.AspNetCore.Http;
using System;

namespace CourseLab.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService userService;
        public LoginController(IUserService userservice)
        {
            this.userService = userservice;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var x = HttpContext.Session.GetString("Id");
            if (HttpContext.Session.GetString("Id") != null)
            {
                var useridstring = HttpContext.Session.GetString("Id");
                var userid = Guid.Parse(useridstring);
                var user = userService.GetById(userid);
                HttpContext.Session.SetString("Id", user.Id.ToString());
                if (user.UserRole == 0)
                {
                    return RedirectToAction(nameof(ProfileController.StudentProfile), "Profile");
                }
                else
                {
                    return RedirectToAction(nameof(ProfileController.ProfessorProfile), "Profile");
                }
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Index(LoginModel model)
        {

            var user = userService.GetByUsernamePassword(model.Username, model.Password);
            if (user == null)
                return RedirectToAction("Index", "Login");
            else
            {
                HttpContext.Session.SetString("Id", user.Id.ToString());
            }
            if (user.UserRole == 0)
            {
                return RedirectToAction(nameof(ProfileController.StudentProfile), "Profile");
            }
            else
            {
                return RedirectToAction(nameof(ProfileController.ProfessorProfile), "Profile");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Id");
           
            return RedirectToAction(nameof(LoginController.Index), "Login");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
