using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Analyzer;

public class Analyzer
{
    public int[] CalculateDamage(string jsonData)
    {
        try
        {
            var doc = JsonDocument.Parse(jsonData);
            var incidents = doc.RootElement.GetProperty("incidents").EnumerateArray().ToList();
            var penaltyPoints = new List<int>();

            foreach (var incident in incidents)
            {
                double packageValue = incident.GetProperty("packageValue").GetDouble();
                double damageSeverity = incident.GetProperty("damageSeverity").GetDouble();

                int penalty = (int)(Math.Log10(packageValue / 1000) * damageSeverity * 15);
                penaltyPoints.Add(Math.Max(0, penalty));
            }

            return penaltyPoints.ToArray();
        }
        catch
        {
            return Array.Empty<int>();
        }
    }
}
