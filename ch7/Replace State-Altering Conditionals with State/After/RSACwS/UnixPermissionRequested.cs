namespace RSACwS;

public class UnixPermissionRequested : PermissionState
{
    public UnixPermissionRequested() : base("UNIX_REQUESTED")
    {
    }

    public override void ClaimedBy(SystemAdmin admin, SystemPermission permission)
    {
        permission.WillBeHandledBy(admin);
        permission.PermissionState = UNIX_CLAIMED;
    }
}