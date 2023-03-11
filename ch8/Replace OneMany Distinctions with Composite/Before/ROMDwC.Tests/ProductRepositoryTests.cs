namespace ROMDwC.Tests
{
    public class ProductRepositoryTests
    {
        private ProductRepository _repository;
        private readonly Product _fireTruck = new Product("f1234", "Fire Truck", Color.Red, 8.95, ProductSize.Medium);
        private readonly Product _barbieClassic = new Product("b7654", "Barbie Classic", Color.Yellow, 15.95, ProductSize.Small);
        private readonly Product _frisbee = new Product("f4321", "Frisbee", Color.Pink, 9.99, ProductSize.Large);
        private readonly Product _baseball = new Product("b2343", "Baseball", Color.White, 8.95, ProductSize.NotApplicable);
        private readonly Product _toyConvertible = new Product("p1112", "Toy Porsche Convertible", Color.Red, 230.00, ProductSize.NotApplicable);

        [SetUp]
        public void Setup()
        {
            _repository = new ProductRepository();
            _repository.Add(_fireTruck);
            _repository.Add(_barbieClassic);
            _repository.Add(_frisbee);
            _repository.Add(_baseball);
            _repository.Add(_toyConvertible);
        }

        [Test]
        public void TestFindByColor()
        {
            // arrange && act
            var result = _repository.SelectBy(new ColorSpec(Color.Red));

            // assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(_fireTruck));
            Assert.IsTrue(result.Contains(_toyConvertible));
        }

        [Test]
        public void TestFindByColorSizeAndBelowPrice()
        {
            // arrange
            List<Spec> specs = new List<Spec>();
            specs.Add(new ColorSpec(Color.Red));
            specs.Add(new SizeSpec(ProductSize.Small));
            specs.Add(new BelowPriceSpec(10.00));

            // act
            var result = _repository.SelectBy(specs);

            // assert
            Assert.AreEqual(0, result.Count);
        }
    }
}