﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using DAL;
using DAL.Interface;
using Forum1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Web;
using System;

namespace Forum1.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _post;
        private readonly IForum _forum;
        private readonly IUser _user;
        private readonly IPostReply _postReply;

        public PostController(IPost post, IForum forum, IUser user, IPostReply postReply)
        {
            _post = post;
            _forum = forum;
            _user = user;
            _postReply = postReply;
        }

        public IActionResult Index(int id)
        {
            int userid;
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            try
            {
                userid = int.Parse(claims.ElementAt(2).Value);
            }
            catch (Exception)
            {

                userid = 0;
            }
            var post = _post.GetById(id);
            var user = _user.GetById(post.User.Id);
            var forum = _forum.GetById(post.Forum.Id);
            var replies = _postReply.GetById(post.Id);
            var model = new PostIndexModel
            {
                RatedByUser = _post.CheckLikeByUserId(userid, id),
                Rating = _post.GetRatingById(id),
                Post = post,
                User = user,
                Forum = forum,
                Replies = replies
            };
            return View(model);
        }

        public IActionResult Create([FromBody]CreatePostViewModel postToCreate)
        {
            var post = new Post();
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            post.Content = postToCreate.Content;
            post.Title = postToCreate.Title;
            post.Forum.Id = postToCreate.ForumId;
            post.User.Id = int.Parse(claims.ElementAt(2).Value);

            _post.Create(post);
            return View();
        }

        public IActionResult Delete(int id)
        {
            _post.Delete(id);
            return View();
        }
        public IActionResult LikePost(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            int userid = int.Parse(claims.ElementAt(2).Value); ;
            _post.LikePost(id, userid);
            return View();
        }
        public IActionResult RemoveLike(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            int userid = int.Parse(claims.ElementAt(2).Value); ;
            _post.RemoveLike(id, userid);
            return View();
        }

        public IActionResult GetAll()
        {
            return View();
        }
    }
}