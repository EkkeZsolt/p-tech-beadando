using System;
using System.Text;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:5000");
var app = builder.Build();

app.MapGet("/api/incidents", () =>
{
    var couriers = new[] { "János", "Péter", "Márta", "László", "Katalin", "Gábor", "Zsuzsanna", "Tamás" };
    var rand = new Random();
    var sb = new StringBuilder();
    sb.AppendLine("<incidents>");
    for (int i = 0; i < 100; i++)
    {
        string courier = couriers[rand.Next(couriers.Length)];
        double packageValue = Math.Round(rand.NextDouble() * 1000000 + 1000, 2);
        double damageSeverity = Math.Round(rand.NextDouble() * 20 + 0.5, 2);

        sb.AppendLine("    <incident>");
        sb.AppendLine($"        <courier>{courier}</courier>");
        sb.AppendLine($"        <packageValue>{packageValue.ToString(System.Globalization.CultureInfo.InvariantCulture)}</packageValue>");
        sb.AppendLine($"        <damageSeverity>{damageSeverity.ToString(System.Globalization.CultureInfo.InvariantCulture)}</damageSeverity>");
        sb.AppendLine("    </incident>");
    }
    sb.AppendLine("</incidents>");

    return Results.Content(sb.ToString(), "application/xml");
});

app.Run();
