using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RabbitReader.Model;
using RabbitReader.Repository;

namespace RabbitReader.Api
{
    [Authorize]
    public class FeedsController : ApiController
    {
        public IFeedRepository db { get; set; }

        public FeedsController(IFeedRepository db)
        {
            this.db = db;
        }

        public List<Feed> GetFeeds()
        {
            return db.GetFeedListForUser(User.Identity.UserId()).Select(m => m.Feed).ToList();
        }
    }
}
