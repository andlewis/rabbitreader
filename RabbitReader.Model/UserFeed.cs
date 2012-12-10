using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RabbitReader.Model
{
    public class UserFeed
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Feed")]
        public int FeedId { get; set; }
        public virtual Feed Feed { get; set; }

        [ForeignKey("UserProfile")]
        public int UserId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public DateTime SubscribedOn { get; set; }
    }
}
