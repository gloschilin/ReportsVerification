using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.DeclarationOnIncomeTax;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common
{
    /// <summary>
    /// Соотношение прямых расходов и выручки от реализации
    /// </summary>
    public abstract class DeclarationOnIncomeTaxCommonDirectCostsValidation: DeclarationOnIncomeTaxCommonValidation
    {
        protected DeclarationOnIncomeTaxCommonDirectCostsValidation(IValidationHandler handler) : base(handler)
        {
        }

        protected override bool IsInvalid(Report report,
            IReadOnlyCollection<Report> allReports, SessionInfo sessionInfo)
        {
            var file = (DataObjects.Xsd.DeclarationOnIncomeTax.Файл) report.XsdReport;
            return file.Документ.Прибыль.Items.OfType<ФайлДокументПрибыльРасчНал>()
                .Any(e => e.РасхУмРеал.ToDecimal() <= e.ДохРеал.ToDecimal());
        }
    }
}