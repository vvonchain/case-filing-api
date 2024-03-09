using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EvictionCaseFilingAPI.Models
{
    public class CasePartyAttorney
    {
        [Key]
        [JsonPropertyName("casePartyAttorneyId")]
        public string CasePartyAttorneyId { get; set; }

        [Required]
        [JsonPropertyName("casePartyId")]
        public string CasePartyID { get; set; }

        [Required]
        [JsonPropertyName("attorneyId")]
        public string AttorneyID { get; set; }
    }
}