using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabbitReader.Model
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        public ICollection<UserFeed> Feeds { get; set; }
    }
}
