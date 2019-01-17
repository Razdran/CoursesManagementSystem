using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLab.Services.Services.Group;
using CourseLab.Services.Services.Objects;
using CourseLab.Services.Services.Professor;
using CourseLab.Services.Services.Student;
using CourseLab.Services.Services.User;
using CourseLab.Web.Models;
using Function.Services.Services.Schedule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace CourseLab.Web.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IUserService userService;
        private readonly IStudentService studentService;
        private readonly IProfessorService professorService;
        private readonly IGroupService groupService;
        private readonly IObjectService objectService;
        private readonly IScheduleService scheduleService;
        public ScheduleController(IUserService userservice, 
                                  IStudentService studentService, 
                                  IProfessorService professorService, 
                                  IGroupService groupService, 
                                  IObjectService objectService,
                                  IScheduleService scheduleService)
        {
            this.userService = userservice;
            this.studentService = studentService;
            this.professorService = professorService;
            this.groupService = groupService;
            this.objectService = objectService;
            this.scheduleService = scheduleService;
        }
        public IActionResult ProfessorSchedule()
        {
            var user = HttpContext.Session.GetString("Id");
            var id = Guid.Parse(user);
            var professor = professorService.GetByUserId(id);
            var fullname = professorService.GetFullName(professor.Id);
            var schedule = scheduleService.GetByProfessor(fullname);
            var modelSchedule = new List<ScheduleModel>();
            foreach(var item in schedule)
            {
                var sch = (ScheduleModel)new ScheduleModel().InjectFrom(item);
                modelSchedule.Add(sch);
            }
            return View(modelSchedule);
        }
        public IActionResult StudentSchedule()
        {
            var user = HttpContext.Session.GetString("Id");
            var id = Guid.Parse(user);
            var student = studentService.GetByUserId(id);
            var group = groupService.GetbyId(student.Group);
            var schedule = scheduleService.GetByGroupAndYear(group.Name,student.Year);
            var modelSchedule = new List<ScheduleModel>();
            foreach (var item in schedule)
            {
                var sch = (ScheduleModel)new ScheduleModel().InjectFrom(item);
                modelSchedule.Add(sch);
            }
            return View(modelSchedule);
        }
    }
}