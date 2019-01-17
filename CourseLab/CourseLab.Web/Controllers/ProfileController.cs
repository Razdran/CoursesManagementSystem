using System;
using System.Collections.Generic;
using CourseLab.Services.Services.Group;
using CourseLab.Services.Services.Objects;
using CourseLab.Services.Services.Professor;
using CourseLab.Services.Services.Student;
using CourseLab.Services.Services.User;
using CourseLab.Web.Models;
using Function.Services.Services.Subscription;
using Function.Services.Services.Subscription.Dto;
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
        private readonly ISubscriptionService subscriptionService;
        public ProfileController(IUserService userservice, 
                                 IStudentService studentService,
                                 IGroupService groupService,
                                 IProfessorService professorService,
                                 IObjectService objectService,
                                 ISubscriptionService subscriptionService)
        {
            this.userService = userservice;
            this.studentService = studentService;
            this.groupService = groupService;
            this.professorService = professorService;
            this.objectService = objectService;
            this.subscriptionService = subscriptionService;
        }
        public IActionResult StudentProfile()
        {
            var profile = new ProfileModel();
            var studentidstring = HttpContext.Session.GetString("Id");
            var studentid = Guid.Parse(studentidstring);
            var studentdto = studentService.GetByUserId(studentid);
            var group = groupService.GetbyId(studentdto.Group);
            var model = (StudentRegisterModel)new StudentRegisterModel().InjectFrom(studentdto);
            model.Group = group.Name;
            profile.Profile = model;

            var subscriptions = subscriptionService.GetSubscriptionsByUser(studentid);
            var list = new List<SubscriptionModel>();
            foreach(var item in subscriptions)
            {
                var sub = (SubscriptionModel)new SubscriptionModel().InjectFrom(item);
                sub.Professor = professorService.GetFullName(item.Professor);
                list.Add(sub);
            }
            profile.Subscriptions = list;
            return View(profile);
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
        [HttpGet]
        public IActionResult Create()
        {
            var list = professorService.GetAllFullName();
            var model = new SubCreateModel();
            model.Professors = list;
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(SubCreateModel model)
        {
            var dto = new SubscriptionDto();
            var user = HttpContext.Session.GetString("Id");
            var userid = Guid.Parse(user);
            var prof = professorService.GetByFullName(model.Name);
            dto.Id = Guid.NewGuid();
            dto.User = userid;
            dto.Professor = prof.Id;
            subscriptionService.CreateSubscription(dto);
            return RedirectToAction("StudentProfile","Profile");
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var model = new DeleteModel();
            model.Id = id;
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(DeleteModel model)
        {
            var x = subscriptionService.GetById(model.Id);
            subscriptionService.DeleteSubscription(x);
            return RedirectToAction("StudentProfile","Profile");
        }



    }
}