namespace RSACwS;

public class PermissionClaimed : PermissionState
{
    public PermissionClaimed() : base("CLAIMED")
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
        
        if (permission.IsUnixPermissionDesiredButNotRequested())
        {
            permission.PermissionState = UNIX_REQUESTED;
            permission.NotifyUserOfPermissionRequestResult();
            return;
        }

        permission.PermissionState = GRANTED;
        permission.IsGranted = true;
        permission.NotifyUserOfPermissionRequestResult();
    }
}