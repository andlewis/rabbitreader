using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabbitReader.Repository
{
    public interface IUserRepository
    {
        int GetUserIdByName(string userName);
    }
}
