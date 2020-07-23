using ReadLater.Entities;
using ReadLater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MVC.Controllers
{
    public class BookmarkWebApiController : ApiController
    {
        IBookmarkService _bookmarkService;
        public BookmarkWebApiController(IBookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }

        [HttpPost]
        [Route("api/[controller]")]      
        public async Task<List<Bookmark>> GetBookmarks()
        {
            var response = _bookmarkService.GetBookmarks("");
            return response;
        }
    }
}
