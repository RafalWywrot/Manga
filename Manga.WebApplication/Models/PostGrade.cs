using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manga.WebApplication.Models
{
    public class PostGrade : AllSelectListClasses
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public int GradeId { get; set; }
    }
}