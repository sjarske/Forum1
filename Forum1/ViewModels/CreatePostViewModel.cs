using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum1.ViewModels
{
    public class CreatePostViewModel
    {
        public int ForumId { get; set; }
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
