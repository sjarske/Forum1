using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class PostReplyModel
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime Created { get; set; }
        public string ReplyContent { get; set; }
        public int PostId { get; set; }
    }
}
