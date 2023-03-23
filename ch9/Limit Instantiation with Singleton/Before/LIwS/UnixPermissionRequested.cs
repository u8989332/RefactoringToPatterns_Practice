namespace LIwS;

public class UnixPermissionRequested : PermissionState
{
    public static readonly string NAME = "UNIX_REQUESTED";
    public override string Name => NAME;
    public override void ClaimedBy(SystemAdmin admin, SystemPermission permission)
    {
        permission.WillBeHandledBy(admin);
        permission.PermissionState = new UnixPermissionClaimed();
    }
}