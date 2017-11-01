using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.DateOfMonthType;
using ReportsVerification.Web.DataObjects.Enums;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Services.Recomendations
{
    /// <summary>
    /// Рекомендации для загрузки "Декларация по налогу на прибыль"
    /// </summary>
    public class DeclarationOnIncomeTaxRecomendations : IConcreteRecomendation
    {
        public IEnumerable<ReportInfo> GetRecomendatedReports(SessionInfo sessionInfo)
        {
            if ((sessionInfo.Mode == UserModes.Osno
                 && new[]
                 {
                     Categories.AoEmployer,
                     Categories.AoWithoutEmployees,
                     Categories.OooEmployer,
                     Categories.OooWithoutEmployees
                 }.Any(e => e == sessionInfo.Category)) || sessionInfo.Mode == UserModes.OsnoWithEnvd)
            {
                return new[] { 1, 2, 3 }.Select(
                    e => new ReportInfo(
                        ReportTypes.DeclarationOnIncomeTax,
                        new DateOfMonth(2017, DateOfMonth.GetMonthFromQuarter(e)),
                        string.Empty));
            }

            return new List<ReportInfo>();
        }
    }
}