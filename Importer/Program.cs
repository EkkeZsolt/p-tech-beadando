using System;
using Importer.Factories;
using Importer.Interfaces;
using Importer.Adapters;
using Importer.Singeltons;

namespace Importer;

class Program
{
    static void Main(string[] args)
    {
        var server = ServerConnection.Instance;
        string xmlData = server.GetXmlData();

        Analyzer.Analyzer adaptee = new Analyzer.Analyzer();
        IAnalyzerTarget adapter = new AnalyzerAdapter(adaptee);
        int[] penaltyPoints = adapter.GetCalculatedPenalties(xmlData);

        Console.WriteLine("--- Alapértelmezett lánc indítása ---");
        var handlerChain = HandlerChainFactory.CreateDefaultChain();

        foreach (int penalty in penaltyPoints)
        {
            handlerChain.Handle(penalty);
        }
        
        Console.WriteLine("\n--- Szigorú lánc indítása (nincs OK naplózás) ---");
        var strictChain = HandlerChainFactory.CreateStrictChain();
        foreach (int penalty in penaltyPoints)
        {
            strictChain.Handle(penalty);
        }
    }
}
