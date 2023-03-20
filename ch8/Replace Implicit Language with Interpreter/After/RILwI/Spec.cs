namespace RILwI;

public abstract class Spec<T>
{
    public abstract bool IsSatisfiedBy(T product);
}