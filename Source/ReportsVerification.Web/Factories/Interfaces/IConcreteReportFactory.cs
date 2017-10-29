using ReportsVerification.Web.DataObjects;

namespace ReportsVerification.Web.Factories.Interfaces
{
    /// <summary>
    /// Фабрика создания конкретного типа отчета
    /// </summary>
    public interface IConcreteReportFactory : IReportFactory
    {
        /// <summary>
        /// Тип создаваемого отчета
        /// </summary>
        ReportTypes ReportType { get; }
    }
}