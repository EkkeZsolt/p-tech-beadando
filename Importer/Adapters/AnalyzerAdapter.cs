using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;
using Importer.Interfaces;

namespace Importer.Adapters;

public class AnalyzerAdapter : IAnalyzerTarget
{
    private readonly Analyzer.Analyzer _adaptee;

    public AnalyzerAdapter(Analyzer.Analyzer adaptee)
    {
        _adaptee = adaptee;
    }

    public int[] GetCalculatedPenalties(string xmlData)
    {
        string jsonData = ConvertXmlToJson(xmlData);
        return _adaptee.CalculateDamage(jsonData);
    }

    private string ConvertXmlToJson(string xmlData)
    {
        var doc = XDocument.Parse(xmlData);
        var incidentElements = doc.Root?.Elements("incident");

        object incidents;
        if (incidentElements != null)
        {
            incidents = incidentElements
                .Select(i => new
                {
                    courier = i.Element("courier")?.Value ?? "Unknown",
                    packageValue = double.Parse(i.Element("packageValue")?.Value ?? "0", CultureInfo.InvariantCulture),
                    damageSeverity = double.Parse(i.Element("damageSeverity")?.Value ?? "0", CultureInfo.InvariantCulture)
                })
                .ToList();
        }
        else
        {
            incidents = new List<object>();
        }

        var json = new { incidents };
        return JsonSerializer.Serialize(json, new JsonSerializerOptions { WriteIndented = false });
    }
}
