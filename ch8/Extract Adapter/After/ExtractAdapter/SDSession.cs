namespace ExtractAdapter;

internal class SDSession
{
    internal string Server { get; }
    internal string User { get; }
    internal string Password { get; }

    public SDSession(string server, string user, string password)
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