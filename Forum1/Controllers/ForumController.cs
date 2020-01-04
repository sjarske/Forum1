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
            return SortByDateAsc(forum);
        }

        public IActionResult SortByDateAsc(Forum forum)
        {
            var sortedPostsByForum = _forum.GetAscDateSortedPostsByForum(forum.Id);
            var model = new TopicViewModel
            {
                Forum = forum,
                Posts = sortedPostsByForum
            };
            return View("Topic",model);
        }

        public IActionResult SortByDateDesc(Forum forum)
        {
            var sortedPostsByForum = _forum.GetDescDateSortedPostsByForum(forum.Id);
            var model = new TopicViewModel
            {
                Forum = forum,
                Posts = sortedPostsByForum
            };
            return View("Topic", model);
        }

        public IActionResult SortByRating(Forum forum)
        {
            var sortedPostsByForum = _forum.GetRatingSortedPostsByForum(forum.Id);
            var model = new TopicViewModel
            {
                Forum = forum,
                Posts = sortedPostsByForum
            };
            return View("Topic", model);
        }
    }
}