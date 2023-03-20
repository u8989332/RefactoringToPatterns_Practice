namespace RILwI;

public class ProductFinder
{
    private readonly ProductRepository _productRepository;

    public ProductFinder(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<Product> ByColor(Color color)
    {
        return _productRepository.GetProducts().Where(x => x.Color == color).ToList();
    }

    public List<Product> ByPrice(double priceLimit)
    {
        return _productRepository.GetProducts().Where(x => x.Price == priceLimit).ToList();
    }

    public List<Product> ByColorSizeAndBelowPrice(Color color, ProductSize size, double price)
    {
        return _productRepository.GetProducts().Where(x => x.Color == color && x.ProductSize == size && x.Price < price).ToList();
    }

    public List<Product> BelowPriceAvoidingAColor(double price, Color color)
    {
        return _productRepository.GetProducts().Where(x => x.Color != color && x.Price < price).ToList();
    }
}