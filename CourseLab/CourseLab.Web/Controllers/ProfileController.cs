using System;
using CourseLab.Services.Services.Group;
using CourseLab.Services.Services.Objects;
using CourseLab.Services.Services.Professor;
using CourseLab.Services.Services.Student;
using CourseLab.Services.Services.User;
using CourseLab.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace CourseLab.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly IStudentService studentService;
        private readonly IProfessorService professorService;
        private readonly IGroupService groupService;
        private readonly IObjectService objectService;
        public ProfileController(IUserService userservice, IStudentService studentService,IGroupService groupService,IProfessorService professorService,IObjectService objectService)
        {
            this.userService = userservice;
            this.studentService = studentService;
            this.groupService = groupService;
            this.professorService = professorService;
            this.objectService = objectService;
        }
        public IActionResult StudentProfile()
        {
            var studentidstring = HttpContext.Session.GetString("Id");
            var studentid = Guid.Parse(studentidstring);
            var studentdto = studentService.GetByUserId(studentid);
            var group = groupService.GetbyId(studentdto.Group);
            var model = (StudentRegisterModel)new StudentRegisterModel().InjectFrom(studentdto);
            model.Group = group.Name;
            return View(model);
        }
        public IActionResult ProfessorProfile()
        {
            var profidstring = HttpContext.Session.GetString("Id");
            var profid = Guid.Parse(profidstring);
            var profdto = professorService.GetByUserId(profid);
            HttpContext.Session.SetString("Id", profdto.UserId.ToString());
            var obj = objectService.GetbyId(profdto.Object);
            var model = (ProfessorRegisterModel)new ProfessorRegisterModel().InjectFrom(profdto);
            model.Object = obj.Name;
            return View(model);
        }

    }
}