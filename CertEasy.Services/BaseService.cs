using Microsoft.Extensions.Logging;

namespace CertEasy.Services
{
    public abstract class BaseService : IBaseService
    {
        protected readonly ILogger _logger;

        protected BaseService(ILogger logger)
        {
            _logger = logger;
        }
    }
}