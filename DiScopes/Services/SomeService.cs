namespace DiScopes.Services
{
    public class SomeService : IService
    {
        private string _creationTime;

        public SomeService()
        {
            Thread.Sleep(2000);
            _creationTime = $"Service has been created at {Utility.Timestamp()}";
        }
        public async Task<string> GetTimestampAsync()
        {
            await Task.Delay(2); // Simulating async work
            return $"Task Completed {Utility.Timestamp()}";
        }

        public string GetCreationTime()
        {
            return _creationTime;
        }
    }
}
