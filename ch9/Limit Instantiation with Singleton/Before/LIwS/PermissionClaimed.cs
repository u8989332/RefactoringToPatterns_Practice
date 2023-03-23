namespace LIwS;

public class PermissionClaimed : PermissionState
{
    public static readonly string NAME = "CLAIMED";
    public override string Name => NAME;

    public override void DeniedBy(SystemAdmin admin, SystemPermission permission)
    {
        if (permission.Admin != admin) return;

        permission.IsGranted = false;
        permission.IsUnixPermissionGranted = false;
        permission.PermissionState = new PermissionDenied();
        permission.NotifyUserOfPermissionRequestResult();
    }

    public override void GrantedBy(SystemAdmin admin, SystemPermission permission)
    {
        if (permission.Admin != admin) return;
        
        if (permission.IsUnixPermissionDesiredButNotRequested())
        {
            permission.PermissionState = new UnixPermissionRequested();
            permission.NotifyUserOfPermissionRequestResult();
            return;
        }

        permission.PermissionState = new PermissionGranted();
        permission.IsGranted = true;
        permission.NotifyUserOfPermissionRequestResult();
    }
}