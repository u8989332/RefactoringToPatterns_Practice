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

        public Loan(float notional, float outstanding, int rating, DateTime? expiry)
        {
            CapitalStrategy = new TermROC();
            Notional = notional;
            Outstanding = outstanding;
            Rating = rating;
            Expiry = expiry;
        }

        public Loan(float notional, float outstanding, int rating, DateTime? expiry, DateTime? maturity)
        {
            CapitalStrategy = new RevolingTermROC();
            Notional = notional;
            Outstanding = outstanding;
            Rating = rating;
            Expiry = expiry;
            Maturity = maturity;
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