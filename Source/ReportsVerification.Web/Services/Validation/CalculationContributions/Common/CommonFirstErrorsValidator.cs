using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.Common
{
    public abstract class CommonFirstErrorsValidator
        : CommonValidator
    {
        protected abstract int Month { get; }

        protected CommonFirstErrorsValidator(IValidationContext context)
            : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport, 
            IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            var summAfter3Month = xsdReport.Документ.РасчетСВ.ОбязПлатСВ
                .РасчСВ_ОПС_ОМС.Select(e => e.РасчСВ_ОПС.НачислСВНеПрев)
                .Sum(e=>GetSum(e));

            var summSvMk = xsdReport.Документ.РасчетСВ.ПерсСвСтрахЛиц.SelectMany(e => e.СвВыплСВОПС.СвВыпл.СвВыплМК)
                .Where(e => e.Месяц.ToInt() == Month).Sum(e => e.НачислСВ);

            return summAfter3Month == summSvMk;
        }

        protected abstract decimal GetSum(СвСум1Тип value);
    }
}