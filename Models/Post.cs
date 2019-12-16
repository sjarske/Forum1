using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Post
    {
        public int Id { get; set; }
        public Forum Forum { get; set; }
        public User User { get; set; }
        public DateTime Created { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public virtual IEnumerable<PostReply> Replies { get; set; }

        public Post()
        {
            Replies = new List<PostReply>();
            User = new User();
            Forum = new Forum();
        }
    }
}
