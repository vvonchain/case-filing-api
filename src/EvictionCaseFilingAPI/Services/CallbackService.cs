using System.Threading.Tasks;
using Serilog;

namespace EvictionCaseFilingAPI.Services
{
    public class CallbackService
    {
        private readonly ILogger _logger;

        public CallbackService(ILogger logger)
        {
            _logger = logger.ForContext<CallbackService>();
        }

        public async Task NotifyProcessingComplete(string efmGuid, string cmsId)
        {
            _logger.Information("Notifying EFM that processing is complete for EFM GUID: {EfmGuid}, CMS ID: {CmsId}", efmGuid, cmsId);
            // Implement the logic to notify EFM when processing is complete
        }
    }
}