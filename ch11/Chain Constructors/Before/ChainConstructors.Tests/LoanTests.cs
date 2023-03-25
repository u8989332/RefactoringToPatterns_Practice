namespace ChainConstructors.Tests
{
    public class LoanTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTermROC()
        {
            // arrange
            float notional = 100.5f;
            float outstanding = 5.5f;
            int rating = 2;
            DateTime? expiry = new DateTime(2022, 1, 30);

            // act
            Loan result = new Loan(notional, outstanding, rating, expiry);

            // assert
            Assert.IsTrue(result.CapitalStrategy is TermROC);
            Assert.AreEqual(notional, result.Notional);
            Assert.AreEqual(outstanding, result.Outstanding);
            Assert.AreEqual(rating, result.Rating);
            Assert.AreEqual(expiry, result.Expiry);
        }

        [Test]
        public void TestRevolingTermROC()
        {
            // arrange
            float notional = 20.6f;
            float outstanding = 97.1f;
            int rating = 3;
            DateTime? expiry = new DateTime(2022, 6, 10);
            DateTime? maturity = new DateTime(2022, 3, 12);

            // act
            Loan result = new Loan(notional, outstanding, rating, expiry, maturity);

            // assert
            Assert.IsTrue(result.CapitalStrategy is RevolingTermROC);
            Assert.AreEqual(notional, result.Notional);
            Assert.AreEqual(outstanding, result.Outstanding);
            Assert.AreEqual(rating, result.Rating);
            Assert.AreEqual(expiry, result.Expiry);
            Assert.AreEqual(maturity, result.Maturity);
        }

        [Test]
        public void TestCustomLoan()
        {
            // arrange
            CapitalStrategy strategy = new TermROC();
            float notional = 429.6f;
            float outstanding = 197.1f;
            int rating = 4;
            DateTime? expiry = new DateTime(2022, 9, 25);
            DateTime? maturity = null;

            // act
            Loan result = new Loan(strategy, notional, outstanding, rating, expiry, maturity);

            // assert
            Assert.IsTrue(result.CapitalStrategy is TermROC);
            Assert.AreEqual(notional, result.Notional);
            Assert.AreEqual(outstanding, result.Outstanding);
            Assert.AreEqual(rating, result.Rating);
            Assert.AreEqual(expiry, result.Expiry);
            Assert.IsNull(result.Maturity);
        }
    }
}