using System;
using System.Security.Cryptography;
using ReportsVerification.Web.DataObjects.Dates;

namespace ReportsVerification.Web.DataObjects.ReportInfoObjects
{
    /// <summary>
    /// Информация по отчету СЗВ-М
    /// </summary>
    public class SzvMReportInfo: ReportInfo
    {
        public SzvMReportInfoType SzvMType { get; }

        public DateOfMonth ReportMoth { get; }

        public SzvMReportInfo(DateOfMonth reportMoth, string companyName, string inn,
            SzvMReportInfoType szvMType) 
            : base(ReportTypes.SzvM, companyName, inn)
        {
            SzvMType = szvMType;
            ReportMoth = reportMoth;
        }

        public override string GetUniq()
        {
            var source = Type.ToString() + ReportMoth + SzvMType;
            using (var md5Hash = MD5.Create())
            {
                var hash = GetHash(md5Hash, source);
                return hash;
            }
        }

        public override DateTime GetStartReportPeriod()
        {
            return ReportMoth.GetStartPeriodDate();
        }
    }
}