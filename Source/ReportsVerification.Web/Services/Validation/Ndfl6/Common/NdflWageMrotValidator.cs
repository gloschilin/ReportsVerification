using System;
using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.Xsd.Ndfl6;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Repositories.Interfaces;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.Ndfl6.Common
{
    public abstract class NdflWageMrotValidator: CommonNdflValidator
    {
        private readonly ICatalogRepository _catalogRepository;

        protected NdflWageMrotValidator(IValidationContext context, ICatalogRepository catalogRepository) 
            : base(context)
        {
            _catalogRepository = catalogRepository;
        }

        protected override bool IsValid(Файл report, IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            if (!sessionInfo.RegionId.HasValue)
            {
                return true;
            }

            return report.Документ.НДФЛ6.ОбобщПоказ.СумСтавка.First().НачислДох
                   /report.Документ.НДФЛ6.ОбобщПоказ.КолФЛДоход.ToDecimal() > GetMrot(sessionInfo);
        }

        private decimal GetMrot(SessionInfo sessionInfo)
        {
            if (!sessionInfo.RegionId.HasValue)
            {
                throw new ApplicationException("Не указан регион");
            }
            var mrot = _catalogRepository.GetMrot(new DateOfQuarter(2017, Quarter).GetStartPeriodDate(),
                sessionInfo.RegionId.Value);

            return mrot.Amount;
        }
    }
}