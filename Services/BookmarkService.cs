using FnxTest.Models.Responses;
using Newtonsoft.Json;

namespace FnxTest.Services
{
    public class BookmarkService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _sessionKey = "BookmarkedRepositories";

        public BookmarkService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void AddBookmark(Repository repository)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var bookmarks = session.GetObjectFromJson<List<Repository>>(_sessionKey) ?? new List<Repository>();
            bookmarks.Add(repository);
            session.SetObjectAsJson(_sessionKey, bookmarks);
        }

        public List<Repository> GetBookmarks()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            return session.GetObjectFromJson<List<Repository>>(_sessionKey) ?? new List<Repository>();
        }
    }



    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }

}
