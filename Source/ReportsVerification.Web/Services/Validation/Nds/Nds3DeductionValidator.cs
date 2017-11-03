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
    public class Nds3DeductionValidator : CommonNdsDeductionValidator
    {

        public Nds3DeductionValidator(IValidationContext context, ICatalogRepository catalogRepository) 
            : base(context, catalogRepository)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Nds3DeductionValidator;
        protected override int Quarter => 3;
        protected override decimal GetDeduction(Deduction deduction)
        {
            return deduction.ThirdQuaterAmount;
        }
    }
}