using DiScopes.Services;
using Microsoft.AspNetCore.Mvc;


namespace DiScopes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScopeDemonstrationController : ControllerBase
    {
        private readonly IService _singletonService;
        private readonly IService _scopedService;
        private readonly IService _scopedService2; // Second scoped injection
        private readonly IService _transientService;
        private readonly IService _transientService2; // Second transient injection

        public ScopeDemonstrationController(
            [FromKeyedServices("singleton")] IService singletonService,
            [FromKeyedServices("scoped")] IService scopedService,
            [FromKeyedServices("scoped")] IService scopedService2, // Same key, should be same instance
            [FromKeyedServices("transient")] IService transientService,
            [FromKeyedServices("transient")] IService transientService2) // Same key, should be different instance
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _scopedService2 = scopedService2;
            _transientService = transientService;
            _transientService2 = transientService2;
        }

        [HttpGet("singleton", Name = "GetScopeSingletonDemonstration")]
        public IEnumerable<string> SingletonDemonstration()
        {
            var singletonResults = new List<string>();
            singletonResults.Add($@"Singleton Get Called - {Utility.Timestamp()}");
            singletonResults.Add(_singletonService.GetCreationTime());
            singletonResults.Add(_singletonService.GetTimestampAsync().Result);
            return singletonResults;
        }

        [HttpGet("scoped", Name = "GetScopeScopedDemonstration")]
        public IEnumerable<string> ScopedDemonstration()
        {
            var scopedResults = new List<string>();
            scopedResults.Add($@"Scoped Get Called - {Utility.Timestamp()}");
            scopedResults.Add($"First Injection: {_scopedService.GetCreationTime()}");
            scopedResults.Add($"Second Injection: {_scopedService2.GetCreationTime()}");
            scopedResults.Add($"Same Instance? {ReferenceEquals(_scopedService, _scopedService2)}");
            return scopedResults;
        }

        [HttpGet("transient", Name = "GetScopeTransientDemonstration")]
        public IEnumerable<string> TransientDemonstration()
        {
            var transientResults = new List<string>();
            transientResults.Add($@"Transient Get Called - {Utility.Timestamp()}");
            transientResults.Add($"First Injection: {_transientService.GetCreationTime()}");
            transientResults.Add($"Second Injection: {_transientService2.GetCreationTime()}");
            transientResults.Add($"Same Instance? {ReferenceEquals(_transientService, _transientService2)}");
            return transientResults;
        }
    }
}
