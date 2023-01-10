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

        // For unit testing
        internal CapitalStrategy CapitalStrategy => _capitalStrategy;


        public Loan(double commitment, double outstanding, int riskRating, DateTime? maturity, DateTime? expiry) : this(null, commitment, outstanding, riskRating, maturity, expiry)
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

        public static Loan CreateTermLoan(double commitment, int riskRating, DateTime? maturity)
        {
            return new Loan(commitment, 0.00, riskRating, maturity, null);
        }

        public static Loan CreateTermLoan(CapitalStrategy capitalStrategy, double commitment, double outstanding, int riskRating, DateTime? maturity)
        {
            return new Loan(capitalStrategy, commitment, outstanding, riskRating, maturity, null);
        }

        public static Loan CreateRevolver(double commitment, double outstanding, int riskRating, DateTime? expiry)
        {
            return new Loan(commitment, outstanding, riskRating, null, expiry);
        }

        public static Loan CreateRevolver(CapitalStrategy capitalStrategy, double commitment, double outstanding, int riskRating, DateTime? expiry)
        {
            return new Loan(capitalStrategy, commitment, outstanding, riskRating, null, expiry);
        }

        public static Loan CreateRCTL(double commitment, double outstanding, int riskRating, DateTime? maturity, DateTime? expiry)
        {
            return new Loan(commitment, outstanding, riskRating, maturity, expiry);
        }

        public static Loan CreateRCTL(CapitalStrategy capitalStrategy, double commitment, double outstanding, int riskRating, DateTime? maturity, DateTime? expiry)
        {
            return new Loan(capitalStrategy, commitment, outstanding, riskRating, maturity, expiry);
        }
    }
}