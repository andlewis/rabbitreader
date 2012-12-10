using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RabbitReader.Model
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Feed")]
        public int FeedId { get; set; }
        public virtual Feed Feed { get; set; }

        public string GuidValue { get; set; }
        public string Link { get; set; }
        public string Author { get; set; }
        public string Categories { get; set; }
        public string Comments { get; set; }
        public DateTime PublicationDate { get; set; }

        public string SourceTitle { get; set; }
        public string SourceUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<UserItem> UserItems { get; set; }
    }
}
