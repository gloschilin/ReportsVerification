﻿using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatementSimplifiedTaxation;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Builders
{
    public class AccountingStatementSimplifiedTaxationInfoBuilder : CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.AccountingStatementSimplifiedTaxation;

        protected override ReportInfo GetReportInfoInternal(Файл xsdReport)
        {
            var period = new DateOfQuarter().ReadFromPeriod(
                    int.Parse(xsdReport.Документ.ОтчетГод),
                    int.Parse(xsdReport.Документ.Период)
                );

            var info = ReportInfoFactory.CreateReportInfoRevision(ReportType, period,
                xsdReport.Документ.СвНП.НПЮЛ.НаимОрг,
                xsdReport.Документ.СвНП.НПЮЛ.ИННЮЛ,
                int.Parse(xsdReport.Документ.НомКорр ?? "0"));
            info.Version = xsdReport.ВерсПрог;
            return info;
        }

        protected override bool Allow(Файл xmlReport)
        {
            return xmlReport != null && xmlReport.Документ?.КНД == "0710096";
        }

        public AccountingStatementSimplifiedTaxationInfoBuilder(IReportInfoFactory reportInfoFactory) : base(reportInfoFactory)
        {
        }
    }
}