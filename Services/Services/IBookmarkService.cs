using System.Collections.Generic;
using ReadLater.Entities;

namespace ReadLater.Services
{
    public interface IBookmarkService
    {
        Bookmark CreateBookmark(Bookmark bookmark);
        List<Bookmark> GetBookmarks(string category);
        Bookmark GetBookMarkById(int id);
        Bookmark UpdateBookmark(Bookmark bookmark);
    }
}