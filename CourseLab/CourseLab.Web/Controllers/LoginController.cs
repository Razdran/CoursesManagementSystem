using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseLab.Web.Models;
using CourseLab.Services.Services.User;
using Omu.ValueInjecter;
using CourseLab.Services.Services.User.Dto;

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
            return View();
        }
        [HttpPut]
        public IActionResult Index(LoginModel model)
        {
            var x = userService.GetByUsernamePassword(model.Username, model.Password);
            if (x == null)
                return NotFound();
            return RedirectToAction("Index", "Home");
        }
        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
