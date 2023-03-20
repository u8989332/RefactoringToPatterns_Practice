namespace RILwI;

public class ColorSpec : ProductSpecification
{
    public ColorSpec(Color colorOfProductToFind)
    {
        ColorOfProductToFind = colorOfProductToFind;
    }

    public Color ColorOfProductToFind { get; }

    public override bool IsSatisfiedBy(Product product)
    {
        return product.Color == this.ColorOfProductToFind;
    }
}