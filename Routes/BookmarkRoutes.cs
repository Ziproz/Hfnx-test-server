namespace FnxTest.Routes
{
    public static class BookmarkRoutes
    {
        public static void MapBookmark(this IEndpointRouteBuilder app)
        {
            var bookmarkGroup = app.MapGroup("api/bookmark/");
            bookmarkGroup.MapPost("save", async (HttpRequest request, IBookmarkService bookmarkService) =>
            {
                using var reader = new StreamReader(request.Body);
                var body = await reader.ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<BookmarkRequest>(body);

                if (data == null || string.IsNullOrEmpty(data.UserId) || data.Repository == null)
                {
                    return Results.BadRequest("Invalid data.");
                }
                await bookmarkService.SaveBookmarkAsync(data.UserId, data.Repository);
                return Results.Ok();
            })
           .RequireAuthorization();


            bookmarkGroup.MapGet("getBookmarks", async (string userId, IBookmarkService bookmarkService) =>
            {
                var bookmarks = await bookmarkService.GetBookmarksAsync(userId);
                return Results.Ok(bookmarks);
            })
            .RequireAuthorization();
        }
    }
}
