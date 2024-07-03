namespace FnxTest.Contracts
{
    public interface ILoginService
    {
        string Authenticate(string username, string password);
    }
}
