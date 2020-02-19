using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using NumberParserExtended.Common.Interfaces;
using NumberParserExtended.Model.XML;

namespace NumberParserExtended.Common.Helper
{
    public class XMLMappingGetter : IMappingGetter
    {
        private static readonly XmlSerializer _xmlSerializer = new XmlSerializer(typeof(XMLMappingModel));

        private readonly IUserInformer _userInformer;

        public XMLMappingGetter(IUserInformer userInformer)
        {
            _userInformer = userInformer;
        }

        public List<(int, string[])>? GetMappings(object? info)
        {
            // That should never happen
            if (info is null || !(info is string path))
            {
                _userInformer.ShowError("Unknwon error in GetMappings.");
                return null;
            }
                
            // Serialize the xml file to an object
            using var xmlReader = XmlReader.Create(File.OpenRead(path));
            if (!_xmlSerializer.CanDeserialize(xmlReader))
            {
                _userInformer.ShowError("The mapping file is not in the correct format and could not be read.");
                return null;
            }

            var model = (XMLMappingModel)_xmlSerializer.Deserialize(xmlReader);
            
            var list = new List<(int, string[])>();
            foreach (var numberMapping in model.Numbers)
            {
                list.Add((numberMapping.Value, numberMapping.Lines));
            }

            return list;
        }
    }
}
