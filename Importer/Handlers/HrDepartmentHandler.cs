using System;
using Importer.Abstracts;

namespace Importer.Handlers;

public class HrDepartmentHandler : DamageHandler
{
    private const int MediumThreshold = 200;
    private const int CriticalThreshold = 600;

    public override void Handle(int penaltyPoint)
    {
        if (penaltyPoint >= MediumThreshold && penaltyPoint < CriticalThreshold)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Level 2: HR Department] Medium damage detected (penalty: {penaltyPoint} points).");
            Console.WriteLine($"  Action: Courier is being IMMEDIATELY TERMINATED! 🚨");
            Console.ResetColor();
        }
        else if (penaltyPoint >= CriticalThreshold)
        {
            _nextHandler?.Handle(penaltyPoint);
        }
    }
}
