using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using DAL.Interface;
using Forum1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Forum1.Controllers
{
    public class PostReplyController : Controller
    {
        private readonly IPostReply _postReply;

        public PostReplyController(IPostReply postReply)
        {
            _postReply = postReply;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create([FromBody]CreateReplyViewModel postReplyToCreate)
        {
            var reply = new PostReply();
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            reply.Content = postReplyToCreate.Content;
            reply.Post.Id = postReplyToCreate.PostId;
            reply.User.Id = int.Parse(claims.ElementAt(2).Value);

            _postReply.Create(reply);
            return View();
        }
    }
}