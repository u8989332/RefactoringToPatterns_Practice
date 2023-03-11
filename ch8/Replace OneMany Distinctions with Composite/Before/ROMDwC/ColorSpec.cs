namespace ROMDwC;

public class ColorSpec : Spec
{
    private readonly Color _color;

    public ColorSpec(Color color)
    {
        _color = color;
    }

    public override bool IsSatisfiedBy(Product product)
    {
        return _color == product.Color;
    }
}