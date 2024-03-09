using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EvictionCaseFilingAPI.Callbacks
{
    public class ProcessingCompleteCallback
    {
        private readonly HttpClient _httpClient;
        public ProcessingCompleteCallback(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task NotifyProcessingComplete(string efmGuid, string cmsId)
        {
            var callbackUrl = $"https://efm.example.com/api/notifications/{efmGuid}";
            var payload = new { Status = "Processing Complete", CmsId = cmsId };
            var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(callbackUrl, httpContent);
                if (!response.IsSuccessStatusCode)
                {
                    // Log or handle unsuccessful notification attempts
                    Console.WriteLine($"Failed to notify EFM for {efmGuid}. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Log or handle exceptions
                Console.WriteLine($"Exception occurred while notifying EFM for {efmGuid}: {ex.Message}");
            }
        }
    }
}