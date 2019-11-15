using DAL;
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

        public Task Add(Post post)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostsByForum(int id)
        {
            return _context.GetPostsByForum(id);          
        }
    }
}
