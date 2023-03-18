namespace ExtractAdapter;

internal class SDQuery
{
    internal string Server { get; }
    internal string User { get; }
    internal string Password { get; }
    internal string Query { get; }

    public SDQuery(string server, string user, string password, string query)
    {
        Server = server;
        User = user;
        Password = password;
        Query = query;
    }

    internal const string OPEN_FOR_QUERY = "QEURY";

    public void ClearResultSet()
    {
        
    }
}