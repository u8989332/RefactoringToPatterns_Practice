namespace IntroduceNullObject;

public class JobRunner
{
    private CopyJob _copyJob = new NullCopyJob();

    public bool Start()
    {
        return _copyJob.Start();
    }

    public bool Stop()
    {
        return _copyJob.Stop();
    }

    public bool AnySetting()
    {
        return _copyJob.AnySetting();
    }

    public void Initialize()
    {
        _copyJob = new CopyJob();
    }
}