namespace FTM;

public class CapitalStrategyRevolver : CapitalStrategy
{
    protected override double RiskAmountFor(Loan loan)
    {
        return loan.Commitment * loan.UnusedPercentage;
    }
}