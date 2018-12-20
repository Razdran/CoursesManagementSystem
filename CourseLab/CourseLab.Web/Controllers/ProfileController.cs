using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLab.Services.Services.Student;
using CourseLab.Services.Services.User;
using CourseLab.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace CourseLab.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly IStudentService studentService;
        public ProfileController(IUserService userservice, IStudentService studentService)
        {
            this.userService = userservice;
            this.studentService = studentService;
        }
        public IActionResult Index()
        {
            var studentlist = studentService.GetAll();
            var studentmodellist = new List<StudentRegisterModel>();
            foreach (var student in studentlist)
            {
                var studentmodel = (StudentRegisterModel)new StudentRegisterModel().InjectFrom(student);
                studentmodellist.Add(studentmodel);
            }
            return View(studentmodellist);
        }
    }
}