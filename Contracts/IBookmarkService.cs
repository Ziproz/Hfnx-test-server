namespace FnxTest.Contracts
{
    public interface IBookmarkService
    {
        Task SaveBookmarkAsync(string userId, Repository repositoryData);
        Task<List<Repository>> GetBookmarksAsync(string userId);
    }
}
