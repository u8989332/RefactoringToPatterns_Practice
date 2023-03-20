namespace RILwI;

public class AndSpec<T> : Spec<T>
{
    public AndSpec(Spec<T> augend, Spec<T> addend)
    {
        Augend = augend;
        Addend = addend;
    }

    public Spec<T> Addend { get; }

    public Spec<T> Augend { get; }


    public override bool IsSatisfiedBy(T product)
    {
        return Augend.IsSatisfiedBy(product) && Addend.IsSatisfiedBy(product);
    }
}