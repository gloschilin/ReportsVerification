using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ReportsVerification.Web.Builders.Interfaces;
using ReportsVerification.Web.DataObjects;

namespace ReportsVerification.Web.Builders
{
    public class ReportInfoBuilder: IReportInfoBuilder
    {
        private readonly IEnumerable<IConcreteReportInfoBuilder> _builders;
        public ReportInfoBuilder(IEnumerable<IConcreteReportInfoBuilder> builders)
        {
            _builders = builders;
        }

        public bool TryGetInfo(XDocument xmlFileContent, out ReportInfo reportInfo)
        {
            reportInfo = null;
            var resultBuild = new List<ReportInfo>();
            foreach (var builder in _builders)
            {
                ReportInfo resultBuildInfo;

                if (builder.TryGetInfo(xmlFileContent, out resultBuildInfo))
                {
                    resultBuild.Add(resultBuildInfo);
                }
            }

            if (!resultBuild.Any())
            {
                return false;
            }

            if (resultBuild.Count == 1)
            {
                reportInfo = resultBuild.First();
                return true;
            }

            var reportTypesString = string.Join(", ", resultBuild.Select(e => e.Type.ToString()));
            throw new ApplicationException(
                $"Несколько билдеров удовлевторяют условиям отчета ({reportTypesString})");
        }
    }
}