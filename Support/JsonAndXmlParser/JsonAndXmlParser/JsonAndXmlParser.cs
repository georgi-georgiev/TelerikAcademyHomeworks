using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace JsonAndXmlParser
{
    /// <summary>
    /// JsonAndXml Parser Methods
    /// </summary>
    public static class JsonAndXmlParser
    {
        /// <summary>
        /// Convert an XML node contained in string xml into a JSON string
        /// </summary>
        /// <param name="xml">Path to xml as string</param>
        /// <returns>Json string</returns>
        public static string JsonToXml(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string json = JsonConvert.SerializeXmlNode(doc);

            return json;
        }

        /// <summary>
        /// Convert JSON text contained in string json into an XML node
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>XmlDocument</returns>
        public static XmlDocument XmlToJson(string json)
        {
            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(json);
            
            return doc;
        }
    }
}
