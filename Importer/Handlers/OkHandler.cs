using System;
using Importer.Abstracts;

namespace Importer.Handlers;

public class OkHandler : DamageHandler
{
    private const int OkThreshold = 50;

    public override void Handle(int penaltyPoint)
    {
        if (penaltyPoint < OkThreshold)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[Level 0: Quality Assurance] Negligible damage detected (penalty: {penaltyPoint} points).");
            Console.WriteLine($"  Action: No action required. Everything is fine! ✅");
            Console.ResetColor();
        }
        else
        {
            _nextHandler?.Handle(penaltyPoint);
        }
    }
}
