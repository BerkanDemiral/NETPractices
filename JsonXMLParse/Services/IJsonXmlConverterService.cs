using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonXMLParse.Services
{
    public interface IJsonXmlConverterService
    {
        string XmlToJson(string xmlData);
        string JsonToXml(string jsonData);
        string DataTableToJson(DataTable dataTable);
        string DataTableToXml(DataTable dataTable);
    }
}
