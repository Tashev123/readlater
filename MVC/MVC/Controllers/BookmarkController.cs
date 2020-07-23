using Microsoft.AspNet.Identity;
using MVC.Models.Bookmark;
using ReadLater.Entities;
using ReadLater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class BookmarkController : Controller
    {
        IBookmarkService _bookmarkService;
        ICategoryService _categoryService;
        public BookmarkController(IBookmarkService bookmarkService, ICategoryService categoryService)
        {
            _bookmarkService = bookmarkService;
            _categoryService = categoryService;
        }
        // GET: Bookmark
        public ActionResult Index()
        {
            return View();
        }
     
        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                //Automapper missing or modelBinding like in category controller
                var model = new CreateEditBookmarkViewModel();
                var categories = _categoryService.GetCategories();
                model.Categories = categories.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.Name,
                                      Value = x.ID.ToString()
                                  }).ToList();

                return View(model);
            }
            catch (Exception)
            {

                throw;
            } 
        }
    
        [HttpPost]
        public ActionResult CreateConfirmed(CreateEditBookmarkViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Automapper missing
                    var bookmark = new Bookmark();
                    bookmark.CreatedBy = User.Identity.GetUserId();
                    bookmark.URL = model.URL;
                    bookmark.CategoryId = model.CategoryId;
                    bookmark.ShortDescription = model.ShortDescription;
                    _bookmarkService.CreateBookmark(bookmark);
                    return RedirectToAction("Bookmarks");
                }
                return View(model);
       
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult Bookmarks()
        {
            try
            {
                
                var bookmarks = _bookmarkService.GetBookmarks(string.Empty);
                //Automapper missing
                var model = new List<ListBookmarksViewModel>();
                foreach(var bookmrk in bookmarks)
                {
                    model.Add(new ListBookmarksViewModel()
                    {
                        Category = bookmrk.Category?.Name,
                        Id = bookmrk.ID,
                       ShortDescription = bookmrk.ShortDescription,
                       Url = bookmrk.URL
                    }); ;
                }
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult Edit(int bookmarkId)
        {
            try
            {
                //Automapper missing
                var bookmark = _bookmarkService.GetBookMarkById(bookmarkId);
                var model = new CreateEditBookmarkViewModel() { 
                    Id = bookmark.ID,
                    CategoryId = bookmark.CategoryId,
                    ShortDescription = bookmark.ShortDescription,
                    URL = bookmark.URL,
                    CreatedBy = bookmark.CreatedBy,
                    DateCreated = bookmark.CreateDate
                };
                var categories = _categoryService.GetCategories();
                model.Categories = categories.Select(x =>
                                new SelectListItem()
                                {
                                    Text = x.Name,
                                    Value = x.ID.ToString()
                                }).ToList();
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult EditConfirmed(CreateEditBookmarkViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Automapper missing
                    var bookmark = new Bookmark()
                    {
                        ID = model.Id,
                        CategoryId = model.CategoryId,
                        URL = model.URL,
                        ShortDescription = model.ShortDescription,
                        CreateDate = model.DateCreated,
                        CreatedBy = model.CreatedBy,
                        ObjectState = ObjectState.Modified
                    };
                    _bookmarkService.UpdateBookmark(bookmark);
                    return RedirectToAction("Bookmarks");
                }
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}