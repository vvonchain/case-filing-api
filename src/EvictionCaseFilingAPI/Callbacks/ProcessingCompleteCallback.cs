using System.Threading.Tasks;

namespace EvictionCaseFilingAPI.Callbacks
{
    public class ProcessingCompleteCallback
    {
        public async Task NotifyProcessingComplete(string efmGuid, string cmsId)
        {
            // TODO: Implement logic to notify the EFM when processing is complete
            await Task.CompletedTask;
        }
    }
}