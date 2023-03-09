namespace FTM;

public class CapitalStrategyTermLoan : CapitalStrategy
{
    protected override double RiskAmountFor(Loan loan)
    {
        return loan.Commitment;
    }

    protected override double DurationFor(Loan loan)
    {
        return WeightedAverageDuration(loan);
    }

    private double WeightedAverageDuration(Loan loan)
    {
        double duration = 0;
        double weightedAverage = 0;
        double sumOfPayments = 0;
        foreach (var payment in loan.Payments)
        {
            sumOfPayments += payment.Amount;
            weightedAverage += YearsTo(payment.Date, loan) * payment.Amount;
        }

        if (loan.Commitment != 0.0)
        {
            duration = weightedAverage / sumOfPayments;
        }

        return duration;
    }

}