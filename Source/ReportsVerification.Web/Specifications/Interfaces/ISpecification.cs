namespace ReportsVerification.Web.Specifications.Interfaces
{
    public interface ISpecification<in T>
    {
        bool IsSpecificatedBy(T value);
    }
}
