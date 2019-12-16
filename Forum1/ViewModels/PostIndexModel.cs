using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum1.ViewModels
{
    public class PostIndexModel
    {
        public bool RatedByUser { get; set; }
        public int Rating { get; set; }
        public User User { get; set; }
        public Forum Forum { get; set; }
        public Post Post { get; set; }
        public List<PostReply> Replies { get; set; }
    }
}
