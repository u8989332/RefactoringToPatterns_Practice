namespace RCLwS.Tests
{
    public class LoanTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCapitalStrategyTermLoan()
        {
            // arrange
            Loan loan = new Loan(null, new DateTime(2023, 2, 4), 5.6, 2.3, new DateTime(2020, 5, 1), null, 3, 4.2);

            // act
            var result = loan.Capital();

            // assert
            Assert.AreEqual(18.58336724, result, 0.00000001);
        }

        [Test]
        public void TestCapitalStrategyAdviseLine()
        {
            // arrange
            Loan loan = new Loan(new DateTime(2023, 2, 4), null, 5.6, 1.0, new DateTime(2020, 5, 1), null, 3, 4.2);

            // act
            var result = loan.Capital();

            // assert
            Assert.AreEqual(23.22082191, result, 0.00000001);
        }

        [Test]
        public void TestCapitalStrategyRevolver()
        {
            // arrange
            Loan loan = new Loan(new DateTime(2023, 2, 4), null, 5.6, 5.9, new DateTime(2020, 5, 1), null, 3, 4.2);

            // act
            var result = loan.Capital();

            // assert
            Assert.AreEqual(137.00284931, result, 0.00000001);
        }
    }
}