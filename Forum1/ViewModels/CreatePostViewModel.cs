using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum1.ViewModels
{
    public class CreatePostViewModel
    {
        public int ForumId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
