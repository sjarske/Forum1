using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Forum1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Forum1.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forum;
        private readonly IPost _post;

        public ForumController(IForum forum, IPost post)
        {
            _forum = forum;
            _post = post;
        }

        public IActionResult Index()
        {
            var forums = _forum.GetAll();
            var model = new ForumIndexModel
            {
                ForumsList = forums
            };
            return View(model);
        }

        public IActionResult Topic(Forum forum)
        {
            var postsByForum = _forum.GetPostsByForum(forum.Id);
            var model = new TopicViewModel
            {
                Forum = forum,
                Posts = postsByForum
            };
            return View(model);
        }
    }
}