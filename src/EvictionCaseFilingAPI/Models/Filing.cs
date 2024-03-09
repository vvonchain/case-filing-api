using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EvictionCaseFilingAPI.Models
{
    public class Filing
    {
        [Key]
        [JsonPropertyName("courtId")]
        public string CourtID { get; set; }

        [Required]
        [JsonPropertyName("caseNumber")]
        public string CaseNumber { get; set; }

        [Required]
        [JsonPropertyName("filingType")]
        public string FilingType { get; set; }
    }
}