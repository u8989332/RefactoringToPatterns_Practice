namespace CreationMethod
{
    public class Loan
    {
        private readonly CapitalStrategy _capitalStrategy;
        private readonly double _commitment;
        private readonly double _outstanding;
        private readonly int _riskRating;
        private readonly DateTime? _maturity;
        private readonly DateTime? _expiry;

        public Loan(double commitment, int riskRating, DateTime? maturity) : this(commitment, 0.00, riskRating, maturity, null)
        {
        }

        public Loan(double commitment, int riskRating, DateTime? maturity, DateTime? expiry) : this(commitment, 0.00, riskRating, maturity, expiry)
        {
        }

        public Loan(double commitment, double outstanding, int riskRating, DateTime? maturity, DateTime? expiry) : this(null, commitment, outstanding, riskRating, maturity, expiry)
        {
        }

        public Loan(CapitalStrategy capitalStrategy, double commitment, int riskRating, DateTime? maturity, DateTime? expiry) : this(capitalStrategy, commitment, 0.00, riskRating, maturity, expiry)
        {
        }

        public Loan(CapitalStrategy capitalStrategy, double commitment, double outstanding, int riskRating, DateTime? maturity, DateTime? expiry)
        {
            _commitment = commitment;
            _outstanding = outstanding;
            _riskRating = riskRating;
            _maturity = maturity;
            _expiry = expiry;
            _capitalStrategy = capitalStrategy;

            if (capitalStrategy == null)
            {
                if (expiry == null)
                {
                    _capitalStrategy = new CapitalStrategyTermLoad();
                }
                else if (maturity == null)
                {
                    _capitalStrategy = new CapitalStrategyRevolver();
                }
                else
                {
                    _capitalStrategy = new CapitalStrategyRCTL();
                }
            }
        }
    }
}