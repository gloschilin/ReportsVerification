using ReportsVerification.Web.DataObjects.Catalogs;
using ReportsVerification.Web.Repositories.Interfaces;
using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Nds.Common;

namespace ReportsVerification.Web.Services.Validation.Nds
{
    /// <summary>
    /// В декларации по НДС за 1 квартал доля вычетов превышает безопасную 
    /// (нужна ссылка на сайт, где есть таблица с долями).
    /// </summary>
    public class Nds1Deduction: CommonNdsDeduction
    {
        public Nds1Deduction(IValidationHandler handler, ICatalogRepository catalogRepository) 
            : base(handler, catalogRepository)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Nds1Deduction;
        protected override int Quarter => 1;
        protected override decimal GetDeduction(Deduction deduction)
        {
            return deduction.FirstQuaterAmount;
        }
    }
}