namespace MAtV;

public class MarketingManager : AbstractEmployee
{
    public int IncreaseFans()
    {
        return 3167;
    }

    public override void Accept(IEmployeeVisitor employeeVisitor)
    {
        employeeVisitor.VisitMarketingManager(this);
    }
}