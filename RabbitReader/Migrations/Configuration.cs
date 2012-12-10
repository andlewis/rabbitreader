namespace RabbitReader.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;
    using RabbitReader.Repository;

    internal sealed class Configuration : DbMigrationsConfiguration<RabbitReader.Repository.dbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(dbContext context)
        {
            SeedMembership();
            SeedFeeds(context);
            SeedSubscriptions(context);
        }

        private void SeedFeeds(dbContext db)
        {
            if (!db.Feeds.Any())
            {
                var feed = new Model.Feed() { RssUrl = "http://feeds.arstechnica.com/arstechnica/index", Title = "ARS Technica", CreatedOn = DateTime.Now, LastRetrievedOn = DateTime.Now };
                db.Feeds.Add(feed);
                db.SaveChanges();
            }
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection",
                "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("admin", false) == null)
            {
                membership.CreateUserAndAccount("admin", "fluffybunny@1");
            }
            if (!roles.GetRolesForUser("admin").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "admin" }, new[] { "admin" });
            }

        }

        private void SeedSubscriptions(dbContext db)
        {
            if (!db.UserFeeds.Any())
            {
                foreach(var feed in db.Feeds)
                    foreach (var user in db.UserProfiles)
                    {
                        db.UserFeeds.Add(new Model.UserFeed() { FeedId = feed.Id, UserId = user.UserId, SubscribedOn = DateTime.Now });
                    }
                db.SaveChanges();
            }

        }
    }
}
