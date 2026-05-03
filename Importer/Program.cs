using System;
using Importer.Handlers;
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

        var okHandler = new OkHandler();
        var financialHandler = new FinancialDepartmentHandler();
        var hrHandler = new HrDepartmentHandler();
        var disasterHandler = new DisasterManagementHandler();

        okHandler.SetNext(financialHandler);
        financialHandler.SetNext(hrHandler);
        hrHandler.SetNext(disasterHandler);

        foreach (int penalty in penaltyPoints)
        {
            okHandler.Handle(penalty);
        }
    }
}
