using System;

namespace ReportsVerification.Web.DataObjects
{
    public class SessionInfo
    {
        public SessionInfo(Guid id, int actionUserId)
        {
            Id = id;
            ActionUserId = actionUserId;
        }

        public Guid Id { get; }

        public int ActionUserId { get; }
    }
}