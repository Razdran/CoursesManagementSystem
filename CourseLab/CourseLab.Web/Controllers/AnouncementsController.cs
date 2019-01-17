using CourseLab.Services.Services.Group;
using CourseLab.Services.Services.Objects;
using CourseLab.Services.Services.Professor;
using CourseLab.Services.Services.Student;
using CourseLab.Services.Services.User;
using CourseLab.Web.Models;
using Function.Services.Services.Anouncement;
using Function.Services.Services.Anouncement.Dto;
using Function.Services.Services.Subscription;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseLab.Web.Controllers
{
    public class AnouncementsController : Controller
    {
        private readonly IUserService userService;
        private readonly IStudentService studentService;
        private readonly IProfessorService professorService;
        private readonly IGroupService groupService;
        private readonly IObjectService objectService;
        private readonly IAnouncementService anouncementService;
        private readonly ISubscriptionService subscriptionService;

        public AnouncementsController(IUserService userservice,
                                 IStudentService studentService,
                                 IGroupService groupService,
                                 IProfessorService professorService,
                                 IObjectService objectService,
                                 IAnouncementService anouncementService,
                                 ISubscriptionService subscriptionService)
        {
            this.userService = userservice;
            this.studentService = studentService;
            this.groupService = groupService;
            this.professorService = professorService;
            this.objectService = objectService;
            this.anouncementService = anouncementService;
            this.subscriptionService = subscriptionService;
        }
        public IActionResult StudentAnouncements()
        {
            var user = userService.GetById(Guid.Parse(HttpContext.Session.GetString("Id")));
            var subs = subscriptionService.GetSubscriptionsByUser(user.Id);
            var list = new List<string>(); 
            foreach(var item in subs)
            {
                var fullname = professorService.GetFullName(item.Professor);
                list.Add(fullname);
            }
            var unAnn = anouncementService.GetAnouncementsByProfessors(list);
            var ann = unAnn.OrderBy(x => x.CreationDate).ToList();
            var modellist = new List<AnouncementModel>();
            foreach(var item in ann)
            {
                var model = (AnouncementModel)new AnouncementModel().InjectFrom(item);
                modellist.Add(model);
            }
            return View(modellist);
        }
        public IActionResult ProfessorAnouncements()
        {
            var id = HttpContext.Session.GetString("Id");
            var prof = professorService.GetByUserId(Guid.Parse(id));
            var fullname = professorService.GetFullName(prof.Id);
            var anouncemens = anouncementService.GetAnouncementsByFullName(fullname);
            var model = new List<AnouncementModel>();
            foreach(var item in anouncemens)
            {
                var ann = (AnouncementModel)new AnouncementModel().InjectFrom(item);
                model.Add(ann);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateAnnModel model)
        {
            var prof = professorService.GetByUserId(Guid.Parse(HttpContext.Session.GetString("Id")));
            var entity = new AnouncementDto();
            entity.Id = Guid.NewGuid();
            entity.Professor = professorService.GetFullName(prof.Id);
            entity.CreationDate = DateTime.Now;
            entity.AnouncementText = model.text;
            anouncementService.Create(entity);
            return RedirectToAction("ProfessorAnouncements", "Anouncements");
        }
    }
}