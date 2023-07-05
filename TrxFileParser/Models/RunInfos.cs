using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrxFileParser.Models
{
    public class RunInfos
    {
        [XmlElement("RunInfo")]
        public List<RunInfo> Infos { get; set; }
    }
}