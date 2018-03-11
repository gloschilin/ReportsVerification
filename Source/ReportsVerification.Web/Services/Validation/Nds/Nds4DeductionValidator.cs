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
    [ValidatorQuarter(4)]
    public class Nds4DeductionValidator : CommonNdsDeductionValidator
    {

        public Nds4DeductionValidator(IValidationContext context, ICatalogRepository catalogRepository) 
            : base(context, catalogRepository)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Nds4DeductionValidator;
        protected override int Quarter => 4;
        protected override decimal GetDeduction(Deduction deduction)
        {
            return deduction.ForthQuaterAmount;
        }
    }
}