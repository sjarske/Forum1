﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Post
    {
        public int Id { get; set; }
        public int ForumId { get; set; }
        public int UserId { get;set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public string Author { get; set; }

        public virtual User User { get; set; }
        public virtual Forum Forum { get; set; }

        public virtual IEnumerable<PostReply> Replies { get; set; }
    }
}
