using System;
using System.Net.Http;

namespace Importer.Singeltons;

public sealed class ServerConnection
{
    private static readonly Lazy<ServerConnection> _instance = new(() => new ServerConnection());
    public static ServerConnection Instance => _instance.Value;
    
    private readonly HttpClient _httpClient;

    private ServerConnection() 
    { 
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("http://localhost:5000");
    }

    public string GetXmlData()
    {
        try 
        {
            var response = _httpClient.GetAsync("/api/incidents").GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
        catch
        {
            return "<incidents></incidents>";
        }
    }
}
