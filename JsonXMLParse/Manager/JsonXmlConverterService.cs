using JsonXMLParse.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JsonXMLParse.Manager
{
    public class JsonXmlConverterService : IJsonXmlConverterService
    {
        public string DataTableToJson(DataTable dataTable)
        {
            return JsonConvert.SerializeObject(dataTable);
        }

        public string DataTableToXml(DataTable dataTable)
        {
            using (StringWriter writer = new StringWriter())
            {
                dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                return writer.ToString();
            }
        }

        public string JsonToXml(string jsonData)
        {
            XmlDocument doc = JsonConvert.DeserializeXmlNode(jsonData);
            using (StringWriter stringWriter = new StringWriter())
            using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
            {
                doc?.WriteTo(xmlTextWriter);
                return stringWriter.ToString();
            }

        }

        public string XmlToJson(string xmlData)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);
            string json = JsonConvert.SerializeXmlNode(doc); // Seralize -> Farklı tipte bir datayı json'a serialize eder
            return json;
        }
    }
}
