
namespace FnxTest.Services
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IConnectionMultiplexer _redis;

        public BookmarkService(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public async Task SaveBookmarkAsync(string userId, Repository repository)
        {
            var db = _redis.GetDatabase();
            string serializedRepository = System.Text.Json.JsonSerializer.Serialize(repository);
            await db.ListRightPushAsync(userId, serializedRepository);
        }

        public async Task<List<Repository>> GetBookmarksAsync(string userId)
        {
            var db = _redis.GetDatabase();
            var serializedRepositories = await db.ListRangeAsync(userId);

            var repositories = serializedRepositories
                .Select(repo => System.Text.Json.JsonSerializer.Deserialize<Repository>(repo))
                .ToList();

            return repositories;
        }

    }
}
