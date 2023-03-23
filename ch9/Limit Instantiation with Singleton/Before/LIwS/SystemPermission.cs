namespace LIwS;

public class SystemPermission
{
    private SystemAdmin _admin;
    private SystemProfile _profile;
    private SystemUser _requestor;

    public SystemPermission(SystemAdmin admin, SystemUser requestor, SystemProfile profile)
    {
        _admin = admin;
        _requestor = requestor;
        _profile = profile;
        IsGranted = false;
        PermissionState = new PermissionRequested();
        NotifyAdminOfPermissionRequest();
    }

    public PermissionState PermissionState { get; internal set; }

    public bool IsGranted { get; internal set; }
    public bool IsUnixPermissionGranted { get; internal set; }
    public SystemAdmin Admin => _admin;


    private void NotifyAdminOfPermissionRequest()
    {
    }

    public void ClaimedBy(SystemAdmin admin)
    {
        PermissionState.ClaimedBy(admin, this);
    }

    internal void WillBeHandledBy(SystemAdmin admin)
    {
        _admin = admin;
    }

    public void DeniedBy(SystemAdmin admin)
    {
        PermissionState.DeniedBy(admin, this);
    }

    internal void NotifyUserOfPermissionRequestResult()
    {
    }

    public void GrantedBy(SystemAdmin admin)
    {
        PermissionState.GrantedBy(admin, this);
    }

    internal bool IsUnixPermissionDesiredButNotRequested()
    {
        return _profile.IsUnixPermissionRequired && IsUnixPermissionGranted;
    }

    internal bool IsUnixPermissionRequestedAndClaimed()
    {
        return _profile.IsUnixPermissionRequired && PermissionState.Name == UnixPermissionClaimed.NAME;
    }

    internal bool IsClaimedState()
    {
        return PermissionState.Name == PermissionClaimed.NAME || PermissionState.Name == UnixPermissionClaimed.NAME;
    }
}