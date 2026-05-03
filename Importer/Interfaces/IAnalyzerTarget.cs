namespace Importer.Interfaces;

public interface IAnalyzerTarget
{
    int[] GetCalculatedPenalties(string xmlData);
}
