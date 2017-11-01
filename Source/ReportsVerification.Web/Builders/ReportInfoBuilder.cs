using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Practices.ObjectBuilder2;
using ReportsVerification.Web.Builders.Interfaces;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;

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
            var resultBuild = new ConcurrentBag<ReportInfo>();
            _builders.ForEach(builder =>
            {
                ReportInfo resultBuildInfo;

                if (builder.TryGetInfo(xmlFileContent, out resultBuildInfo))
                {
                    resultBuild.Add(resultBuildInfo);
                }
            });

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