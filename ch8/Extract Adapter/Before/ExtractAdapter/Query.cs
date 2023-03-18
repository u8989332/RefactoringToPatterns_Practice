namespace ExtractAdapter;

public class Query
{
    private readonly SDLogin _sdLogin; // SD 5.1
    private SDSession _sdSession; // SD 5.1
    private SDLoginSession _sdLoginSession; // SD 5.2
    private bool _sd52; // notify if to run as SD 5.2
    private SDQuery _sdQuery; // SD 5.1 & 5.2

    public Query()
    {
        _sdLogin = new SDLogin();
    }

    /// <summary>
    /// For unit testing
    /// </summary>
    internal bool Sd52 => _sd52;
    internal SDSession SdSession => _sdSession;
    internal SDLoginSession SdLoginSession => _sdLoginSession;
    internal SDQuery SdQuery => _sdQuery;

    // SD 5.1 login
    public void Login(string server, string user, string password)
    {
        _sd52 = false;
        try
        {
            _sdSession = _sdLogin.LoginSession(server, user, password);
        }
        catch (Exception ex)
        {
            throw new Exception("Fail", ex);
        }
    }

    // SD 5.2 login
    public void Login(string server, string user, string password, string sdConfigFileName)
    {
        _sd52 = true;
        _sdLoginSession = new SDLoginSession(sdConfigFileName, false);
        try
        {
            SdLoginSession.LoginSession(server, user, password);
        }
        catch (Exception ex)
        {
            throw new Exception("Fail", ex);
        }
    }

    public void DoQuery()
    {
        if (SdQuery != null)
        {
            SdQuery.ClearResultSet();
        }

        if (Sd52)
        {
            _sdQuery = SdLoginSession.CreateQuery(SDQuery.OPEN_FOR_QUERY);
        }
        else
        {
            _sdQuery = SdSession.CreateQuery(SDQuery.OPEN_FOR_QUERY);
        }

        ExecuteQuery();
    }

    private void ExecuteQuery()
    {
        
    }
}