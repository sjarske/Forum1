using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum1.ViewModels
{
    public class ForumIndexModel
    {
        public IEnumerable<Forum> ForumsList { get; set; }
    }
}
