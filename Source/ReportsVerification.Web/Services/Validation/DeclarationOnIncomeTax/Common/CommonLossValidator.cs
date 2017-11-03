using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.DeclarationOnIncomeTax;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common
{
    public abstract class CommonLossValidator : CommonValidator
    {
        protected CommonLossValidator(IValidationContext context) : base(context)
        {
        }

        protected override bool IsInvalid(Report report,
            IReadOnlyCollection<Report> allReports, SessionInfo sessionInfo)
        {
            var file = (Файл)report.XsdReport;
            return file.Документ.Прибыль.Items.OfType<ФайлДокументПрибыльРасчНал>()
                .Any(e => e.НалБаза.ToDecimal() > 0);
        }
    }
}