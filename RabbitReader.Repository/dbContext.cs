using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RabbitReader.Model;

namespace RabbitReader.Repository
{
    public class dbContext : DbContext, IDatabase
    {
        public dbContext() : base("name=DefaultConnection") { }

        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserFeed> UserFeeds { get; set;}
        public DbSet<UserItem> UserItems { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feed>().ToTable("feed");
            modelBuilder.Entity<Item>().ToTable("item");
            modelBuilder.Entity<UserFeed>().ToTable("userfeed");
            modelBuilder.Entity<UserItem>().ToTable("useritem");
     
            modelBuilder.Entity<UserProfile>().ToTable("userprofile");
     
            //Database.SetInitializer(new dbContextInitializer());

            base.OnModelCreating(modelBuilder);
        }

        IQueryable<Feed> IDatabase.Feeds
        {
            get { return Feeds; }
        }

        IQueryable<Item> IDatabase.Items
        {
            get { return Items; }
        }

        IQueryable<UserProfile> IDatabase.UserProfiles
        {
            get { return UserProfiles; }
        }

        IQueryable<UserFeed> IDatabase.UserFeeds
        {
            get { return UserFeeds; }
        }

        IQueryable<UserItem> IDatabase.UserItems
        {
            get { return UserItems; }
        }
    }
}
