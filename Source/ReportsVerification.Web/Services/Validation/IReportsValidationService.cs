using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.Nds;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Repositories.Interfaces;

namespace ReportsVerification.Web.Services.Validation
{
    public enum ValidationStepType
    {
        Nds1Vosmechenie,
        Nds1Deduction,
        Nds2Vosmechenie,
        Nds2Deduction,
        Nds3Vosmechenie,
        Nds3Deduction
    }

    public interface IReportsValidationService
    {
        void Validate(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo);
    }

    public interface IReportsConcreteValidationService : IReportsValidationService
    {

    }

    public class ReportsValidationService: IReportsValidationService
    {
        private readonly IEnumerable<IReportsConcreteValidationService> _services;

        public ReportsValidationService(IEnumerable<IReportsConcreteValidationService> services)
        {
            _services = services;
        }

        public void Validate(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            foreach (var service in _services)
            {
                service.Validate(reports, sessionInfo);
            }
        }
    }

    public interface IValidationHandler
    {
        void Wrong(ValidationStepType type);
        void Success(ValidationStepType type);
    }

    public abstract class CommonConcreteValidationService : IReportsConcreteValidationService
    {
        private readonly IValidationHandler _handler;
        protected abstract ValidationStepType Type { get; }

        protected CommonConcreteValidationService(IValidationHandler handler)
        {
            _handler = handler;
        }

        public void Validate(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            if (IsValid(reports, sessionInfo))
            {
                _handler.Success(Type);
            }
            else
            {
                _handler.Wrong(Type);
            }
        }

