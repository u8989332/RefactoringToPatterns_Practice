namespace RSACwS;

public class SystemPermission
{
    public static readonly string REQUESTED = "REQUESTED";
    public static readonly string CLAIMED = "CLAIMED";
    public static readonly string GRANTED = "GRANTED";
    public static readonly string DENIED = "DENIED";
    public static readonly string UNIX_REQUESTED = "UNIX_REQUESTED";
    public static readonly string UNIX_CLAIMED = "UNIX_CLAIMED";
    private SystemAdmin _admin;
    private SystemProfile _profile;
    private SystemUser _requestor;

    public SystemPermission(SystemAdmin admin, SystemUser requestor, SystemProfile profile)
    {
        _admin = admin;
        _requestor = requestor;
        _profile = profile;
        State = REQUESTED;
        IsGranted = false;
        NotifyAdminOfPermissionRequest();
    }

    public string State { get; private set; }

    public bool IsGranted { get; private set; }
    public bool IsUnixPermissionGranted { get; private set; }


    private void NotifyAdminOfPermissionRequest()
    {
    }

    public void ClaimedBy(SystemAdmin admin)
    {
        if (State != REQUESTED && State != UNIX_REQUESTED)
        {
            return;
        }

        WillBeHandledBy(admin);
        if (State == REQUESTED)
        {
            State = CLAIMED;
        }
        else if (State == UNIX_REQUESTED)
        {
            State = UNIX_CLAIMED;
        }
       
    }

    private void WillBeHandledBy(SystemAdmin admin)
    {
        _admin = admin;
    }

    public void DeniedBy(SystemAdmin admin)
    {
        if (State != CLAIMED && State != UNIX_CLAIMED) return;

        if (_admin != admin) return;

        IsGranted = false;
        IsUnixPermissionGranted = false;
        State = DENIED;
        NotifyUserOfPermissionRequestResult();
    }

    private void NotifyUserOfPermissionRequestResult()
    {
    }

    public void GrantedBy(SystemAdmin admin)
    {
        if (State != CLAIMED && State != UNIX_CLAIMED) return;

        if (_admin != admin) return;

        if (_profile.IsUnixPermissionRequired && State == UNIX_CLAIMED)
        {
            IsUnixPermissionGranted = true;
        }
        else if (_profile.IsUnixPermissionRequired && IsUnixPermissionGranted)
        {
            State = UNIX_REQUESTED;
            NotifyUserOfPermissionRequestResult();
            return;
        }

        State = GRANTED;
        IsGranted = true;
        NotifyUserOfPermissionRequestResult();
    }
}