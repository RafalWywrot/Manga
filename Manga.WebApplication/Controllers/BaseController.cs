using Manga.WebApplication.Logic;
using Manga.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manga.WebApplication.Controllers
{
    public class BaseController : Controller
    {
        protected IEnumerable<SelectListItem> AddEmptyElement(IEnumerable<SelectListItem> items)
        {
            var emptyElement = new[] { new SelectListItem() { Text = "Choose", Value = "" } };
            var result = emptyElement.Concat(items);
            return result;
        }
        protected List<TeacherViewModel> GetAllTeachers()
        {
            var teachers = new ApiClient().GetData<List<TeacherViewModel>>("university/getTeachers");
            return teachers;
        }
        protected IEnumerable<SelectListItem> GetSelectListStudents(IList<StudentViewModel> students)
        {
            var studentsSelectList = students.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return AddEmptyElement(studentsSelectList);
        }
        protected IEnumerable<SelectListItem> GetSelectListSubjects(IList<SubjectViewModel> subjects)
        {
            var subjectsSelectList = subjects.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return AddEmptyElement(subjectsSelectList);
        }
        protected IEnumerable<SelectListItem> GetSelectListTeachers(IList<TeacherViewModel> teachers)
        {
            var teachersSelectList = teachers.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return AddEmptyElement(teachersSelectList);
        }
        protected IEnumerable<SelectListItem> GetSelectListGrades(IList<GradeViewModel> grades)
        {
            var gradesSelectList = grades.Select(x => new SelectListItem()
            {
                Text = x.value.ToString(),
                Value = x.Id.ToString()
            });
            return AddEmptyElement(gradesSelectList);
        }

    }
}