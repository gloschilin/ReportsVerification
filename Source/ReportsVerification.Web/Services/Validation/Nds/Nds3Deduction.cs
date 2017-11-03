using ReportsVerification.Web.DataObjects.Catalogs;
using ReportsVerification.Web.Repositories.Interfaces;
using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Nds.Common;

namespace ReportsVerification.Web.Services.Validation.Nds
{
    /// <summary>
    /// В декларации по НДС за 3 квартал доля вычетов превышает 
    /// безопасную (в скобках указываем  значение безопасной доли в %).
    /// </summary>
    public class Nds3Deduction : CommonNdsDeduction
    {

        public Nds3Deduction(IValidationHandler handler, ICatalogRepository catalogRepository) 
            : base(handler, catalogRepository)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Nds3Deduction;
        protected override int Quarter => 3;
        protected override decimal GetDeduction(Deduction deduction)
        {
            return deduction.ThirdQuaterAmount;
        }
    }
}