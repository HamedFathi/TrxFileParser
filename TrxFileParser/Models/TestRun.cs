using System.Xml.Serialization;

namespace TrxFileParser.Models
{
    [XmlRoot(ElementName = "TestRun", Namespace = "")]
    public class TestRun
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("runUser")]
        public string User { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("times")]
        public Times Times { get; set; }

        [XmlElement("results")]
        public Results Results { get; set; }

        [XmlElement("resultSummary")]
        public ResultSummary ResultSummary { get; set; }

        [XmlElement("testDefinitions")]
        public TestDefinitions TestDefinitions { get; set; }
    }
}
