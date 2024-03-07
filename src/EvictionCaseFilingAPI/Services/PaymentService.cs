using EvictionCaseFilingAPI.Models;
using System.Threading.Tasks;

namespace EvictionCaseFilingAPI.Services
{
    public interface IPaymentService
    {
        Task<string> ProcessPaymentAsync(Payment payment);
    }

    public class PaymentService : IPaymentService
    {
        public async Task<string> ProcessPaymentAsync(Payment payment)
        {
            // TODO: Implement payment processing logic
            return await Task.FromResult("Payment processed successfully");
        }
    }
}