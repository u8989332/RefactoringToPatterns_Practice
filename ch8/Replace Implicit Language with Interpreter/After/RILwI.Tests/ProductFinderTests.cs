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
            ColorSpec spec = new ColorSpec(Color.Red);
            List<Product> foundProducts = _finder.SelectBy(spec);
            Assert.AreEqual(2, foundProducts.Count);
            Assert.IsTrue(foundProducts.Contains(_fireTruck));
            Assert.IsTrue(foundProducts.Contains(_toyConvertible));
        }

        [Test]
        public void TestFindByPrice()
        {
            PriceSpec spec = new PriceSpec(8.95);
            List<Product> foundProducts = _finder.SelectBy(spec);
            Assert.AreEqual(2, foundProducts.Count);
            foreach (var product in foundProducts)
            {
                Assert.IsTrue(product.Price == 8.95);
            }
        }

        [Test]
        public void TestFindByColorSizeAndBelowPrice()
        {
            ColorSpec colorSpec = new ColorSpec(Color.Red);
            BelowPriceSpec belowPriceSpec = new BelowPriceSpec(10.00);
            ProductSizeSpec productSizeSpec = new ProductSizeSpec(ProductSize.Small);
            AndSpec<Product> spec = new AndSpec<Product>(colorSpec, new AndSpec<Product>(belowPriceSpec, productSizeSpec));

            List<Product> foundProducts = _finder.SelectBy(spec);
            Assert.AreEqual(0, foundProducts.Count);

            colorSpec = new ColorSpec(Color.Red);
            belowPriceSpec = new BelowPriceSpec(10.00);
            productSizeSpec = new ProductSizeSpec(ProductSize.Medium);
            spec = new AndSpec<Product>(colorSpec, new AndSpec<Product>(belowPriceSpec, productSizeSpec));
            foundProducts = _finder.SelectBy(spec);
            Assert.AreEqual(_fireTruck, foundProducts[0]);
        }

        [Test]
        public void TestFindBelowPriceAvoidingAColor()
        {
            AndSpec<Product> spec = new AndSpec<Product>(
                new BelowPriceSpec(9.00),
                new NotSpec<Product>(
                    new ColorSpec(Color.White)));
            List<Product> foundProducts = _finder.SelectBy(spec);
            Assert.AreEqual(1, foundProducts.Count);
            Assert.IsTrue(foundProducts.Contains(_fireTruck));

            spec = new AndSpec<Product>(
                new BelowPriceSpec(9.00),
                new NotSpec<Product>(
                    new ColorSpec(Color.Red)));
            foundProducts = _finder.SelectBy(spec);
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