namespace ExtractAdapter;

public class QuerySd52 : AbstractQuery
{
    private readonly string _sdConfigFileName;
    private SDLoginSession _sdLoginSession; // SD 5.2
    internal SDLoginSession SdLoginSession => _sdLoginSession;

    public QuerySd52(string sdConfigFileName) : base()
    {
        _sdConfigFileName = sdConfigFileName;
    }

    public override void Login(string server, string user, string password)
    {
        _sdLoginSession = new SDLoginSession(_sdConfigFileName, false);
        try
        {
            SdLoginSession.LoginSession(server, user, password);
        }
        catch (Exception ex)
        {
            throw new Exception("Fail", ex);
        }
    }

    protected override SDQuery CreateQuery()
    {
        return SdLoginSession.CreateQuery(SDQuery.OPEN_FOR_QUERY);
    }
}