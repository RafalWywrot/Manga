using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manga.WebApplication.Models
{
    public class AllSelectListClasses
    {
        public IEnumerable<SelectListItem> StudentsSelectList { get; set; }
        public IEnumerable<SelectListItem> SubjectsSelectList { get; set; }
        public IEnumerable<SelectListItem> TeachersSelectList { get; set; }
        public IEnumerable<SelectListItem> GradesSelectList { get; set; }
    }
}