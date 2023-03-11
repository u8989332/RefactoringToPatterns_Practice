namespace ROMDwC;

public class BelowPriceSpec : Spec
{
    private readonly double _price;

    public BelowPriceSpec(double price)
    {
        _price = price;
    }

    public override bool IsSatisfiedBy(Product product)
    {
        return _price > product.Price;
    }
}