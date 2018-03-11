using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;

namespace ReportsVerification.Web.Factories.Interfaces
{
    /// <summary>
    /// Фабрика ReportInfo
    /// </summary>
    public interface IReportInfoFactory
    {
        ReportInfo Create2NdflReportInfo(DateOfQuarter reportMonth,
            string companyName, string inn, int revisionNumber, int mark);

        ReportInfo CreateReportInfoRevision<TReportDate>(ReportTypes type, TReportDate reportPeriod,
            string companyName, string inn, int revisionNumber) where TReportDate : class, IDateType;

        ReportInfo CreateSzvMReportInfo(SzvMReportInfoType szvMType, DateOfMonth reportMoth, string companyName, 
            string inn);
    }
}