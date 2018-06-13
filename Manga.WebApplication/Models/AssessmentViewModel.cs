using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manga.WebApplication.Models
{
    public class AssessmentViewModel : AllSelectListClasses
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        [Required]
        [Display(Name = "Subject")]
        public int SubjectId { get; set; }
        [Required]
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
        [Required]
        [Display(Name = "Grade")]
        public int GradeId { get; set; }

        
    }
}