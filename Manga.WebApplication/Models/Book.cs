using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manga.WebApplication.Models
{
    public class Book
    {
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}