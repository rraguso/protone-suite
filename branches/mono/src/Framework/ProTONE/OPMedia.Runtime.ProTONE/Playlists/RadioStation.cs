using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using OPMedia.Core;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using OPMedia.Core.Utilities;

namespace OPMedia.Runtime.ProTONE.Playlists
{
    [DataContract]
    public class RadioStation
    {
        [DataMember(Order = 0)]
        public string Url { get; set; }

        [DataMember(Order = 1)]
        public string Title { get; set; }

        [DataMember(Order = 2)]
        public string Genre { get; set; }
    }

    [DataContract]
    public class RadioStationsData
    {
        [DataMember(Order = 0)]
        public List<RadioStation> RadioStations { get; set; }

        public RadioStationsData()
        {
            RadioStations = new List<RadioStation>();
        }

        public static RadioStationsData Load()
        {
            string xml = PersistenceProxy.ReadObject("RadioStationsData", string.Empty);
            if (!string.IsNullOrEmpty(xml))
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                using (StringReader sr = new StringReader(xml))
                using (XmlReader xr = XmlReader.Create(sr))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(RadioStationsData));
                    return xs.Deserialize(xr) as RadioStationsData;
                }
            }

            return null;
        }

        public void SavePersistentList()
        {
            StringBuilder xml = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.NewLineHandling = NewLineHandling.Entitize;
            settings.OmitXmlDeclaration = true;
            settings.NewLineChars = "\r\n";
            settings.Indent = true;
            settings.IndentChars = " ";
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.CloseOutput = true;
            settings.NamespaceHandling = NamespaceHandling.OmitDuplicates;

            using (XmlWriter xw = XmlWriter.Create(xml, settings))
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                XmlSerializer xs = new XmlSerializer(typeof(RadioStationsData));
                xs.Serialize(xw, this, ns);
            }

            PersistenceProxy.SaveObject("RadioStationsData", xml.ToValidXml());
        }

    }
}
