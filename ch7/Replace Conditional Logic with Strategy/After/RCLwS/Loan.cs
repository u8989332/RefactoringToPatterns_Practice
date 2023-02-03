namespace RCLwS
{
    public class Loan
    {
        internal int RiskRating { get; }
        internal double Commitment { get; }
        internal DateTime? Expiry { get; }
        internal DateTime? Maturity { get; }
        private readonly double _outstanding;
        private readonly CapitalStrategy _capitalStrategy;
        internal double UnusedPercentage { get; }

        public List<Payment> Payments { get; } = new List<Payment>()
        {
            new Payment(95.2, new DateTime(2022, 6, 8)),
            new Payment(153.4, new DateTime(2022, 8, 11))
        };

        internal DateTime? Today { get; }
        internal DateTime? Start { get; }

        public Loan(DateTime? expiry, DateTime? maturity, double commitment, double unusedPercentage, DateTime? start, DateTime? today, int riskRating, double outstanding, CapitalStrategy capitalStrategy)
        {
            Expiry = expiry;
            Maturity = maturity;
            Commitment = commitment;
            UnusedPercentage = unusedPercentage;
            Start = start;
            Today = today;
            RiskRating = riskRating;
            _outstanding = outstanding;
            _capitalStrategy = capitalStrategy;
        }

        public static Loan NewTermLoan(double commitment, double unusedPercentage, DateTime start, DateTime maturity, int riskRating, DateTime? today, double outstanding)
        {
            return new Loan(null, maturity, commitment, unusedPercentage, start, today, riskRating, outstanding,
                new CapitalStrategyTermLoan());
        }

        public static Loan NewRevolver(double commitment, double unusedPercentage, DateTime start, DateTime expiry, int riskRating, DateTime? today, double outstanding)
        {
            return new Loan(expiry, null, commitment, unusedPercentage, start, today, riskRating, outstanding,
                new CapitalStrategyRevolver());
        }

        public static Loan NewAdvisedLine(double commitment, DateTime start, DateTime expiry, int riskRating, DateTime? today, double outstanding)
        {
            if (riskRating > 3)
            {
                return null;
            }

            return new Loan(expiry, null, commitment, 1.0, start, today, riskRating, outstanding,
                new CapitalStrategyAdvisedLine());
        }

        public double Capital()
        {
            return _capitalStrategy.Capital(this);
        }

        internal double OutstandingRiskAmount()
        {
            return _outstanding;
        }

        internal double UnusedRiskAmount()
        {
            return (Commitment - _outstanding);
        }
    }
}
