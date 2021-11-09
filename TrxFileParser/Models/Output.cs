using System.Xml.Serialization;

namespace TrxFileParser.Models
{
    public class Output
    {
        [XmlElement("StdOut")]
        public string StdOut { get; set; }

        [XmlElement("StdErr")]
        public string StdErr { get; set; }
    }
}
