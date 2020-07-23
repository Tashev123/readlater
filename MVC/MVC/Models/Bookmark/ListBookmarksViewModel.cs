using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.Bookmark
{
    public class ListBookmarksViewModel
    {
        public ListBookmarksViewModel()
        {

        }
        public int Id { get; set; }
        public string Url { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        public string Category { get; set; }
    }
}