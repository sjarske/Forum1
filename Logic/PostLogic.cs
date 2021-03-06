﻿using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PostLogic : IPost
    {
        private readonly IPost _context;

        public PostLogic()
        {
            _context = new PostSQLContext();

        }

        public bool CheckLikeByUserId(int userid, int postid)
        {
            return _context.CheckLikeByUserId(userid, postid);
        }

        public void Create(Post post)
        {
           _context.Create(post);
        }

        public void Delete(int id)
        {
            _context.Delete(id);
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            return _context.GetById(id);
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public int GetRatingById(int id)
        {
            return _context.GetRatingById(id);
        }
        public void LikePost(int id, int userid)
        {
            _context.LikePost(id, userid);
        }

        public void RemoveLike(int id, int userid)
        {
            _context.RemoveLike(id, userid);
        }
    }
}
