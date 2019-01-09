using System;
using CourseLab.Services.Services.Group;
using CourseLab.Services.Services.Objects;
using CourseLab.Services.Services.Professor;
using CourseLab.Services.Services.Professor.Dtos;
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
        private readonly IProfessorService professorService;
        private readonly IGroupService groupService;
        private readonly IObjectService objectService;
        public RegisterController(IUserService userservice, IStudentService studentService, IProfessorService professorService, IGroupService groupService, IObjectService objectService)
        {
            this.userService = userservice;
            this.studentService = studentService;
            this.professorService = professorService;
            this.groupService = groupService;
            this.objectService = objectService;
        }
        [HttpGet]
        public IActionResult StudentRegister()
        {
            var groups = groupService.GetAll();
            var model = new StudentRegisterModel();
            model.Groups = groups;
            return View(model);
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
            student.Group = groupService.GetbyName(model.Group).Id;
            student.UserId = user.Id;
            student.IsDeleted = false;
            userService.CreateUser(user);
            studentService.CreateStudent(student);
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public IActionResult ProfessorRegister()
        {
            var objects = objectService.GetAll();
            var model = new ProfessorRegisterModel();
            model.Objects = objects;
            return View(model);
        }
        [HttpPost]
        public IActionResult ProfessorRegister(ProfessorRegisterModel model)
        {
            var user = (UserDto)new UserDto().InjectFrom(model);
            user.Id = Guid.NewGuid();
            user.UserRole = Data.UserManagement.RoleEnum.Professor;
            user.IsDeleted = false;
            var professor = (ProfessorDto)new ProfessorDto().InjectFrom(model);
            professor.Id = Guid.NewGuid();
            professor.Object = objectService.GetbyName(model.Object).Id;
            professor.UserId = user.Id;
            professor.IsDeleted = false;
            userService.CreateUser(user);
            professorService.CreateProfessor(professor);
            return RedirectToAction("Index", "Login");
        }

        public JsonResult CheckUsernameAvailability(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = userService.GetByUsername(userdata);
            if (SeachData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }


        }
    }
}