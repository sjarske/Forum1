using System;

namespace Models
{
    public class PostReply
    {
        public int Id { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }

        public PostReply()
        {
            Post = new Post();
            User = new User();
        }
    }
}
