namespace RILwI;

public class BelowPriceSpec : ProductSpecification
{
    public BelowPriceSpec(double priceThreshold)
    {
        PriceThreshold = priceThreshold;
    }

    public double PriceThreshold { get; }

    public override bool IsSatisfiedBy(Product product)
    {
        return product.Price < PriceThreshold;
    }
}