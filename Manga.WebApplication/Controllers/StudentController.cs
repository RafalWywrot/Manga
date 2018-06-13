using Manga.WebApplication.Logic;
using Manga.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manga.WebApplication.Controllers
{
    public class StudentController : BaseController
    {
        // GET: Student
        public ActionResult Index()
        {
            var students = new ApiClient().GetData<List<StudentViewModel>>("University/GetStudents");
            return View(students);
        }
        public ActionResult Add()
        {
            var vm = new StudentViewModel()
            {
                Provinces = GetProvinces(),
                Genders = GetGenders()
            };
            return View(vm);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = new ApiClient().GetData<StudentViewModel>(String.Format("University/GetStudent?id={0}", id));
            student.Genders = GetGenders();
            student.Provinces = GetProvinces();
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                student.Genders = GetGenders();
                student.Provinces = GetProvinces();
                return View(student);
            }
            new ApiClient().PostData<StudentViewModel>("university/SaveStudent", student);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var student = new ApiClient().GetData<StudentViewModel>(String.Format("University/GetStudent?id={0}", id));
            return View(student);
        }
        public ActionResult Remove(int id)
        {
            var student = new ApiClient().PostData<PostRemoveId>("University/RemoveStudent",new PostRemoveId() { Id = id });
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Add(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = new ApiClient().PostData<StudentViewModel>("university/AddStudent", model);
                return RedirectToAction("Index");
            }
            var vm = new StudentViewModel()
            {
                Provinces = GetProvinces(),
                Genders = GetGenders()
            };
            return View(vm);
        }
        private IEnumerable<SelectListItem> GetProvinces()
        {
            var provincesList = new ApiClient().GetData<List<ProvincesViewModel>>("University/GetProvinces");
            var provinces = provincesList.Select(province => new SelectListItem()
            {
                Value = province.Id.ToString(),
                Text = province.Name
            });
            return AddEmptyElement(provinces);
        }
        private IEnumerable<SelectListItem> GetGenders()
        {
            var gendersList = new ApiClient().GetData<List<GendersViewModel>>("University/GetGenders");
            var genders = gendersList.Select(province => new SelectListItem()
            {
                Value = province.Id.ToString(),
                Text = province.Name
            });
            return AddEmptyElement(genders);
        }
    }
}