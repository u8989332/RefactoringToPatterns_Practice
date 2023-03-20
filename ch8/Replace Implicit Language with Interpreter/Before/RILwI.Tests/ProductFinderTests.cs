namespace RILwI.Tests
{
    public class ProductFinderTests
    {
        private ProductFinder _finder;
        private readonly Product _fireTruck = new Product("f1234", "Fire Truck", Color.Red, 8.95, ProductSize.Medium);
        private readonly Product _barbieClassic = new Product("b7654", "Barbie Classic", Color.Yellow, 15.95, ProductSize.Small);
        private readonly Product _frisbee = new Product("f4321", "Frisbee", Color.Pink, 9.99, ProductSize.Large);
        private readonly Product _baseball = new Product("b2343", "Baseball", Color.White, 8.95, ProductSize.NotApplicable);
        private readonly Product _toyConvertible = new Product("p1112", "Toy Porsche Convertible", Color.Red, 230.00, ProductSize.NotApplicable);

        [SetUp]
        public void Setup()
        {
            _finder = new ProductFinder(CreateProductRepository());
        }

        [Test]
        public void TestFindByColor()
        {
            List<Product> foundProducts = _finder.ByColor(Color.Red);
            Assert.AreEqual(2, foundProducts.Count);
            Assert.IsTrue(foundProducts.Contains(_fireTruck));
            Assert.IsTrue(foundProducts.Contains(_toyConvertible));
        }

        [Test]
        public void TestFindByPrice()
        {
            List<Product> foundProducts = _finder.ByPrice(8.95);
            Assert.AreEqual(2, foundProducts.Count);
            foreach (var product in foundProducts)
            {
                Assert.IsTrue(product.Price == 8.95);
            }
        }

        [Test]
        public void TestFindByColorSizeAndBelowPrice()
        {
            List<Product> foundProducts = _finder.ByColorSizeAndBelowPrice(Color.Red, ProductSize.Small, 10.00);
            Assert.AreEqual(0, foundProducts.Count);

            foundProducts = _finder.ByColorSizeAndBelowPrice(Color.Red, ProductSize.Medium, 10.00);
            Assert.AreEqual(_fireTruck, foundProducts[0]);
        }

        [Test]
        public void TestFindBelowPriceAvoidingAColor()
        {
            List<Product> foundProducts = _finder.BelowPriceAvoidingAColor(9.00, Color.White);
            Assert.AreEqual(1, foundProducts.Count);
            Assert.IsTrue(foundProducts.Contains(_fireTruck));

            foundProducts = _finder.BelowPriceAvoidingAColor(9.00, Color.Red);
            Assert.AreEqual(1, foundProducts.Count);
            Assert.IsTrue(foundProducts.Contains(_baseball));
        }

        private ProductRepository CreateProductRepository()
        {
            ProductRepository repository = new ProductRepository();
            repository.Add(_fireTruck);
            repository.Add(_barbieClassic);
            repository.Add(_frisbee);
            repository.Add(_baseball);
            repository.Add(_toyConvertible);
            return repository;
        }
    }
}