using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportsVerification.Web.DataObjects
{
    public class SessionInfo
    {
        public SessionInfo(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}