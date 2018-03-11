using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Factories.ReportInfoObjects
{
    public class ReportInfoFactory: IReportInfoFactory
    {
        public ReportInfo Create2NdflReportInfo(DateOfQuarter reportMonth, 
            string companyName, string inn, int revisionNumber, int mark)
        {
            return new Ndfl2ReportInfo(reportMonth, companyName, inn, revisionNumber, mark);
        }

        public ReportInfo CreateReportInfoRevision<TReportDate>(ReportTypes type, TReportDate reportPeriod, 
            string companyName, string inn, int revisionNumber) where TReportDate : class, IDateType
        {
            return new ReportInfoRevistion<TReportDate>(type, reportPeriod, companyName, inn, revisionNumber);
        }

        public ReportInfo CreateSzvMReportInfo(SzvMReportInfoType szvMType, DateOfMonth reportMoth, 
            string companyName, string inn)
        {
            return new SzvMReportInfo(reportMoth, companyName, inn, szvMType);
        }
    }
}