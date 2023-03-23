namespace RTCwC;

public class SystemPermission
{
    private bool _granted;
    private string _state;
    public static readonly string REQUESTED = "REQUESTED";
    public static readonly string CLAIMED = "CLAIMED";
    public static readonly string DENIED = "DENIED";
    public static readonly string GRANTED = "GRANTED";

    public string State
    {
        get => _state;
        private set => _state = value;
    }

    public SystemPermission()
    {
        State = REQUESTED;
        _granted = false;
    }

    public void Claimed()
    {
        if (State == REQUESTED)
        {
            State = CLAIMED;
        }
    }

    public void Denied()
    {
        if (State == CLAIMED)
        {
            State = DENIED;
        }
    }

    public void Granted()
    {
        if (State != CLAIMED)
        {
            return;
        }

        State = GRANTED;
        _granted = true;
    }

    public bool IsGranted()
    {
        return _granted;
    }
}