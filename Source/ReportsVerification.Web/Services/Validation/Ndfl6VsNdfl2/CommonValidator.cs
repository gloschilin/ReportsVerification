using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;
using Ndfl6File = ReportsVerification.Web.DataObjects.Xsd.Ndfl6.Файл;
using Ndfl2File = ReportsVerification.Web.DataObjects.Xsd.Ndfl2.Файл;

namespace ReportsVerification.Web.Services.Validation.Ndfl6VsNdfl2
{
    public abstract class CommonValidator : CommonConcreteReportValidator
    {
        public override ReportTypes[] ReportTypesSupport => new[]
        {
            ReportTypes.Ndfl6, ReportTypes.Ndfl2
        };

        protected CommonValidator(IValidationContext context) 
            : base(context)
        {
        }

        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            var ndfl6Year = reports
                .FirstOrDefault(e =>
                {
                    if (e.ReportType != ReportTypes.Ndfl6)
                    {
                        return false;
                    }

                    var info = e.GetReportInfo() as ReportInfoRevistion<DateOfQuarter>;
                    return info?.ReportPeriod.Quarter == 4;
                });

            if (ndfl6Year == null)
            {
                return true;
            }

            var ndfl2Reports = reports.Where(e =>
            {
                if (e.ReportType != ReportTypes.Ndfl2)
                {
                    return false;
                }

                var info = e.GetReportInfo() as Ndfl2ReportInfo;
                return info?.Mark == 1;
            });

            var file6 = ndfl6Year.XsdReport as Ndfl6File;

            foreach (var ndfl2 in ndfl2Reports)
            {
                var file2 = ndfl2.XsdReport as Ndfl2File;
                var validateInternalResult
                    = ValidateInternal(file6, file2);

                if (!validateInternalResult)
                {
                    return false;
                }
            }

            return true;
        }

        protected abstract bool ValidateInternal(Ndfl6File ndfl6, Ndfl2File ndfl2);
    }

    public abstract class Ndfl6Vs2RateValidator : CommonValidator
    {
        protected abstract int Rate { get; }

        protected Ndfl6Vs2RateValidator(IValidationContext context) : base(context)
        {
        }

        protected override bool ValidateInternal(Ndfl6File ndfl6, Ndfl2File ndfl2)
        {
            var ndfl6Value = ndfl6.Документ.НДФЛ6.ОбобщПоказ.СумСтавка
                .FirstOrDefault(e => e.Ставка.ToInt() == Rate)?.НачислДох ?? 0;

            var ndfl2Value = ndfl2.Документ
                .SelectMany(e => e.СведДох)
                .Where(e => e.Ставка.ToInt() == Rate)
                .Sum(s => s.СумИтНалПер.СумДохОбщ);

            return ndfl2Value == ndfl6Value;
        }
    }

    public class Ndfl6Vs2Rate13Validator : Ndfl6Vs2RateValidator
    {
        public Ndfl6Vs2Rate13Validator(IValidationContext context) : base(context)
        {
        }

        protected override int Rate => 13;
        protected override ValidationStepType Type => ValidationStepType.Ndfl6Vs2Rate13Validator;
    }

    public class Ndfl6Vs2Rate9Validator : Ndfl6Vs2RateValidator
    {
        public Ndfl6Vs2Rate9Validator(IValidationContext context) : base(context)
        {
        }

        protected override int Rate => 9;
        protected override ValidationStepType Type => ValidationStepType.Ndfl6Vs2Rate9Validator;
    }

    public class Ndfl6Vs2Rate15Validator : Ndfl6Vs2RateValidator
    {
        public Ndfl6Vs2Rate15Validator(IValidationContext context) : base(context)
        {
        }

        protected override int Rate => 15;
        protected override ValidationStepType Type => ValidationStepType.Ndfl6Vs2Rate15Validator;
    }

    public class Ndfl6Vs2Rate35Validator : Ndfl6Vs2RateValidator
    {
        public Ndfl6Vs2Rate35Validator(IValidationContext context) : base(context)
        {
        }

        protected override int Rate => 35;
        protected override ValidationStepType Type => ValidationStepType.Ndfl6Vs2Rate35Validator;
    }
}