using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;

namespace MVC.Models.Bookmark
{
    public class CreateEditBookmarkViewModel
    {
        public CreateEditBookmarkViewModel()
        {
            Categories = new List<SelectListItem>();
        }
        public int Id { get; set; }

        [StringLength(maximumLength: 500)]
        [Required(ErrorMessage = "The url is required")]
        public string URL { get; set; }
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        public int? CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
    }
}