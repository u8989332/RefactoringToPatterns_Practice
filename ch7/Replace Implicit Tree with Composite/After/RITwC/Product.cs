namespace RITwC;

public class Product
{
    public Product(int id, int size, string name, double price)
    {
        Id = id;
        Size = size;
        Name = name;
        Price = price;
    }

    public int Id { get; }
    public int Size { get; }
    public string Name { get; }
    public double Price { get; }
}