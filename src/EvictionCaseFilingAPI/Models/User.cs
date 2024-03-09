using System.ComponentModel.DataAnnotations;

namespace EvictionCaseFilingAPI.Models
{
    public class User
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}