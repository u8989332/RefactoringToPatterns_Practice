namespace IPCwFM;

public class XMLRunner : AbstractRunner
{
    public string Run()
    {
        builder = CreateBuilder("orders");
        builder.AddBelow("<order>");

        return builder.Run();
    }

    protected override IOutputBuilder CreateBuilder(string rootName)
    {
        return new XMLBuilder(rootName);
    }
}