namespace MAtV;

public interface IEmployee
{
    void Accept(IEmployeeVisitor employeeVisitor);
}