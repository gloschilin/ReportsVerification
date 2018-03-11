﻿using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    /// <summary>
    /// Соотношение прямых расходов и выручки от реализации 2 квартал
    /// </summary>
    [ValidatorQuarter(2)]
    public class DirectCosts2Validator : CommonDirectCostsValidator
    {
        public DirectCosts2Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.DeclarationOnIncomeTaxDirectCosts2Validator;
        protected override int Quarter => 2;
    }
}