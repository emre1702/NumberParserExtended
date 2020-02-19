using System.Xml.Serialization;

namespace NumberParserExtended.Model.XML
{
    #nullable disable warnings
    [XmlRoot("Mappings")]
    public class XMLMappingModel
    {
        [XmlElement("Number")]
        public XMLMappingNumberModel[] Numbers { get; set; }
    }
}
