using Manga.WebApplication.Logic;
using Manga.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manga.WebApplication.Controllers
{
    public class SubjectController : BaseController
    {
        // GET: Subject
        public ActionResult Index()
        {
            var subjects = new ApiClient().GetData<List<SubjectViewModel>>("University/GetSubjects");
            return View(subjects);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var subject = new SubjectViewModel()
            {
                TeachersSelectList = GetTeachersSelectList(GetAllTeachers())
            };
            return View(subject);
        }
        [HttpPost]
        public ActionResult Create(SubjectViewModel subject)
        {
            if (!ModelState.IsValid)
            {
                subject.TeachersSelectList = GetTeachersSelectList(GetAllTeachers());
                return View(subject);
            }
            new ApiClient().PostData<SubjectViewModel>("University/AddSubject", subject);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var subject = new ApiClient().GetData<SubjectViewModel>(String.Format("University/GetSubject?id={0}",id));
            subject.TeachersSelectList = GetTeachersSelectList(subject.Teachers as List<TeacherViewModel>);
            return View(subject);
        }
        [HttpPost]
        public ActionResult Edit(SubjectViewModel subject)
        {
            new ApiClient().PostData<SubjectViewModel>("University/UpdateSubject", subject);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var subject = new ApiClient().GetData<SubjectViewModel>(String.Format("University/GetSubject?id={0}", id));
            subject.TeachersSelectList = GetTeachersSelectList(subject.Teachers as List<TeacherViewModel>);
            return View(subject);
        }
        [HttpGet]
        public ActionResult Remove(int id)
        {
            new ApiClient().PostData<PostRemoveId>("University/RemoveSubject", new PostRemoveId() { Id = id });
            return RedirectToAction("Index");
        }

        private List<SelectListItem> GetTeachersSelectList(IList<TeacherViewModel> teachers)
        {
            List<SelectListItem> teacherSelectList = teachers.Select(
               x => new SelectListItem()
               {
                   Text = x.Name + " " + x.Lastname,
                   Value = x.Id.ToString(),
                   Selected = x.Selected
               }).ToList();
            return teacherSelectList;
        }
    }
}