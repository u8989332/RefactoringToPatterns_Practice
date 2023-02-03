namespace RCLwS;

public class CapitalStrategyRevolver : CapitalStrategy
{
    public override double Capital(Loan loan)
    { 
        return loan.Commitment * loan.UnusedPercentage * DurationFor(loan) * GetRiskFactorFor(loan);
    }
}