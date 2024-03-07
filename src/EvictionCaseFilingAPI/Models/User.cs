using System.Xml.Serialization;

namespace EvictionCaseFilingAPI.Models
{
    [XmlRoot("User")]
    public class User
    {
        [XmlElement("UserID")]
        public string UserID { get; set; }

        [XmlElement("Email")]
        public string Email { get; set; }
    }
}