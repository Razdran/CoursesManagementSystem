using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CourseLab.Web.Models;
using CourseLab.Services.Services.User;

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
        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            var x = userService.GetByUsernamePassword(model.Username, model.Password);
            if (x == null)
                return RedirectToAction("Index","Login");
            
            return RedirectToAction(nameof(ProfileController.Index), "Profile");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
