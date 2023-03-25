namespace MAtV;

public abstract class AbstractEmployee : IEmployee
{
    public virtual void Accept(IEmployeeVisitor employeeVisitor)
    {
    }
}