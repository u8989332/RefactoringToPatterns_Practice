namespace FTM;

public class CapitalStrategyAdvisedLine : CapitalStrategy
{
    public override double Capital(Loan loan)
    {
        return base.Capital(loan) +
               UnusedCapital(loan);
    }

    private double UnusedCapital(Loan loan)
    {
        return loan.UnusedRiskAmount() * DurationFor(loan) * GetUnusedRiskFactorFor(loan);
    }

    protected override double RiskAmountFor(Loan loan)
    {
        return loan.OutstandingRiskAmount();
    }
}