namespace LIwS;

public class PermissionClaimed : PermissionState
{
    public static readonly string NAME = "CLAIMED";
    public override string Name => NAME;

    public static PermissionState State { get; } = new PermissionClaimed();

    public override void DeniedBy(SystemAdmin admin, SystemPermission permission)
    {
        if (permission.Admin != admin) return;

        permission.IsGranted = false;
        permission.IsUnixPermissionGranted = false;
        permission.PermissionState = PermissionDenied.State;
        permission.NotifyUserOfPermissionRequestResult();
    }

    public override void GrantedBy(SystemAdmin admin, SystemPermission permission)
    {
        if (permission.Admin != admin) return;
        
        if (permission.IsUnixPermissionDesiredButNotRequested())
        {
            permission.PermissionState = UnixPermissionRequested.State;
            permission.NotifyUserOfPermissionRequestResult();
            return;
        }

        permission.PermissionState = PermissionGranted.State;
        permission.IsGranted = true;
        permission.NotifyUserOfPermissionRequestResult();
    }
}