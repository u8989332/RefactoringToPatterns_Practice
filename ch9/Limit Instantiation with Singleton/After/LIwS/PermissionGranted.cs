namespace LIwS;

public class PermissionGranted : PermissionState
{
    public static readonly string NAME = "GRANTED";
    public override string Name => NAME;
    public static PermissionState State { get; } = new PermissionGranted();
}