namespace FTM
{
    public abstract class CapitalStrategy
    {
        private const double DaysPerYear = 365;
        public virtual double Capital(Loan loan)
        {
            return RiskAmountFor(loan) * DurationFor(loan) * GetRiskFactorFor(loan);
        }
        protected abstract double RiskAmountFor(Loan loan);

        protected double GetRiskFactorFor(Loan loan)
        {
            return RiskFactor.GetFactors().ForRating(loan.RiskRating);
        }

        protected double GetUnusedRiskFactorFor(Loan loan)
        {
            return UnusedRiskFactors.GetFactors().ForRating(loan.RiskRating);
        }

        protected virtual double DurationFor(Loan loan)
        {
            if (loan.Expiry != null && loan.Maturity == null)
            {
                return YearsTo(loan.Expiry, loan);
            }

            return 0.0;
        }

        protected double YearsTo(DateTime? endDate, Loan loan)
        {
            DateTime? beginDate = (loan.Today == null ? loan.Start : loan.Today);
            TimeSpan ts = endDate.Value - beginDate.Value;
            return ts.TotalDays / DaysPerYear;
        }
    }
}
