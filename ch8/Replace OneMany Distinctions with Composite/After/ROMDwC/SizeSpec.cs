namespace ROMDwC;

public class SizeSpec : Spec
{
    private readonly ProductSize _size;

    public SizeSpec(ProductSize size)
    {
        _size = size;
    }

    public override bool IsSatisfiedBy(Product product)
    {
        return _size == product.ProductSize;
    }
}