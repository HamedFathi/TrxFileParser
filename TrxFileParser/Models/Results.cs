using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrxFileParser.Models
{
    public class Results
    {
        [XmlElement("UnitTestResult")]
        public List<UnitTestResult> UnitTestResults { get; set; }
    }
}
