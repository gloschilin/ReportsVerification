﻿using System.Xml.Linq;
using ReportsVerification.Web.Builders.Interfaces;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Interfaces;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Builders
{
    public abstract class CommonConcreteInfoBuilder<TXsdReport>: IConcreteReportInfoBuilder
        where TXsdReport: class, IXsdReport
    {
        protected readonly IReportInfoFactory ReportInfoFactory;
        protected abstract ReportTypes ReportType { get; }

        protected CommonConcreteInfoBuilder(IReportInfoFactory reportInfoFactory)
        {
            ReportInfoFactory = reportInfoFactory;
        }

        public bool TryGetInfo(XDocument xmlFileContent, out ReportInfo reportInfo)
        {
            reportInfo = null;
            TXsdReport xsdReport;
            if (!Allow(xmlFileContent, out xsdReport))
            {
                return false;
            }

            reportInfo = GetReportInfoInternal(xsdReport);
            return true;
        }

        protected abstract ReportInfo GetReportInfoInternal(TXsdReport xsdReport);

        protected abstract bool Allow(TXsdReport xmlReport);

        private bool Allow(XDocument xmlFileContent, out TXsdReport xsdReport)
        {
            xsdReport = null;
            IXsdReport parseResult;
            if (Report.TryParse(typeof(TXsdReport), xmlFileContent, out parseResult) 
                && (xsdReport = parseResult as TXsdReport) != null)
            {
                return Allow(xsdReport);
            }

            return false;
        }
    }
}