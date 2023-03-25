namespace IntroduceNullObject;

public class JobRunner
{
    private CopyJob _copyJob = null;

    public bool Start()
    {
        if (_copyJob != null)
        {
            return _copyJob.Start();
        }

        return false;
    }

    public bool Stop()
    {
        if (_copyJob != null)
        {
            return _copyJob.Stop();
        }

        return false;
    }

    public bool AnySetting()
    {

        if (_copyJob != null)
        {
            return _copyJob.AnySetting();
        }

        return false;
    }

    public void Initialize()
    {
        _copyJob = new CopyJob();
    }
}