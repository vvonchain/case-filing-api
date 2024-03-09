using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EvictionCaseFilingAPI.Services
{
    public interface IConfigurationService
    {
        Task<string> GetPolicyAsync(string courtId);
    }

    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GetPolicyAsync(string courtId)
        {
            // Implement logic to retrieve court-specific configuration
            var courtPolicyKey = $"CourtPolicies:{courtId}";
            var courtPolicy = _configuration[courtPolicyKey];
            if (string.IsNullOrEmpty(courtPolicy))
            {
                return await Task.FromResult("Court policy not found");
            }
            return await Task.FromResult($"Court policy for {courtId} retrieved successfully: {courtPolicy}");
        }
    }
}