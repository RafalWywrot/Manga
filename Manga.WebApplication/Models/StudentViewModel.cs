using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manga.WebApplication.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string City { get; set; }
        public string CodePostal { get; set; }
        [Required]
        [Display(Name = "Province")]
        public int ProvinceId { get; set; }
        public string Provincename { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }
        public string Gendername { get; set; }
        public string Address { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public IEnumerable<SelectListItem> Provinces { get; set; }
        public IEnumerable<SelectListItem> Genders { get; set; }
    }
}