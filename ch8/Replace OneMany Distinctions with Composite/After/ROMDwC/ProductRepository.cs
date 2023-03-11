namespace ROMDwC;

public class ProductRepository
{
    private readonly List<Product> _products = new List<Product>();
    public void Add(Product product)
    {
        _products.Add(product);
    }

    public List<Product> SelectBy(Spec spec)
    {
        List<Product> foundProducts = new List<Product>();
        foreach (Product product in _products)
        {
            if (spec.IsSatisfiedBy(product))
            {
                foundProducts.Add(product);
            }
        }

        return foundProducts;
    }
}