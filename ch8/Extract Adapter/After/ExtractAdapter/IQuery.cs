namespace ExtractAdapter;

public interface IQuery
{
    void Login(string server, string user, string password);
    void DoQuery();
}