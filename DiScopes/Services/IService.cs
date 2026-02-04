namespace DiScopes.Services
{
    public interface IService
    {
        Task<string> GetTimestampAsync();
        string GetCreationTime();
    }
}
