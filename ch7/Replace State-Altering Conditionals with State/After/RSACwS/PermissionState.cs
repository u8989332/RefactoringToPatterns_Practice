namespace RSACwS;

public abstract class PermissionState
{
    private readonly string _name;

    protected PermissionState(string name)
    {
        _name = name;
    }

    public static readonly PermissionState REQUESTED = new PermissionRequested();
    public static readonly PermissionState CLAIMED = new PermissionClaimed();
    public static readonly PermissionState GRANTED = new PermissionGranted();
    public static readonly PermissionState DENIED = new PermissionDenied();
    public static readonly PermissionState UNIX_REQUESTED = new UnixPermissionRequested();
    public static readonly PermissionState UNIX_CLAIMED = new UnixPermissionClaimed();

    public override string ToString()
    {
        return _name;
    }

    public virtual void ClaimedBy(SystemAdmin admin, SystemPermission permission)
    {
    }

    public virtual void DeniedBy(SystemAdmin admin, SystemPermission permission)
    {
    }

    public virtual void GrantedBy(SystemAdmin admin, SystemPermission permission)
    {
    }
}