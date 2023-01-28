namespace IPCwFM;

public class XMLRunner
{
    private IOutputBuilder builder;
    public string Run()
    {
        builder = new XMLBuilder("orders");
        builder.AddBelow("<order>");

        return builder.Run();
    }
}