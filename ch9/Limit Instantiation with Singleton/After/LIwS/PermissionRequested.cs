namespace LIwS;

public class PermissionRequested : PermissionState
{
    public static readonly string NAME = "REQUESTED";
    public override string Name => NAME;
    public static PermissionState State { get; } = new PermissionRequested();

    public override void ClaimedBy(SystemAdmin admin, SystemPermission permission)
    {
        permission.WillBeHandledBy(admin);
        permission.PermissionState = PermissionClaimed.State;
    }
}