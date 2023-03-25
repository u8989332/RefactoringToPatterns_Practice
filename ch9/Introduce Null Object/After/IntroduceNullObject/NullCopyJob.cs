namespace IntroduceNullObject;

internal class NullCopyJob : CopyJob
{
    public override bool Start()
    {
        return false;
    }

    public override bool Stop()
    {
        return false;
    }

    public override bool AnySetting()
    {
        return false;
    }
}