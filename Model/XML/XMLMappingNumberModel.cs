using System;
using System.Xml.Serialization;

namespace NumberParserExtended.Model.XML
{
    #nullable disable warnings
    public class XMLMappingNumberModel
    {
        [XmlAttribute("Value")]
        public int Value { get; set; }

        [XmlElement("Str")]
        public string[] Lines { get; set; }
    }
}
