using System;
using CourseLab.Services.Services.Student;
using CourseLab.Services.Services.Student.Dto;
using CourseLab.Services.Services.User;
using CourseLab.Services.Services.User.Dto;
using CourseLab.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace CourseLab.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService userService;
        private readonly IStudentService studentService;
        public RegisterController(IUserService userservice,IStudentService studentService)
        {
            this.userService = userservice;
            this.studentService = studentService;
        }
        [HttpGet]
        public IActionResult StudentRegister()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StudentRegister(StudentRegisterModel model)
        {
            var user = (UserDto)new UserDto().InjectFrom(model);
            user.Id = Guid.NewGuid();
            user.UserRole = Data.UserManagement.RoleEnum.Student;
            user.IsDeleted = false;
            var student = (StudentDto)new StudentDto().InjectFrom(model);
            student.Id = Guid.NewGuid();
            student.UserId = user.Id;
            student.IsDeleted = false;
            userService.CreateUser(user);
            studentService.CreateStudent(student);
            return RedirectToAction("Index", "Login");
        }
        public IActionResult ProfessorRegister()
        {
            return View();
        }
    }
}