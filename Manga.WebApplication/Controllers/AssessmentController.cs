using Manga.WebApplication.Logic;
using Manga.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manga.WebApplication.Controllers
{
    public class AssessmentController : BaseController
    {
        // GET: Grades
        public ActionResult Index()
        {
            var grades = new ApiClient().GetData<List<GradesNameViewModel>>("university/GetAllGrades");
            return View(grades);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var assessementModel = new ApiClient().GetData<AssessmentClassesModel>("university/GetDataForCreateGrade");
            var assessement = new AssessmentViewModel()
            {
                StudentsSelectList = GetSelectListStudents(assessementModel.Students),
                SubjectsSelectList = GetSelectListSubjects(assessementModel.Subjects),
                TeachersSelectList = GetSelectListTeachers(assessementModel.Teachers),
                GradesSelectList = GetSelectListGrades(assessementModel.Grades)
            };
            return View(assessement);
        }
        [HttpPost]
        public ActionResult Create(AssessmentViewModel assModel)
        {
            if (!ModelState.IsValid)
            {
                var assessementModel = new ApiClient().GetData<AssessmentClassesModel>("university/GetDataForCreateGrade");
                var assessement = new AssessmentViewModel()
                {
                    StudentsSelectList = GetSelectListStudents(assessementModel.Students),
                    SubjectsSelectList = GetSelectListSubjects(assessementModel.Subjects),
                    TeachersSelectList = GetSelectListTeachers(assessementModel.Teachers),
                    GradesSelectList = GetSelectListGrades(assessementModel.Grades)
                };
                return View(assessement);
            }
            var postGrade = new PostGrade()
            {
                Id = assModel.Id,
                StudentId = assModel.StudentId,
                SubjectId = assModel.SubjectId,
                TeacherId = assModel.TeacherId,
                GradeId = assModel.GradeId
            };
            new ApiClient().PostData<PostGrade>("university/CreateGradeForStudent", postGrade);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //var grade = CreateAssessmenetViewModel("university/GetAssessment");
            var PostGrade = new ApiClient().GetData<PostGrade>(String.Format("university/GetAssessment?id={0}", id));
            var assessementModel = CreateAssessmenetViewModel();
            PostGrade.StudentsSelectList = GetSelectListStudents(assessementModel.Students);
            PostGrade.SubjectsSelectList = GetSelectListSubjects(assessementModel.Subjects);
            PostGrade.TeachersSelectList = GetSelectListTeachers(assessementModel.Teachers);
            PostGrade.GradesSelectList = GetSelectListGrades(assessementModel.Grades);
            return View(PostGrade);
        }
        public ActionResult Delete(int id)
        {
            new ApiClient().PostData<PostRemoveId>("university/DeleteGradeAssessment", new PostRemoveId() { Id = id });
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(PostGrade postGrade)
        {
            if (!ModelState.IsValid)
            {
                var assessementModel = CreateAssessmenetViewModel();
                postGrade.StudentsSelectList = GetSelectListStudents(assessementModel.Students);
                postGrade.SubjectsSelectList = GetSelectListSubjects(assessementModel.Subjects);
                postGrade.TeachersSelectList = GetSelectListTeachers(assessementModel.Teachers);
                postGrade.GradesSelectList = GetSelectListGrades(assessementModel.Grades);
                return View(postGrade);
            }
            new ApiClient().PostData<PostGrade>("university/UpdateGrades", postGrade);
            return RedirectToAction("Index");
        }
        private AssessmentClassesModel CreateAssessmenetViewModel()
        {
            var assessementModel = new ApiClient().GetData<AssessmentClassesModel>("university/GetDataForCreateGrade");
            return assessementModel;
        }
        //void CreateSelectList(AssessmentViewModel model, AssessmentClassesModel assessementModel)
        //{
        //    model.StudentsSelectList = GetSelectListStudents(assessementModel.Students);
        //    model.SubjectsSelectList = GetSelectListSubjects(assessementModel.Subjects);
        //    model.TeachersSelectList = GetSelectListTeachers(assessementModel.Teachers);
        //    model.GradesSelectList = GetSelectListGrades(assessementModel.Grades);
        //}

    }
}