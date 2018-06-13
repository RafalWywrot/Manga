using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manga.WebApplication.Models
{
    public class AssessmentClassesModel
    {
        public List<StudentViewModel> Students { get; set; }
        public List<SubjectViewModel> Subjects { get; set; }
        public List<TeacherViewModel> Teachers { get; set; }
        public List<GradeViewModel> Grades { get; set; }
    }
}