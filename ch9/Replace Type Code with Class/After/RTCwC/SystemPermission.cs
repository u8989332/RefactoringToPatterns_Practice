namespace RTCwC;

public class SystemPermission
{
    private bool _granted;

    public PermissionState State
    {
        get => _permission;
    }

    private PermissionState Permission
    {
        set => _permission = value;
    }

    private PermissionState _permission;

    public SystemPermission()
    {
        Permission = PermissionState.REQUESTED;
        _granted = false;
    }

    public void Claimed()
    {
        if (State == PermissionState.REQUESTED)
        {
            Permission = PermissionState.CLAIMED;
        }
    }

    public void Denied()
    {
        if (State == PermissionState.CLAIMED)
        {
            Permission = PermissionState.DENIED;
        }
    }

    public void Granted()
    {
        if (State != PermissionState.CLAIMED)
        {
            return;
        }

        Permission = PermissionState.GRANTED;
        _granted = true;
    }

    public bool IsGranted()
    {
        return _granted;
    }
}