namespace RCLwS;

public class CapitalStrategyAdvisedLine : CapitalStrategy
{
    public override double Capital(Loan loan)
    {
        return loan.OutstandingRiskAmount() * DurationFor(loan) * GetRiskFactorFor(loan) +
               loan.UnusedRiskAmount() * DurationFor(loan) * GetUnusedRiskFactorFor(loan);
    }
}