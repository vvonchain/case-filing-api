using EvictionCaseFilingAPI.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EvictionCaseFilingAPI.Services
{
    public interface IEFilingService
    {
        Task<string> SubmitFilingAsync(Envelope envelope);
        Task<string> UploadDocumentAsync(Document document);
    }

    public class EFilingService : IEFilingService
    {
        private readonly HttpClient _httpClient;

        public EFilingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> SubmitFilingAsync(Envelope envelope)
        {
            var filingSubmissionUrl = "https://efilingportal.example.com/api/filings";
            var filingPayload = new
            {
                CaseNumber = envelope.CaseNumber,
                FilingType = envelope.FilingType,
                Documents = envelope.Documents
            };
            var httpContent = new StringContent(JsonConvert.SerializeObject(filingPayload), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(filingSubmissionUrl, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    return "Filing submitted successfully";
                }
                else
                {
                    return $"Failed to submit filing. Status code: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                return $"Exception occurred while submitting filing: {ex.Message}";
            }
        }

        public async Task<string> UploadDocumentAsync(Document document)
        {
            var documentUploadUrl = "https://efilingportal.example.com/api/documents";
            var documentPayload = new
            {
                Name = document.Name,
                Type = document.Type,
                Content = Convert.ToBase64String(document.Content)
            };
            var httpContent = new StringContent(JsonConvert.SerializeObject(documentPayload), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(documentUploadUrl, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    return "Document uploaded successfully";
                }
                else
                {
                    return $"Failed to upload document. Status code: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                return $"Exception occurred while uploading document: {ex.Message}";
            }
        }
    }
}