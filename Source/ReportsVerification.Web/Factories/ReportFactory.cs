using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ReportsVerification.Web.Builders.Interfaces;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Factories
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

            var factory = _internaFactories.FirstOrDefault(e => e.ReportType == reportInfo.Type);
            if (factory == null)
            {
                throw new ApplicationException(
                    $"Не найдена фабрика для создания указанного типа отчета  {reportInfo.Type}");
            }

            return factory.GetReport(xmlContent);
        }
    }
}