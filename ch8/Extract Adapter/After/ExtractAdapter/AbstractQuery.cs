namespace ExtractAdapter;

public abstract class AbstractQuery : IQuery
{
    protected SDQuery _sdQuery; // SD 5.1 & 5.2

    protected AbstractQuery()
    {

    }

    /// <summary>
    /// For unit testing
    /// </summary>
    
    internal SDQuery SdQuery => _sdQuery;

    public abstract void Login(string server, string user, string password);

    public void DoQuery()
    {
        if (_sdQuery != null)
        {
            _sdQuery.ClearResultSet();
        }

        _sdQuery = CreateQuery();
        ExecuteQuery();
    }

    protected abstract SDQuery CreateQuery();

    private void ExecuteQuery()
    {
        
    }
}