using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.Common
{
    public abstract class CommonSecondErrorsValidator
        : CommonValidator
    {
        protected abstract int Month { get; }
        
        protected CommonSecondErrorsValidator(IValidationContext context) 
            : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport, IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            var svSum = xsdReport.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .SelectMany(e => e.РасчСВ_ОПС428.РасчСВ_42812.Select(c => GetSum(c.НачислСВДоп))).Sum()
                + xsdReport.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .SelectMany(e => e.РасчСВ_ОПС428.РасчСВ_4283.Select(c => GetSum(c.НачислСВДоп))).Sum();

            var sumByMonth =
                xsdReport.Документ.РасчетСВ.ПерсСвСтрахЛиц.Select(
                    e => e.СвВыплСВОПС.ВыплСВДоп.ВыплСВДопМТ.Where(c => c.Месяц.ToInt() == Month).Sum(s => s.НачислСВ))
                    .Sum();

            return sumByMonth == svSum;
        }

        protected abstract decimal GetSum(СвСум1Тип value);
    }
}