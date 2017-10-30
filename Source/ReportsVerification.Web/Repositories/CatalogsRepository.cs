using System;
using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.Repositories.EF;
using ReportsVerification.Web.Repositories.Interfaces;
using Deduction = ReportsVerification.Web.DataObjects.Catalogs.Deduction;
using Mrot = ReportsVerification.Web.DataObjects.Catalogs.Mrot;

namespace ReportsVerification.Web.Repositories
{
    /// <summary>
    /// Репозиторий каталогов
    /// </summary>
    public class CatalogsRepository : ICatalogRepository
    {
        private static readonly Lazy<IEnumerable<EF.Deduction>> DeductionsInMemory 
            = new Lazy<IEnumerable<EF.Deduction>>(GetDeductionsInternal);

        private static readonly Lazy<IEnumerable<EF.Mrot>> MrotInMemory
            = new Lazy<IEnumerable<EF.Mrot>>(GetMrotInternal);

        private static IEnumerable<EF.Mrot> GetMrotInternal()
        {
            using (var dataContext = new ReportsVertification())
            {
                return dataContext.Mrots.ToArray();
            }
        }

        private static IEnumerable<EF.Deduction> GetDeductionsInternal()
        {
            using (var dataContext = new ReportsVertification())
            {
                return dataContext.Deductions.ToArray();
            }
        }

        private static Deduction ConvertDecuctions(EF.Deduction input)
        {
            return new Deduction
            {
                FirstQuaterAmount = input.FirstQuarter,
                SecondQuaterAmount = input.SecondQuarder,
                ThirdQuaterAmount = input.ThirdQuarter,
                ForthQuaterAmount = input.FourthQuarter
            };
        }

        public IEnumerable<Deduction> GetDeductions(DateTime valuesOnDate)
        {
            var resultDbEntities =  DeductionsInMemory.Value.Where(e => e.BeginDate <= valuesOnDate)
                .OrderByDescending(e => e.BeginDate).ToArray();
            var result = Array.ConvertAll(resultDbEntities, ConvertDecuctions);
            return result;
        }

        public Deduction GetDeduction(DateTime valuesOnDate, Guid regionId)
        {
            return GetDeductions(valuesOnDate).FirstOrDefault(e => e.RegionId == regionId);
        }

        public IEnumerable<Mrot> GetMrot(DateTime valuesOnDate)
        {
            var resultDbEntities = MrotInMemory.Value.Where(e => e.BeginDate <= valuesOnDate)
                .OrderByDescending(e => e.BeginDate).ToArray();
            var result = Array.ConvertAll(resultDbEntities, ConvertMrot);
            return result;
        }

        private static Mrot ConvertMrot(EF.Mrot input)
        {
            return new Mrot { Amount = input.Value, RegionId = input.RegionId };
        }

        public Mrot GetMrot(DateTime valuesOnDate, Guid regionId)
        {
            return GetMrot(valuesOnDate).First(e => e.RegionId == regionId);
        }
    }
}