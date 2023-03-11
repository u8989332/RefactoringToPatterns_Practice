namespace ROMDwC;

public class Product
{
    public string Id { get; }
    public string Name { get; }
    public Color Color { get; }
    public double Price { get; }
    public ProductSize ProductSize { get; }

    public Product(string id, string name, Color color, double price, ProductSize productSize)
    {
        Id = id;
        Name = name;
        Color = color;
        Price = price;
        ProductSize = productSize;
    }
}