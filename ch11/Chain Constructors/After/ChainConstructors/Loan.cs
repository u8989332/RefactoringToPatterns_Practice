namespace ChainConstructors
{
    public class Loan
    {       
        // For unit testing
        internal float Notional { get; }
        internal float Outstanding { get; }
        internal int Rating { get; }
        internal DateTime? Expiry { get; }
        internal DateTime? Maturity { get; }
        internal CapitalStrategy CapitalStrategy { get; }

        public Loan(float notional, float outstanding, int rating, DateTime? expiry) : this(new TermROC(), notional, outstanding, rating, expiry, null)
        {
        }

        public Loan(float notional, float outstanding, int rating, DateTime? expiry, DateTime? maturity) : this(new RevolingTermROC(), notional, outstanding, rating, expiry, maturity)
        {
        }

        public Loan(CapitalStrategy strategy, float notional, float outstanding, int rating, DateTime? expiry, DateTime? maturity)
        {
            CapitalStrategy = strategy;
            Notional = notional;
            Outstanding = outstanding;
            Rating = rating;
            Expiry = expiry;
            Maturity = maturity;
        }
    }
}