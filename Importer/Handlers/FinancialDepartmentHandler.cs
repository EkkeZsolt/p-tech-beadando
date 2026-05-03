using System;
using Importer.Abstracts;

namespace Importer.Handlers;

public class FinancialDepartmentHandler : DamageHandler
{
    private const int MinimumThreshold = 50;
    private const int MinorThreshold = 200;

    public override void Handle(int penaltyPoint)
    {
        if (penaltyPoint >= MinimumThreshold && penaltyPoint < MinorThreshold)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[Level 1: Financial Department] Minor damage detected (penalty: {penaltyPoint} points).");
            Console.WriteLine($"  Action: Deducting {penaltyPoint * 50} HUF from courier's salary. ⚠️");
            Console.ResetColor();
        }
        else
        {
            _nextHandler?.Handle(penaltyPoint);
        }
    }
}
