using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EvictionCaseFilingAPI.Models
{
    public class Attorney
    {
        [Key]
        [JsonPropertyName("attorneyId")]
        public string AttorneyID { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("barNumber")]
        public string BarNumber { get; set; }
    }
}