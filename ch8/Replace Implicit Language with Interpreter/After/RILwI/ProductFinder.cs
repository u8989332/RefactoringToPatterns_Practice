namespace RILwI;

public class ProductFinder
{
    private readonly ProductRepository _productRepository;

    public ProductFinder(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<Product> SelectBy(Spec<Product> spec)
    {
        return _productRepository.GetProducts().Where(spec.IsSatisfiedBy).ToList();
    }
}