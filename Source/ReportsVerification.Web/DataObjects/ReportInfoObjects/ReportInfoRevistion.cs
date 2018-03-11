using System;
using System.Security.Cryptography;
using ReportsVerification.Web.DataObjects.Dates;

namespace ReportsVerification.Web.DataObjects.ReportInfoObjects
{
    public class ReportInfoRevistion<TReportDate> : ReportInfo
        where TReportDate: class, IDateType
    {
        /// <summary>
        /// Номер корректировки
        /// </summary>
        public int RevisionNumber { get; }

        public TReportDate ReportPeriod { get; set; }

        public ReportInfoRevistion(ReportTypes type, TReportDate reportPeriod, string companyName, string inn, 
            int revisionNumber) 
            : base(type, companyName, inn)
        {
            RevisionNumber = revisionNumber;
            ReportPeriod = reportPeriod;
        }

        public override string GetUniq()
        {
            var source = Type.ToString() + RevisionNumber  + ReportPeriod;
            using (var md5Hash = MD5.Create())
            {
                var hash = GetHash(md5Hash, source);
                return hash;
            }
        }

        public override DateTime? GetStartReportPeriod()
        {
            return ReportPeriod?.GetStartPeriodDate();
        }
    }
}