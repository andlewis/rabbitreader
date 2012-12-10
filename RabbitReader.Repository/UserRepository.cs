using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabbitReader.Repository
{
    public class UserRepository : RepositoryBase<dbContext>, IUserRepository
    {
        public int GetUserIdByName(string userName)
        {
            using (var context = DataContext)
            {
                return context.UserProfiles.FirstOrDefault(m => m.Username == userName).UserId;
            }
        }
    }
}
