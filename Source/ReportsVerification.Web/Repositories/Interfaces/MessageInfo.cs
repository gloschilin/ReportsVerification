using ReportsVerification.Web.Services.Validation;

namespace ReportsVerification.Web.Repositories.Interfaces
{
    public class MessageInfo
    {
        public MessageInfo(int? quarter, ValidationStepType message)
        {
            Quarter = quarter;
            Message = message;
        }

        public ValidationStepType Message { get; }
        public int? Quarter { get; }
    }
}