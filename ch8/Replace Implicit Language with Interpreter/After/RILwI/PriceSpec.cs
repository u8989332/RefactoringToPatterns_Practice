namespace RILwI;

public class PriceSpec : ProductSpecification
{
    public PriceSpec(double priceLimit)
    {
        PriceLimit = priceLimit;
    }

    public double PriceLimit { get; }

    public override bool IsSatisfiedBy(Product product)
    {
        return product.Price == PriceLimit;
    }
}