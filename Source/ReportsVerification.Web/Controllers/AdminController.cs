using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Http;
using ReportsVerification.Web.Repositories.EF;

namespace ReportsVerification.Web.Controllers
{
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("import")]
        public void Import()
        {
            using (var context = new ReportsVertification())
            {
                var sessions = context.Sessions
                    .Include(e=>e.Reports)
                    .Where(e => e.UserId == 6119535).ToArray();

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
                        //var fromEncode = Encoding.Default;
                        //var toEncode = fromEncode;// Encoding.GetEncoding("Windows-1251");

                        //var fromBytes = fromEncode.GetBytes(report.Content);
                        //var toBytes = Encoding.Convert(fromEncode, toEncode, fromBytes);

                        File.AppendAllText(
                            $"c:/userreports/{session.UserId}/{ind}/{report.FileName}",
                            report.Content
                            //toEncode.GetString(toBytes), toEncode
                            );
                    }

                    ind++;
                }

            }
        }
    }
}
