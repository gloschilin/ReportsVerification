using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.Ndfl2;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.PrimaryValidation
{
    [ValidatorQuarter(1)]
    public class ByYearNdfl2ReportValidator : CommonConcretePrimaryReportValidator
    {

        public override ReportTypes[] ReportTypesSupport => new ReportTypes[0];
        public ByYearNdfl2ReportValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.PrimaryReportsNdfl2ByYearValidator;

        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            return reports.Select(e => e.XsdReport).OfType<Файл>().All(IsValid);
        }

        private static bool IsValid(Файл file)
        {
            var years = file.Документ.Select(e => e.ОтчетГод.ToInt()).ToList();
            years.Add(file.СвРекв.ОтчетГод.ToInt());
            return years.Distinct().Count() <= 1;
        }
    }
}