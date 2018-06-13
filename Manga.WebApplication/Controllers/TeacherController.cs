using Manga.WebApplication.Logic;
using Manga.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manga.WebApplication.Controllers
{
    public class TeacherController : BaseController
    {
        // GET: Teacher
        public ActionResult Index()
        {
            var teachers = GetAllTeachers();
            return View(teachers);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TeacherViewModel teacherModel)
        {
            if (ModelState.IsValid)
            {
                new ApiClient().PostData<TeacherViewModel>("university/AddTeacher", teacherModel);
            }
            else
            {
                return View(teacherModel);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var teacher = new ApiClient().GetData<TeacherViewModel>(String.Format("university/GetTeacher?id={0}", id));
            return View(teacher);
        }
        [HttpPost]
        public ActionResult Edit(TeacherViewModel teacher)
        {
            new ApiClient().PostData<TeacherViewModel>("University/SaveTeacher", teacher);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public  ActionResult Details(int id)
        {
            var teacher = new ApiClient().GetData<TeacherViewModel>(String.Format("university/GetTeacher?id={0}",id));
            return View(teacher);
        }
        public ActionResult Delete(int id)
        {
            new ApiClient().PostData<PostRemoveId>("university/RemoveTeacher", new PostRemoveId() { Id = id });
            return RedirectToAction("Index");
        }
    }
}