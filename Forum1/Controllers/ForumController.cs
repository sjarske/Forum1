using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
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
            var forums = _forum.GetAll().Select(forum => new ForumListingModel {
                Id = forum.Id,
                Name = forum.Title,
                Description = forum.Description
            });

            var model = new ForumIndexModel
            {
                ForumList = forums
            };
            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var forum = _forum.GetById(id);
            var posts = forum.Posts;

            var postListings = posts.Select(post => new PostListingModel
            {
                Id= post.Id,
                AuthorId=post.User.Id.ToString(),
                Author= post.Author,
                Title=post.Title,
                DatePosted=post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = BuildForumListing(post)
            });

            var model = new ForumTopicModel  
            {
                Posts = postListings,
                Forum = BuildForumListing(forum)
            };

            return View(model);
        }

        private ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;
            return BuildForumListing(forum);
        }

        private ForumListingModel BuildForumListing(Forum forum)
        {
            return new ForumListingModel
            {
                Id = forum.Id,
                Name = forum.Title,
                Description = forum.Description,
                ImageUrl = forum.ImageUrl
            };
        }
    }
}