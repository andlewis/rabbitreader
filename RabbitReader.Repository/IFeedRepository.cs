using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitReader.Model;

namespace RabbitReader.Repository
{
    public interface IFeedRepository
    {
        Feed GetFeed(int id);
        List<UserFeed> GetFeedListForUser(int userId);
        OperationStatus UpdateFeed(Feed feed);
        OperationStatus InsertFeed(Feed feed);
        List<Item> GetUnreadItems(int feedId, int userId);
        OperationStatus MarkItemAsRead(int itemId, int userId);
        OperationStatus MarkFeedAsRead(int feedId, int userId);
    }
}
