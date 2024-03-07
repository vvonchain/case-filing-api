using System.Xml.Serialization;

namespace EvictionCaseFilingAPI.Models
{
    [XmlRoot("Document")]
    public class Document
    {
        [XmlElement("DocumentID")]
        public string DocumentID { get; set; }

        [XmlElement("DocumentType")]
        public string DocumentType { get; set; }

        [XmlElement("DocumentData")]
        public byte[] DocumentData { get; set; }
    }
}