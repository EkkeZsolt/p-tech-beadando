using Importer.Abstracts;
using Importer.Handlers;

namespace Importer.Factories;

public static class HandlerChainFactory
{
    public static DamageHandler CreateDefaultChain()
    {
        var okHandler = new OkHandler();
        var financialHandler = new FinancialDepartmentHandler();
        var hrHandler = new HrDepartmentHandler();
        var disasterHandler = new DisasterManagementHandler();

        okHandler.SetNext(financialHandler);
        financialHandler.SetNext(hrHandler);
        hrHandler.SetNext(disasterHandler);

        return okHandler;
    }

    public static DamageHandler CreateStrictChain()
    {
        var financialHandler = new FinancialDepartmentHandler();
        var hrHandler = new HrDepartmentHandler();
        var disasterHandler = new DisasterManagementHandler();

        financialHandler.SetNext(hrHandler);
        hrHandler.SetNext(disasterHandler);

        return financialHandler;
    }

    public static DamageHandler CreateLenientChain()
    {
        var okHandler = new OkHandler();
        var financialHandler = new FinancialDepartmentHandler();
        var hrHandler = new HrDepartmentHandler();

        okHandler.SetNext(financialHandler);
        financialHandler.SetNext(hrHandler);

        return okHandler;
    }
}
