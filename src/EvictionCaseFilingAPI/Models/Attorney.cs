using System.Xml.Serialization;

namespace EvictionCaseFilingAPI.Models
{
    [XmlRoot("Attorney")]
    public class Attorney
    {
        [XmlElement("AttorneyID")]
        public string AttorneyID { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("BarNumber")]
        public string BarNumber { get; set; }
    }
}