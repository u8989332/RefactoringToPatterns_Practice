namespace ExtractAdapter;

internal class SDLoginSession
{
    internal string Server { get; private set; }
    internal string User { get; private set; }
    internal string Password { get; private set; }
    internal string SdConfigFileName { get; }
    internal bool Dummy { get; }

    public SDLoginSession(string sdConfigFileName, bool dummy)
    {
        SdConfigFileName = sdConfigFileName;
        Dummy = dummy;
    }

    public void LoginSession(string server, string user, string password)
    {
        Server = server;
        User = user;
        Password = password;
    }

    public SDQuery CreateQuery(string query)
    {
        return new SDQuery(Server, User, Password, query);
    }
}