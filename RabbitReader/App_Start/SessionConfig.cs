using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using RabbitReader.Repository;

namespace RabbitReader
{
    public static class SessionConfig
    {
        public static int UserId(this IIdentity identity)
        {
            return new UserRepository().GetUserIdByName(identity.Name);
        }
    }
}