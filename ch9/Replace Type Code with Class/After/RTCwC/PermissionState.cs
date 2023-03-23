namespace RTCwC;

public class PermissionState
{
    private readonly string _name;
    public PermissionState(string name)
    {
        _name = name;
    }

    public override string ToString()
    {
        return _name;
    }

    public static readonly PermissionState REQUESTED = new PermissionState("REQUESTED");
    public static readonly PermissionState CLAIMED = new PermissionState("CLAIMED");
    public static readonly PermissionState DENIED = new PermissionState("DENIED");
    public static readonly PermissionState GRANTED = new PermissionState("GRANTED");
}