using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.Ndfl6;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.Ndfl6.Common
{
    public abstract class Ndfl6TaxesValidator:  CommonNdflValidator
    {
        protected Ndfl6TaxesValidator(IValidationContext context) 
            : base(context)
        {
        }

        protected override bool IsValid(Файл report, IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            if (report.Документ.НДФЛ6.ОбобщПоказ.СумСтавка.First().НачислДох <= 0)
            {
                return true;
            }

            return report.Документ.НДФЛ6.ОбобщПоказ.УдержНалИт.ToDecimal() > 0;
        }
    }
}