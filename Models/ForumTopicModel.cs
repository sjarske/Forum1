using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ForumTopicModel
    {
        public ForumListingModel Forum { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }

    }
}
