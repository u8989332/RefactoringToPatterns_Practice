namespace RILwI;

public class NotSpec<T> : Spec<T>
{
    private readonly Spec<T> _specToNegate;

    public NotSpec(Spec<T> specToNegate)
    {
        _specToNegate = specToNegate;
    }

    public override bool IsSatisfiedBy(T product)
    {
        return !_specToNegate.IsSatisfiedBy(product);
    }
}