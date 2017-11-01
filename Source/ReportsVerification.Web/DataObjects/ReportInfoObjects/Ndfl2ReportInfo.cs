using System.Security.Cryptography;
using ReportsVerification.Web.DataObjects.Dates;

namespace ReportsVerification.Web.DataObjects.ReportInfoObjects
{
    public class Ndfl2ReportInfo : ReportInfoRevistion<DateOfQuarter>
    {
        /// <summary>
        /// Признак
        /// </summary>
        public int Mark { get; }

        public Ndfl2ReportInfo(ReportTypes type, DateOfQuarter reportMonth, string companyName, 
            int revisionNumber, int mark) 
            : base(type, reportMonth, companyName, revisionNumber)
        {
            Mark = mark;
        }

        public override string GetUniq()
        {
            var source = Type.ToString() + ReportPeriod + RevisionNumber + Mark;
            using (var md5Hash = MD5.Create())
            {
                var hash = GetHash(md5Hash, source);
                return hash;
            }
        }
    }
}