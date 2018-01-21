using System;
using System.Collections.Generic;
using ReportsVerification.Web.Repositories.EF;
using ReportsVerification.Web.Services.Validation;
using ReportsVerification.Web.Utills;

namespace ReportsVerification.Web.Repositories.Interfaces
{
    public class MessagesRepository: IMessagesRepository
    {
        private static readonly Lazy<IEnumerable<MessageInfo>> Messages
            = new Lazy<IEnumerable<MessageInfo>>(GetMessagesInternal);

        private static IEnumerable<MessageInfo> GetMessagesInternal()
        {
            var result = new List<MessageInfo>();
            using (var dataContext = new ReportsVertification())
            {
                foreach (var message in dataContext.MessageToQuarters)
                {
                    AppLog.Instance().Info($"Load message {message.Message}");

                    var enumValue = (ValidationStepType)Enum.Parse(
                        typeof(ValidationStepType), message.Message);

                    result.Add(new MessageInfo(message.Quarter, enumValue));
                }
            }

            return result;
        }

        public IEnumerable<MessageInfo> GetMessages()
        {
            return Messages.Value;
        }
    }
}