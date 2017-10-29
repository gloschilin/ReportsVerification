﻿using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.Ndfl2;

namespace ReportsVerification.Web.Builders
{
    public class Ndfl2InfoBuilder : CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.Ndfl2;
        protected override string GetCompanyName(Файл xmlFileContent)
        {
            throw new NotImplementedException();
        }

        protected override DateOfMonth GetReportMonth(Файл xmlFileContent)
        {
            throw new NotImplementedException();
        }

        protected override bool Allow(Файл xmlReport)
        {
            throw new NotImplementedException();
        }
    }
}