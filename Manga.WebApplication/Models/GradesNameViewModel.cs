using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manga.WebApplication.Models
{
    public class GradesNameViewModel
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
        public double Grade { get; set; }
    }
}