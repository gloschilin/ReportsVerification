using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Xml.Linq;
using ReportsVerification.Web.Factories.Interfaces;
using ReportsVerification.Web.Repositories.EF;
using ReportsVerification.Web.Repositories.Interfaces;
using ReportsVerification.Web.Services.Validation;
using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Utills;

namespace ReportsVerification.Web.Controllers
{
    public class AdminController : ApiController
    {
        private readonly IReportRepository _reportRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IReportsValidator _reportsValidator;
        private readonly IValidationContext _validationContext;
        private readonly IReportFactory _factory;

        public AdminController(IReportRepository reportRepository, 
            ISessionRepository sessionRepository, 
            IReportsValidator reportsValidator, 
            IValidationContext validationContext,
            IReportFactory factory)
        {
            _reportRepository = reportRepository;
            _sessionRepository = sessionRepository;
            _reportsValidator = reportsValidator;
            _validationContext = validationContext;
            _factory = factory;
        }

        private static byte[] Utf8ToWin1251(string sourceStr)
        {
            var utf8 = Encoding.UTF8;
            var win1251 = Encoding.GetEncoding("windows-1251");
            var utf8Bytes = utf8.GetBytes(sourceStr);
            var win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);
            return win1251Bytes;
        }

        [HttpGet]
        [Route("handle")]
        public int HandleAll()
        {
            var countErrors = 0;
            var countReports = 0;
            var countsession = 0;

            using (var context = new ReportsVertification())
            {
                var sessions = context.Sessions
                    .Where(e=>e.Reports.Any())
                    .Select(e=>e.Id);

                countsession = sessions.Count();

                foreach (var sessionId in sessions)
                {
                    var reports = _reportRepository.GetList(sessionId).ToArray();
                    countReports += reports.Length;
                    var session = _sessionRepository.Get(sessionId);
                    
                    _reportsValidator.Validate(reports, session, ValidationType.Secondary);
                    var validationResult = _validationContext.GetWrongMessages(sessionId).Count();

                    countErrors += validationResult;
                }
            }
            
            AppLog.Instance().Info($"Всего сессий пройдено: {countsession} Проверено отчетов {countReports}. Предупреждений всего  {countErrors} сессий");

            return countErrors;
        }

        [HttpGet]
        [Route("import")]
        public void Import()
        {
            var skip = 0;

            using (var context = new ReportsVertification())
            {
                var totalReports = context.Reports.Count();
                Debug.WriteLine($"Начало выгрузки. Количество отчетов {totalReports}");
            }

            var reportsCount = 0;

            while (true)
                {
                    try
                    {
                        using (var context = new ReportsVertification())
                        {
                            //6119535

                            var reports = context.Reports
                                .Select(e => new {e.SessionId, e.Session.UserId, e.Id, e.FileName, e.Content})
                                .OrderBy(e => e.Id)
                                .Skip(skip)
                                .Take(100)
                                .ToArray();

                            if (!reports.Any())
                            {
                                return;
                            }

                            foreach (var report in reports)
                            {
                                var indUserSubstring1 = report.UserId.ToString().Substring(0, 2);

                                var path = $"c:/userreports/{indUserSubstring1}/{report.UserId}/{report.SessionId}";

                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }

                                var pathToFile =
                                    $"{path}/{Guid.NewGuid().ToString().Substring(0, 4)}-{report.FileName}";

                                var bytes = Utf8ToWin1251(report.Content);
                                var win = Encoding.GetEncoding("windows-1251");
                                var content = win.GetString(bytes);
                                using (var sw = new StreamWriter(File.Open(pathToFile, FileMode.CreateNew), win))
                                {
                                    sw.WriteLine(content);
                                }

                                reportsCount++;
                            }

                            skip += 100;

                            Debug.WriteLine($"Обработано {reportsCount} отчетов");
                        }
                    }
                    catch (Exception e)
                    {

                    }
                }
        }

        [HttpGet]
        [Route("import-reports")]
        public void GetReports()
        {
            var skip = 0;
            var win = Encoding.GetEncoding("windows-1251");

            var stream = new FileStream("C:\\rps\\file.csv", FileMode.Append, FileAccess.Write);
            var writer = new StreamWriter(stream, win);

            while (true)
            {
                using (var context = new ReportsVertification())
                {
                    var reports = context.Reports
                        .Select(e => new { e.SessionId, e.Session.UserId, e.Id, e.Content })
                        .OrderBy(e => e.Id)
                        .Skip(skip)
                        .Take(100)
                        .ToArray();
                    
                    if (!reports.Any())
                    {
                        writer.Dispose();
                        stream.Dispose();
                        return;
                    }

                    try
                    {
                        var builder = new StringBuilder();

                        foreach (var report in reports)
                        {
                            var bytes = Utf8ToWin1251(report.Content);
                            var content = win.GetString(bytes);
                            var xml = XDocument.Parse(content); //new XDocument(report.Content);
                            var current = _factory.GetReport(xml);
                            var info = current.GetReportInfo();

                            
                            builder.AppendLine(
                                $"{report.UserId}|{info.Inn}|{info.CompanyName}|{info.Version}|{info.Type}|{info.GetStartReportPeriod()?.ToString("dd.MM.yyyy")}|");
                        }

                        writer.WriteLine(builder.ToString());
                        
                        skip += 100;
                    }
                    catch
                    {
                        // ignored
                    }

                }
            }
            
        }
    }
}
