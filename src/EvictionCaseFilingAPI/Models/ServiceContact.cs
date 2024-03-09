using System.ComponentModel.DataAnnotations;

namespace EvictionCaseFilingAPI.Models
{
    public class ServiceContact
    {
        [Key]
        public string ServiceContactID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}