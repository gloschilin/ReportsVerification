using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;

namespace ReportsVerification.Web.Utills.Interfaces
{
    public interface IContentHandler
    {
        bool Handle(XDocument xmlFileContent, out ReportInfo reportInfo);
    }
}
