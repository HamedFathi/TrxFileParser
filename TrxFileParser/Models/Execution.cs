using System.Xml.Serialization;

namespace TrxFileParser.Models
{
    public class Execution
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
    }
}
