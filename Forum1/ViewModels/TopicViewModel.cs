using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum1.ViewModels
{
    public class TopicViewModel
    {
        public Forum Forum { get; set; }
        
        public List<Post> Posts { get; set; }
    }
}
