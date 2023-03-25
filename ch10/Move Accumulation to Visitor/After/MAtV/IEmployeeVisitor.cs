namespace MAtV;

public interface IEmployeeVisitor
{
    void VisitBookkeeper(Bookkeeper bookkeeper);
    void VisitMarketingManager(MarketingManager marketingManager);
    void VisitProjectManager(ProjectManager projectManager);
    void VisitEngineer(Engineer engineer);
}