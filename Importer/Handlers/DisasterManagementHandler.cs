using System;
using Importer.Abstracts;

namespace Importer.Handlers;

public class DisasterManagementHandler : DamageHandler
{
    private const int CriticalThreshold = 600;

    public override void Handle(int penaltyPoint)
    {
        if (penaltyPoint >= CriticalThreshold)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"[Level 3: Disaster Management] CRITICAL damage detected (penalty: {penaltyPoint} points)!");
            Console.WriteLine($"  Action: BUILDING EVACUATION INITIATED! Package may have created a black hole! 💥");
            Console.WriteLine($"  Emergency protocols activated. All personnel evacuating... RUN!!!!");
            Console.ResetColor();
        }
    }
}
