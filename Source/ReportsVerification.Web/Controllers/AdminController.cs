using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Http;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Repositories.EF;

namespace ReportsVerification.Web.Controllers
{
    public class AdminController : ApiController
    {
        static byte[] Utf8ToWin1251(string sourceStr)
        {
            var utf8 = Encoding.UTF8;
            var win1251 = Encoding.GetEncoding("windows-1251");
            var utf8Bytes = utf8.GetBytes(sourceStr);
            var win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);
            return win1251Bytes;
        }

        [HttpGet]
        [Route("import")]
        public void Import()
        {
            using (var context = new ReportsVertification())
            {
                //6119535

                var usersids = context.Reports
                    .Include(e => e.Session)
                    .Where(e => e.Alias == ReportTypes.SzvM.ToString())
                    .Select(e => e.Session.UserId)
                    .Take(5);

                var sessions = context.Sessions
                    .Include(e=>e.Reports)
                    .Where(e => usersids.Contains(e.UserId)).ToArray();

                var ind = 1;

                foreach (var session in sessions)
                {
                    if (!session.Reports.Any())
                    {
                        continue;
                    }

                    if (!Directory.Exists($"c:/userreports/{session.UserId}/{ind}"))
                    {
                        Directory.CreateDirectory($"c:/userreports/{session.UserId}/{ind}");
                    }

                    foreach (var report in session.Reports)
                    {
                        var bytes = Utf8ToWin1251(report.Content);
                        var win = Encoding.GetEncoding("windows-1251");
                        var content = win.GetString(bytes);
                        using (var sw = new StreamWriter(
                            File.Open($"c:/userreports/{session.UserId}/{ind}/{report.FileName}", 
                                FileMode.CreateNew), win))
                        {
                            sw.WriteLine(content);
                        }

                        //File.WriteAllBytes(
                        //    $"c:/userreports/{session.UserId}/{ind}/{report.FileName}",
                        //    bytes);
                    }

                    ind++;
                }

            }
        }
    }
}
