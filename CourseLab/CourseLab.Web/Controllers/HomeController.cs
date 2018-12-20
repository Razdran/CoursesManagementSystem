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
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        public HomeController(IUserService userservice)
        {
            this.userService = userservice;
        }
        public IActionResult Index()
        {
            //var userlist = userService.GetAll();
            //var usermodellist = new List<UserModel>();
            //foreach(var user in userlist)
            //{
            //    var usermodel = (UserModel)new UserModel().InjectFrom(user);
            //    usermodellist.Add(usermodel);
            //}
            //return View(usermodellist);
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserModel model)
        {
            var user = new UserDto();
            user.InjectFrom(model);
            user.Id = Guid.NewGuid();
            userService.CreateUser(user);
            return RedirectToAction("Index","Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
