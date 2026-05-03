namespace Importer.Abstracts;

public abstract class DamageHandler
{
    protected DamageHandler? _nextHandler;

    public void SetNext(DamageHandler nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public abstract void Handle(int penaltyPoint);
}
