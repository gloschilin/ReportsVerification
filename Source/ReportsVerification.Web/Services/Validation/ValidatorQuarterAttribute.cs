using System;
using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation
{
    public static class ValidatorQuarterHelper
    {
        private static readonly Lazy<Dictionary<Type, int>> Quarters 
            = new Lazy<Dictionary<Type, int>>(Load);

        private static Dictionary<Type, int> Load()
        {
            var result = new Dictionary<Type, int>();

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IReportsValidator).IsAssignableFrom(p) && !p.IsAbstract);

            foreach (var type in types)
            {
                var dnAttribute = type.GetCustomAttributes(
                    typeof(ValidatorQuarterAttribute), true
                ).FirstOrDefault() as ValidatorQuarterAttribute;
                if (dnAttribute != null)
                {
                    result.Add(type, dnAttribute.Quarter);
                }
            }

            return result;
        }

        public static int GetQuarter(Type validatorType)
        {
            if (!Quarters.Value.ContainsKey(validatorType))
            {
                throw new ApplicationException("Не найдено соотношение валидатора и квартала");
            }

            return Quarters.Value[validatorType];
        }
    }

    public class ValidatorQuarterAttribute: Attribute
    {
        public readonly int Quarter;

        public ValidatorQuarterAttribute(int quarter)
        {
            Quarter = quarter;
        }
    }
}