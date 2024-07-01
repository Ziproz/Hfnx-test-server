using FnxTest.Models.Responses;
using FnxTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace FnxTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly BookmarkService _bookmarkService;

        public BookmarkController(BookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }

        [HttpPost("bookmark")]
        public IActionResult BookmarkRepository([FromBody] Repository repository)
        {
            _bookmarkService.AddBookmark(repository);
            return Ok();
        }

        [HttpGet("bookmarks")]
        public IActionResult GetBookmarks()
        {
            var bookmarks = _bookmarkService.GetBookmarks();
            return Ok(bookmarks);
        }
    }
}
