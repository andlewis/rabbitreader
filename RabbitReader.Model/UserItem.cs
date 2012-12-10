using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RabbitReader.Model
{
    public class UserItem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserProfile")]
        public int UserId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public DateTime ReadOn { get; set; }
    }
}
