namespace RCLwS
{
    public class Payment
    {
        public double Amount { get; }
        public DateTime Date { get; }
        public Payment(double amount, DateTime date)
        {
            Amount = amount;
            Date = date;
        }
    }
}