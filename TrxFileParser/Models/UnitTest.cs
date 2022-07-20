using System.Xml.Serialization;

namespace TrxFileParser.Models
{
    public class UnitTest
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("storage")]
        public string Storage { get; set; }

        [XmlElement("execution")]
        public Execution Execution { get; set; }

        [XmlElement("testMethod")]
        public TestMethod TestMethod { get; set; }
    }
}
