namespace IPCwFM;

public abstract class AbstractRunner
{
    protected IOutputBuilder builder;
    protected abstract IOutputBuilder CreateBuilder(string rootName);
}