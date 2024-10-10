using JsonXMLParse.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace NETPractices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JsonXMLController : Controller
    {
        private readonly IJsonXmlConverterService _jsonXmlConverterService;

        public JsonXMLController(IJsonXmlConverterService jsonXmlConverterService)
        {
            _jsonXmlConverterService = jsonXmlConverterService;
        }

        [HttpPost("xmltojson")]
        public IActionResult XmlToJson(string xmlData)
        {
            if (string.IsNullOrEmpty(xmlData))
                return BadRequest("XML data is required.");

            var jsonResult = _jsonXmlConverterService.XmlToJson(xmlData);
            return Json(new { success = true, JsonResult = jsonResult });
        }

        [HttpPost("jsontoxml")]
        public IActionResult JsonToXml([FromBody] string jsonData)
        {
            if (string.IsNullOrEmpty(jsonData))
                return BadRequest("JSON data is required.");

            var xmlResult = _jsonXmlConverterService.JsonToXml(jsonData);
            return Json(new { success = true, JsonResult = xmlResult });
        }

        [HttpPost("datatabletojson")]
        public IActionResult DataTableToJson([FromBody] DataTable dataTable)
        {
            if (dataTable == null)
                return BadRequest("DataTable is required.");

            var jsonResult = _jsonXmlConverterService.DataTableToJson(dataTable);
            return Json(new { success = true, JsonResult = jsonResult });
        }

        [HttpPost("datatabletoxml")]
        public IActionResult DataTableToXml([FromBody] DataTable dataTable)
        {
            if (dataTable == null)
                return BadRequest("DataTable is required.");

            var xmlResult = _jsonXmlConverterService.DataTableToXml(dataTable);
            return Ok(xmlResult);
        }
    }
}
