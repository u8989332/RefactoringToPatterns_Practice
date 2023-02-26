namespace RITwC;

public class Order
{
    public Order(string orderId)
    {
        OrderId = orderId;
    }

    public string OrderId { get; }
    public int ProductCount => _products.Count;
    private readonly List<Product> _products = new List<Product>();

    public Product GetProduct(int index)
    {
        return _products[index];
    }

    public void Add(Product product)
    {
        _products.Add(product);
    }
}