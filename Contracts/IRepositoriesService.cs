namespace FnxTest.Contracts
{
    public interface IRepositoriesService
    {
        Task<List<Repository>> GetRepositories(string query);
    }
}
