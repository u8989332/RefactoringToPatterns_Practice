namespace ExtractAdapter;

internal class SDLogin
{
    public SDSession LoginSession(string server, string user, string password)
    {
        return new SDSession(server, user, password);
    }
}