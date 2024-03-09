using EvictionCaseFilingAPI.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EvictionCaseFilingAPI.Services
{
    public interface IPaymentService
    {
        Task<string> ProcessPaymentAsync(Payment payment);
    }

    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ProcessPaymentAsync(Payment payment)
        {
            var paymentRequestUrl = "https://paymentprocessor.example.com/api/payments";
            var paymentPayload = new
            {
                Amount = payment.Amount,
                Currency = payment.Currency,
                Source = payment.Source,
                Description = payment.Description
            };
            var httpContent = new StringContent(JsonConvert.SerializeObject(paymentPayload), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(paymentRequestUrl, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var paymentResponse = JsonConvert.DeserializeObject<PaymentResponse>(responseContent);
                    return $"Payment processed successfully. Transaction ID: {paymentResponse.TransactionId}";
                }
                else
                {
                    return $"Failed to process payment. Status code: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                return $"Exception occurred while processing payment: {ex.Message}";
            }
        }
    }

    public class PaymentResponse
    {
        public string TransactionId { get; set; }
    }
}