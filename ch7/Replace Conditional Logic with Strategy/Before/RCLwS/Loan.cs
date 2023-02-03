namespace RCLwS
{
    public class Loan
    {
        private const double DaysPerYear = 365;
        private readonly int _riskRating;
        private readonly double _commitment;
        private readonly DateTime? _expiry;
        private readonly DateTime? _maturity;
        private readonly double _outstanding;
        private readonly double _unusedPercentage;
        public List<Payment> Payments { get; } = new List<Payment>()
        {
            new Payment(95.2, new DateTime(2022, 6, 8)),
            new Payment(153.4, new DateTime(2022, 8, 11))
        };
        private readonly DateTime? _today;
        private readonly DateTime? _start;

        public Loan(DateTime? expiry, DateTime? maturity, double commitment, double unusedPercentage, DateTime? start, DateTime? today, int riskRating, double outstanding)
        {
            _expiry = expiry;
            _maturity = maturity;
            _commitment = commitment;
            _unusedPercentage = unusedPercentage;
            _start = start;
            _today = today;
            _riskRating = riskRating;
            _outstanding = outstanding;
        }
    
        public double Capital()
        {
            if (_expiry == null && _maturity != null)
            {
                return _commitment * Duration() * GetRiskFactor();
            }

            if (_expiry != null && _maturity == null)
            {
                if (_unusedPercentage != 1.0)
                {
                    return _commitment * _unusedPercentage * Duration() * GetRiskFactor();
                }
                else
                {
                    return OutstandingRiskAmount() * Duration() * GetRiskFactor() +
                           UnusedRiskAmount() * Duration() * GetUnusedRiskFactor();
                }
            }

            return 0.0;
        }

        private double OutstandingRiskAmount()
        {
            return _outstanding;
        }

        private double UnusedRiskAmount()
        {
            return (_commitment - _outstanding);
        }

        private double Duration()
        {
            if (_expiry == null && _maturity != null)
            {
                return WeightedAverageDuration();
            }

            if (_expiry != null && _maturity == null)
            {
                return YearsTo(_expiry);
            }

            return 0.0;
        }

        private double WeightedAverageDuration()
        {
            double duration = 0;
            double weightedAverage = 0;
            double sumOfPayments = 0;
            foreach (var payment in Payments)
            {
                sumOfPayments += payment.Amount;
                weightedAverage += YearsTo(payment.Date) * payment.Amount;
            }

            if (_commitment != 0.0)
            {
                duration = weightedAverage / sumOfPayments;
            }

            return duration;
        }

        private double YearsTo(DateTime? endDate)
        {
            DateTime? beginDate = (_today == null ? _start : _today);
            TimeSpan ts = endDate.Value - beginDate.Value;
            return ts.TotalDays / DaysPerYear;
        }

        private double GetRiskFactor()
        {
            return RiskFactor.GetFactors().ForRating(_riskRating);
        }

        private double GetUnusedRiskFactor()
        {
            return UnusedRiskFactors.GetFactors().ForRating(_riskRating);
        }
    }
}
