using System;
using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.TransportDeclaration;

namespace ReportsVerification.Web.Builders
{
    public class TransportDeclarationInfoBuilder : CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.TransportDeclaration;

        protected string GetCompanyName(Файл xmlFileContent)
        {
            throw new NotImplementedException();
        }

        protected DateOfMonth GetReportMonth(Файл xmlFileContent)
        {
            throw new NotImplementedException();
        }

        protected override ReportInfo GetReportInfoInternal(Файл xsdReport)
        {
            
        }

        protected override bool Allow(Файл xmlReport)
        {
            return xmlReport.Документ.КНД == "1152004";
        }
    }
}