namespace FTM.Tests
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
            Loan loan = Loan.NewTermLoan(5.6, 2.3, new DateTime(2020, 5, 1), new DateTime(2023, 2, 4), 3, null, 4.2);

            // act
            var result = loan.Capital();

            // assert
            Assert.AreEqual(18.58336724, result, 0.00000001);
        }

        [Test]
        public void TestCapitalStrategyAdviseLine()
        {
            // arrange
            Loan loan = Loan.NewAdvisedLine(5.6, new DateTime(2020, 5, 1), new DateTime(2023, 2, 4), 3, null, 4.2);

            // act
            var result = loan.Capital();

            // assert
            Assert.AreEqual(23.22082191, result, 0.00000001);
        }

        [Test]
        public void TestCapitalStrategyRevolver()
        {
            // arrange
            Loan loan = Loan.NewRevolver(5.6, 5.9, new DateTime(2020, 5, 1), new DateTime(2023, 2, 4), 3, null, 4.2);

            // act
            var result = loan.Capital();

            // assert
            Assert.AreEqual(137.00284931, result, 0.00000001);
        }
    }
}