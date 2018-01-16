using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ReportsVerification.Web.DataObjects.Catalogs;
using ReportsVerification.Web.Filters;
using ReportsVerification.Web.Repositories.Interfaces;
using ReportsVerification.Web.Utills.Attributes;

namespace ReportsVerification.Web.Controllers
{
    public class RegionInfoModel
    {
        /// <summary>
        /// Идентификатор региона
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование региона
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Размер МРОТ
        /// </summary>
        public decimal Mrot { get; set; }

        /// <summary>
        /// Значение на 1 квартал
        /// </summary>
        public decimal FirstQuaterAmountDeduction { get; set; }

        /// <summary>
        /// Значение на 2 квартал
        /// </summary>
        public decimal SecondQuaterAmountDeduction { get; set; }

        /// <summary>
        /// Значение на 3 квартал
        /// </summary>
        public decimal ThirdQuaterAmountDeduction { get; set; }

        /// <summary>
        /// Значение на 4 квартал
        /// </summary>
        public decimal ForthQuaterAmountDeduction { get; set; }
    }

    /// <summary>
    /// Получение справочников
    /// </summary>
    [ControllerSettings(allowCamelCase: true), AllowOptionsFilter]
    [RoutePrefix("api/catalogs")]
    public class CatalogsController: ApiController
    {
        private readonly ICatalogRepository _catalogRepository;

        public CatalogsController(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        [Route("regions"), HttpGet, HttpPut]
        public IEnumerable<Region> Regions()
        {
            var regions = _catalogRepository.GetRegions();
            return regions;
        }

        [Route("regions/{regionId}"), HttpGet]
        public IHttpActionResult GetRegion(Guid regionId)
        {
            var valuesOnDate = DateTime.Now;
            var region = _catalogRepository.GetRegions().FirstOrDefault(e => e.Id == regionId);

            if (region == null)
            {
                return NotFound();
            }

            var mrot = _catalogRepository.GetMrot(valuesOnDate, regionId)?.Amount;

            if (!mrot.HasValue)
            {
                return NotFound();
            }

            var deduction = _catalogRepository.GetDeduction(valuesOnDate, regionId);

            if (deduction == null)
            {
                return NotFound();
            }

            var model = new RegionInfoModel
            {
                Id = region.Id,
                Name = region.Name,
                Mrot = mrot.Value,
                FirstQuaterAmountDeduction = deduction.ForthQuaterAmount,
                SecondQuaterAmountDeduction = deduction.SecondQuaterAmount,
                ThirdQuaterAmountDeduction = deduction.ThirdQuaterAmount,
                ForthQuaterAmountDeduction = deduction.ForthQuaterAmount
            };

            return Ok(model);
        }
    }
}