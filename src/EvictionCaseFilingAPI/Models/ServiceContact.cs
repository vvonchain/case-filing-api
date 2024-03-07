using System.Xml.Serialization;

namespace EvictionCaseFilingAPI.Models
{
    [XmlRoot("ServiceContact")]
    public class ServiceContact
    {
        [XmlElement("ServiceContactID")]
        public string ServiceContactID { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Email")]
        public string Email { get; set; }
    }
}