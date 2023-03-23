namespace LIwS;

public class PermissionDenied : PermissionState
{
    public static readonly string NAME = "DENIED";
    public override string Name => NAME;
    public static PermissionState State { get; } = new PermissionDenied();
}