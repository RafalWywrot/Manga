using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manga.WebApplication.Models
{
    public class SubjectViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IList<TeacherViewModel> Teachers { get; set; }
        public IList<SelectListItem> TeachersSelectList { get; set; }
        [Required(ErrorMessage = "You must choose min 1 teacher")]
        [Display(Name = "Assigned Teachers")]
        public List<int> SelectedTeachers { get; set; }
    }
}