using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitReader.Model;
using Argotic.Syndication;

namespace RabbitReader.Repository
{
    public class FeedRepository : RepositoryBase<dbContext>, IFeedRepository
    {
        public Model.Feed GetFeed(int id)
        {
            using (var context = DataContext)
            {
                return context.Feeds.FirstOrDefault(m => m.Id == id);
            }
        }

        public List<Model.UserFeed> GetFeedListForUser(int userId)
        {
            using (var context = DataContext)
            {
                return context.UserFeeds.Include("Feed").Include("UserProfile").Where(m => m.UserId == userId).ToList();
            }
        }

        public Model.OperationStatus UpdateFeed(Model.Feed feed)
        {
            var opStatus = new OperationStatus() { Status = true };

            using (var context = DataContext)
            {
                var item = context.Feeds.FirstOrDefault(m => m.Id == feed.Id);
                item.CreatedOn = feed.CreatedOn;
                item.LastRetrievedOn = feed.LastRetrievedOn;
                item.RssUrl = feed.RssUrl;

                opStatus.RecordsAffected = context.SaveChanges();
            }

            return opStatus;
        }

        public Model.OperationStatus InsertFeed(Model.Feed feed)
        {
            var opStatus = new OperationStatus() { Status = true };

            using (var context = DataContext)
            {
                var item = new Feed();

                item.CreatedOn = feed.CreatedOn;
                item.LastRetrievedOn = feed.LastRetrievedOn;
                item.RssUrl = feed.RssUrl;

                context.Feeds.Add(item);

                opStatus.RecordsAffected = context.SaveChanges();

                RetrieveItems(item.Id);
            }

            return opStatus;
        }

        private void RetrieveItems(int feedId)
        {
            using (var context = DataContext)
            {
                var item = context.Feeds.FirstOrDefault(m => m.Id == feedId);
                var feed = RssFeed.Create(new Uri(item.RssUrl));

                foreach (var feedItem in feed.Channel.Items.Where(m => m.PublicationDate > item.LastRetrievedOn))
                {

                    var newItem = new Item()
                    {
                        FeedId = feedId,
                        Description = feedItem.Description,
                        Author = feedItem.Author,
                        Categories = string.Join(";", feedItem.Categories.Select(m => m.Value).ToArray<string>()),
                        Comments = feedItem.Comments.ToString(),
                        GuidValue = feedItem.Guid.Value,
                        Link = feedItem.Link.ToString(),
                        PublicationDate = feedItem.PublicationDate,
                        SourceTitle = feedItem.Source.Title,
                        SourceUrl = feedItem.Source.Url.ToString(),
                        Title = feedItem.Title
                    };
                    context.Items.Add(newItem);
                }

                item.Title = feed.Channel.Title;
                item.Format = feed.Format.ToString();
                item.Version = feed.Version.ToString();
                item.Webmaster = feed.Channel.Webmaster;
                item.Description = feed.Channel.Description;
                item.Copyright = feed.Channel.Copyright;
                item.LastRetrievedOn = DateTime.Now;

                context.SaveChanges();
            }
        }

        public List<Model.Item> GetUnreadItems(int feedId, int userId)
        {
            using (var context = DataContext)
            {
                return context.Items.Where(m => m.FeedId == feedId && context.UserItems.Where(z => z.UserId == userId && z.ItemId == m.Id).Any()).ToList();
            }
        }

        public Model.OperationStatus MarkItemAsRead(int itemId, int userId)
        {
            var opStatus = new OperationStatus() { Status = true };
            using (var context = DataContext)
            {
                var item = new Model.UserItem() { ItemId = itemId, UserId = userId, ReadOn = DateTime.Now };
                context.UserItems.Add(item);
                opStatus.RecordsAffected = context.SaveChanges();
            }
            return opStatus;
        }

        public Model.OperationStatus MarkFeedAsRead(int feedId, int userId)
        {
            var opStatus = new OperationStatus() { Status = true };
            using (var context = DataContext)
            {
                var items = GetUnreadItems(feedId, userId);
                foreach (var unread in items)
                {
                    var item = new Model.UserItem() { ItemId = unread.Id, UserId = userId, ReadOn = DateTime.Now };
                    context.UserItems.Add(item);
                }
                opStatus.RecordsAffected = context.SaveChanges();
            }
            return opStatus;
        }
    }
}
