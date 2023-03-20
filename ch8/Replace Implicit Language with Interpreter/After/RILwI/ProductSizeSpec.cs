namespace RILwI;

public class ProductSizeSpec : ProductSpecification
{
    public ProductSize Size { get; }

    public ProductSizeSpec(ProductSize size)
    {
        Size = size;
    }

    public override bool IsSatisfiedBy(Product product)
    {
        return product.ProductSize == Size;
    }
}