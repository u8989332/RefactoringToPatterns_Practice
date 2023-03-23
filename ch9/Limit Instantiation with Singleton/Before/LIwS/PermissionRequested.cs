namespace LIwS;

public class PermissionRequested : PermissionState
{
    public static readonly string NAME = "REQUESTED";
    public override string Name => NAME;

    public override void ClaimedBy(SystemAdmin admin, SystemPermission permission)
    {
        permission.WillBeHandledBy(admin);
        permission.PermissionState = new PermissionClaimed();
    }
}