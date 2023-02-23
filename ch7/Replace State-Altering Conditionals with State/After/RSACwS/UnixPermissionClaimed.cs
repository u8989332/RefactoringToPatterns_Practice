namespace RSACwS;

public class UnixPermissionClaimed: PermissionState
{
    public UnixPermissionClaimed() : base("UNIX_CLAIMED")
    {
    }

    public override void DeniedBy(SystemAdmin admin, SystemPermission permission)
    {
        if (permission.Admin != admin) return;

        permission.IsGranted = false;
        permission.IsUnixPermissionGranted = false;
        permission.PermissionState = DENIED;
        permission.NotifyUserOfPermissionRequestResult();
    }

    public override void GrantedBy(SystemAdmin admin, SystemPermission permission)
    {
        if (permission.Admin != admin) return;

        if (permission.IsUnixPermissionRequestedAndClaimed())
        {
            permission.IsUnixPermissionGranted = true;
        }

        permission.PermissionState = GRANTED;
        permission.IsGranted = true;
        permission.NotifyUserOfPermissionRequestResult();
    }
}