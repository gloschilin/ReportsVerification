using System.Collections.Generic;

namespace ReportsVerification.Web.Repositories.Interfaces
{
    public interface IMessagesRepository
    {
        IEnumerable<MessageInfo> GetMessages();
    }
}