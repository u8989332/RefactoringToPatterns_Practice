namespace ExtractAdapter;

public class QuerySd51 : AbstractQuery
{
    private readonly SDLogin _sdLogin; // SD 5.1
    private SDSession _sdSession; // SD 5.1

    internal SDSession SdSession => _sdSession;

    public QuerySd51()
    {
        _sdLogin = new SDLogin();
    }

    public override void Login(string server, string user, string password)
    {
        try
        {
            _sdSession = _sdLogin.LoginSession(server, user, password);
        }
        catch (Exception ex)
        {
            throw new Exception("Fail", ex);
        }
    }

    protected override SDQuery CreateQuery()
    {
        return SdSession.CreateQuery(SDQuery.OPEN_FOR_QUERY);
    }
}