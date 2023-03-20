namespace RILwI;

public class ProductRepository
{
    private readonly List<Product> _products = new List<Product>();
    public void Add(Product product)
    {
        _products.Add(product);
    }

    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }
}