using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RabbitReader.Model
{
    public class Feed
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Format { get; set; }
        public string Version { get; set; }
        public string Copyright { get; set; }
        public string Webmaster { get; set; }
        public string RssUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastRetrievedOn { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
