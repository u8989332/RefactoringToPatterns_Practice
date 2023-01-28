namespace IPCwFM;

public class DOMRunner
{
    private IOutputBuilder builder;
    public string Run()
    {
        builder = new DOMBuilder("orders");
        builder.AddBelow("[order]");

        return builder.Run();
    }
}