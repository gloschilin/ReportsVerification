namespace ReportsVerification.Web.DataObjects
{
    public class Ndfl2ReportInfo : ReportInfo
    {
        /// <summary>
        /// Признак
        /// </summary>
        public int Mark { get; }

        public Ndfl2ReportInfo(ReportTypes type, DateOfMonth reportMonth, string companyName, int mark) 
            : base(type, reportMonth, companyName)
        {
            Mark = mark;
        }
    }
}