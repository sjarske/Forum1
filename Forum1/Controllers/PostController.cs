using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Forum1.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _post;

        public PostController(IPost post)
        {
            _post = post;
        }

        public IActionResult Index(int id)
        {
            var post = _post.GetById(id);
            var replies = BuildPostReplies(post.Replies);

            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id.ToString(),
                AuthorName = post.User.Username,
                Created = post.Created,
                PostContent = post.Content,
                Replies =  replies
            };
            return View(model);
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyModel
            {
                Id = reply.Id,
                AuthorName = reply.User.Username,
                AuthorId = reply.User.Id.ToString(),
                Created = reply.Created,
                ReplyContent = reply.Content
            });
        }
    }
}