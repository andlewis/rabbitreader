using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitReader.Model;

namespace RabbitReader.Repository
{
    public interface IDatabase
    {
        IQueryable<Feed> Feeds { get; }
        IQueryable<Item> Items { get; }
        IQueryable<UserProfile> UserProfiles { get; }
        IQueryable<UserFeed> UserFeeds { get; }
        IQueryable<UserItem> UserItems { get; }
    }
}
