using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ReportsVerification.Web.Builders.Interfaces;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Factories.Reports
{
    /// <summary>
    /// Фабрика создания экземпляра отчета
    /// </summary>
    public class ReportFactory : IReportFactory
    {
        private readonly IReportInfoBuilder _reportInfoBuilder;
        private readonly IEnumerable<IConcreteReportFactory> _internaFactories;

        public ReportFactory(IReportInfoBuilder reportInfoBuilder,
            IEnumerable<IConcreteReportFactory> internaFactories)
        {
            _reportInfoBuilder = reportInfoBuilder;
            _internaFactories = internaFactories;
        }

        public Report GetReport(XDocument xmlContent)
        {
            ReportInfo reportInfo;
            if (!_reportInfoBuilder.TryGetInfo(xmlContent, out reportInfo))
            {
                throw new ApplicationException("Не удалось обработать контент файла. Неизвестный типа отчета.");
            }

            var factoryies = _internaFactories.Where(e => e.ReportType == reportInfo.Type).ToArray();
            if (!factoryies.Any())
            {
                throw new ApplicationException(
                    $"Не найдена фабрика для создания указанного типа отчета  {reportInfo.Type}");
            }

            if (factoryies.Length > 1)
            {
                throw new ApplicationException(
                    $"Не найдено несколько фабрик для создания указанного типа отчета  {reportInfo.Type}");
            }

            var report = factoryies[0].GetReport(xmlContent);
            report.SetInfo(reportInfo);
            return report;
        }
    }
}