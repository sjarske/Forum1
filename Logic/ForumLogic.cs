using DAL;
using DAL.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ForumLogic : IForum
    {
        private readonly IForum _context;
        private readonly IUser _userContext;
        private readonly IPost _postContext;
        public ForumLogic()
        {
            _context = new ForumSQLContext();
            _userContext = new UserSQLContext();
            _postContext = new PostSQLContext();
        }
        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int forumId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.GetAll();
        }

        public Forum GetById(int id)
        {
            return _context.GetById(id);
        }

        public List<Post> GetAscDateSortedPostsByForum(int id)
        {
            var returnedList = _context.GetAscDateSortedPostsByForum(id);
            return GetUsersByPost(returnedList);
        }

        public List<Post> GetDescDateSortedPostsByForum(int id)
        {
            var returnedList = _context.GetDescDateSortedPostsByForum(id);
            return GetUsersByPost(returnedList);
        }

        public List<Post> GetRatingSortedPostsByForum(int id)
        {
            var returnedList = _context.GetDescDateSortedPostsByForum(id);
            GetUsersByPost(returnedList);
            for (int i = 0; i < returnedList.Count; i++)
            {
                returnedList[i].Like.Value = _postContext.GetRatingById(returnedList[i].Id);
            }
            var newlist = returnedList.OrderByDescending(l => l.Like.Value).ToList();
            return newlist;
        }

        private List<Post> GetUsersByPost(List<Post> returnedList)
        {
            for (int i = 0; i < returnedList.Count; i++)
            {
                returnedList[i].User = _userContext.GetById(returnedList[i].User.Id);
            }
            return returnedList;
        }
    }
}
