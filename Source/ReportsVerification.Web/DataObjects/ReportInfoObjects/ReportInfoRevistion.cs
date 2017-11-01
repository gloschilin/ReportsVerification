using System.Security.Cryptography;
using ReportsVerification.Web.DataObjects.DateOfMonthType;

namespace ReportsVerification.Web.DataObjects.ReportInfoObjects
{
    public class ReportInfoRevistion : ReportInfo
    {
        /// <summary>
        /// Номер корректировки
        /// </summary>
        public int RevisionNumber { get; }

        public ReportInfoRevistion(ReportTypes type, DateOfMonth reportMonth, string companyName, int revisionNumber) 
            : base(type, reportMonth, companyName)
        {
            RevisionNumber = revisionNumber;
        }

        public override string GetUniq()
        {
            var source = Type.ToString() + ReportMonth.Month + ReportMonth.Year + RevisionNumber;
            using (var md5Hash = MD5.Create())
            {
                var hash = GetHash(md5Hash, source);
                return hash;
            }
        }
    }
}