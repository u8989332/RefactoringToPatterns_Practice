namespace LIwS;

public abstract class PermissionState
{

    protected PermissionState()
    {
    }

    public abstract string Name { get; }

    public virtual void ClaimedBy(SystemAdmin admin, SystemPermission permission)
    {
    }

    public virtual void DeniedBy(SystemAdmin admin, SystemPermission permission)
    {
    }

    public virtual void GrantedBy(SystemAdmin admin, SystemPermission permission)
    {
    }
}