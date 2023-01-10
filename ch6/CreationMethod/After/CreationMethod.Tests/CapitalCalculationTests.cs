namespace CreationMethod.Tests
{
    public class CapitalCalculationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTermLoadNoPayments()
        {
            double commitment = 100;
            int riskRating = 2;
            DateTime? maturity = null;
            
            Loan termLoan = Loan.CreateTermLoan(commitment, riskRating, maturity);

            Assert.IsTrue(termLoan.CapitalStrategy is CapitalStrategyTermLoad);
        }

        [Test]
        public void TestTermLoadNoMaturityButHasExpiry()
        {
            double commitment = 100;
            double outstanding = 5.5;
            int riskRating = 2;
            DateTime? expiry = DateTime.Now;

            Loan termLoan = Loan.CreateRevolver(commitment, outstanding, riskRating, expiry);

            Assert.IsTrue(termLoan.CapitalStrategy is CapitalStrategyRevolver);
        }

        [Test]
        public void TestTermLoadHasMaturityExpiry()
        {
            double commitment = 100;
            double outstanding = 5.5;
            int riskRating = 2;
            DateTime? maturity = DateTime.Now;
            DateTime? expiry = DateTime.Now;

            Loan termLoan = Loan.CreateRCTL(null, commitment, outstanding, riskRating, maturity, expiry);

            Assert.IsTrue(termLoan.CapitalStrategy is CapitalStrategyRCTL);
        }
    }
}