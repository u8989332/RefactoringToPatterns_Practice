namespace RSACwS;

public class PermissionRequested : PermissionState
{
    public PermissionRequested() : base("REQUESTED")
    {
    }

    public override void ClaimedBy(SystemAdmin admin, SystemPermission permission)
    {
        permission.WillBeHandledBy(admin);
        permission.PermissionState = CLAIMED;
    }
}