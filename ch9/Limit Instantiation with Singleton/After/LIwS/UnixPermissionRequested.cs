namespace LIwS;

public class UnixPermissionRequested : PermissionState
{
    public static readonly string NAME = "UNIX_REQUESTED";
    public override string Name => NAME;
    public static PermissionState State { get; } = new UnixPermissionRequested();
    public override void ClaimedBy(SystemAdmin admin, SystemPermission permission)
    {
        permission.WillBeHandledBy(admin);
        permission.PermissionState = UnixPermissionClaimed.State;
    }
}