        protected abstract bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo);
    }

    /// <summary>
    /// В декларации по НДС за 1 квартал заявлено возмещение. Готовьтесь к камеральной проверке.
    /// Ссылки на статьи
    /// </summary>
    public class Nds1Vosmechenie: CommonConcreteValidationService
    {
        public Nds1Vosmechenie(IValidationHandler handler) : base(handler)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Nds1Vosmechenie;
        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            var ndsReports = reports
                .Where(e => e.ReportType == ReportTypes.Nds)
                .Where(e => ((ReportInfoRevistion<DateOfQuarter>) e.GetReportInfo()).ReportPeriod.Quarter == 1)
                .Select(e => e.XsdReport).OfType<Файл>().ToArray();

            return !ndsReports.Any() || ndsReports.All(e => e.Документ.НДС.СумУплНП.СумПУ_1731.ToDecimal() == 0);
        }
    }

    /// <summary>
    /// В декларации по НДС за 1 квартал доля вычетов превышает безопасную 
    /// (нужна ссылка на сайт, где есть таблица с долями).
    /// </summary>
    public class Nds1Deduction: CommonConcreteValidationService
    {
        private readonly ICatalogRepository _catalogRepository;

        public Nds1Deduction(IValidationHandler handler, ICatalogRepository catalogRepository) : base(handler)
        {
            _catalogRepository = catalogRepository;
        }

        protected override ValidationStepType Type => ValidationStepType.Nds1Deduction;
        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            if (!sessionInfo.RegionId.HasValue)
            {
                return true;
            }

            foreach (var report in reports
                .Where(e => e.ReportType == ReportTypes.Nds)
                .Where(e => ((ReportInfoRevistion<DateOfQuarter>)e.GetReportInfo()).ReportPeriod.Quarter == 1)
                .Where(e=>(e.XsdReport as Файл)?.Документ.НДС.СумУплНП.СумПУ_1731.ToDecimal() > 0).ToList())
            {
                var file = (Файл)report.XsdReport;
                var deduction = _catalogRepository.GetDeduction(
                    report.GetReportInfo().GetStartReportPeriod(),
                    sessionInfo.RegionId.Value);

                var incorrect = file.Документ.НДС.СумУпл164.СумНалВыч.НалВычОбщ.ToDecimal()
                    /   file.Документ.НДС.СумУпл164.СумНалОб.СумНалВосст.СумНалВс.ToDecimal() * 100 
                    >= deduction.FirstQuaterAmount;

                if (incorrect)
                {
                    return false;
                }
            }

            return true;
        }
    }

    /// <summary>
    /// В декларации по НДС за 2 квартал заявлено возмещение. Готовьтесь к камеральной проверке.
    /// </summary>
    public class Nds2Vosmechenie : CommonConcreteValidationService
    {
        public Nds2Vosmechenie(IValidationHandler handler) : base(handler)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Nds2Vosmechenie;
        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            var ndsReports = reports
                .Where(e => e.ReportType == ReportTypes.Nds)
                .Where(e => ((ReportInfoRevistion<DateOfQuarter>)e.GetReportInfo()).ReportPeriod.Quarter == 2)
                .Select(e => e.XsdReport).OfType<Файл>().ToArray();

            return !ndsReports.Any() || ndsReports.All(e => e.Документ.НДС.СумУплНП.СумПУ_1731.ToDecimal() == 0);
        }
    }

    /// <summary>
    /// В декларации по НДС за 2 квартал доля вычетов превышает безопасную (нужна ссылка на сайт, где есть таблица с долями).
    /// </summary>
    public class Nds2Deduction : CommonConcreteValidationService
    {
        private readonly ICatalogRepository _catalogRepository;

        public Nds2Deduction(IValidationHandler handler, ICatalogRepository catalogRepository) : base(handler)
        {
            _catalogRepository = catalogRepository;
        }

        protected override ValidationStepType Type => ValidationStepType.Nds2Deduction;
        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            if (!sessionInfo.RegionId.HasValue)
            {
                return true;
            }

            foreach (var report in reports
                .Where(e => e.ReportType == ReportTypes.Nds)
                .Where(e => ((ReportInfoRevistion<DateOfQuarter>)e.GetReportInfo()).ReportPeriod.Quarter == 2)
                .Where(e => (e.XsdReport as Файл)?.Документ.НДС.СумУплНП.СумПУ_1731.ToDecimal() > 0).ToList())
            {
                var file = (Файл)report.XsdReport;
                var deduction = _catalogRepository.GetDeduction(
                    report.GetReportInfo().GetStartReportPeriod(),
                    sessionInfo.RegionId.Value);

                var incorrect = file.Документ.НДС.СумУпл164.СумНалВыч.НалВычОбщ.ToDecimal()
                    / file.Документ.НДС.СумУпл164.СумНалОб.СумНалВосст.СумНалВс.ToDecimal() * 100
                    >= deduction.SecondQuaterAmount;

                if (incorrect)
                {
                    return false;
                }
            }

            return true;
        }
    }

    /// <summary>
    /// В декларации по НДС за 3 квартал заявлено возмещение. Готовьтесь к камеральной проверке
    /// </summary>
    public class Nds3Vosmechenie : CommonConcreteValidationService
    {
        public Nds3Vosmechenie(IValidationHandler handler) : base(handler)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Nds3Vosmechenie;
        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            var ndsReports = reports
                .Where(e => e.ReportType == ReportTypes.Nds)
                .Where(e => ((ReportInfoRevistion<DateOfQuarter>)e.GetReportInfo()).ReportPeriod.Quarter == 3)
                .Select(e => e.XsdReport).OfType<Файл>().ToArray();

            return !ndsReports.Any() || ndsReports.All(e => e.Документ.НДС.СумУплНП.СумПУ_1731.ToDecimal() == 0);
        }
    }

    /// <summary>
    /// В декларации по НДС за 3 квартал доля вычетов превышает 
    /// безопасную (в скобках указываем  значение безопасной доли в %).
    /// </summary>
    public class Nds3Deduction : CommonConcreteValidationService
    {
        private readonly ICatalogRepository _catalogRepository;

        public Nds3Deduction(IValidationHandler handler, ICatalogRepository catalogRepository) : base(handler)
        {
            _catalogRepository = catalogRepository;
        }

        protected override ValidationStepType Type => ValidationStepType.Nds3Deduction;
        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            if (!sessionInfo.RegionId.HasValue)
            {
                return true;
            }

            foreach (var report in reports
                .Where(e => e.ReportType == ReportTypes.Nds)
                .Where(e => ((ReportInfoRevistion<DateOfQuarter>)e.GetReportInfo()).ReportPeriod.Quarter == 3)
                .Where(e => (e.XsdReport as Файл)?.Документ.НДС.СумУплНП.СумПУ_1731.ToDecimal() > 0).ToList())
            {
                var file = (Файл)report.XsdReport;
                var deduction = _catalogRepository.GetDeduction(
                    report.GetReportInfo().GetStartReportPeriod(),
                    sessionInfo.RegionId.Value);

                var incorrect = file.Документ.НДС.СумУпл164.СумНалВыч.НалВычОбщ.ToDecimal()
                    / file.Документ.НДС.СумУпл164.СумНалОб.СумНалВосст.СумНалВс.ToDecimal() * 100
                    >= deduction.ThirdQuaterAmount;

                if (incorrect)
                {
                    return false;
                }
            }

            return true;
        }
    }
}