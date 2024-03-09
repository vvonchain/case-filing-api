using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EvictionCaseFilingAPI.Models
{
    public class CaseParty
    {
        [Key]
        [JsonPropertyName("casePartyId")]
        public string CasePartyID { get; set; }

        [Required]
        [JsonPropertyName("partyType")]
        public string PartyType { get; set; }
    }
}