using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;

namespace ReportsVerification.Web.Factories.Interfaces
{
    /// <summary>
    /// Фабрика создания отчетов
    /// </summary>
    public interface IReportFactory
    {
        /// <summary>
        /// Получить экспемпляр отчета
        /// </summary>
        /// <param name="xmlContent"></param>
        /// <returns></returns>
        Report GetReport(XDocument xmlContent);
    }
}