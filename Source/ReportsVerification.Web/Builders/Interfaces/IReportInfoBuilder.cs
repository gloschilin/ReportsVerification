using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;

namespace ReportsVerification.Web.Builders.Interfaces
{
    /// <summary>
    /// Сборщик объекта ReportInfo из контента отчета
    /// </summary>
    public interface IReportInfoBuilder
    {
        /// <summary>
        /// Получить информацию ReportInfo
        /// </summary>
        /// <param name="xmlFileContent"></param>
        /// <param name="reportInfo"></param>
        /// <returns></returns>
        bool TryGetInfo(XDocument xmlFileContent, out ReportInfo reportInfo);
    }
}
