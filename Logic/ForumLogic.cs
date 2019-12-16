using DAL;
using DAL.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ForumLogic : IForum
    {
        private readonly IForum _context;
        private readonly IUser _userContext;

        public ForumLogic()
        {
            _context = new ForumSQLContext();
            _userContext = new UserSQLContext();
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

        public List<Post> GetPostsByForum(int id)
        {
            var returnedList = _context.GetPostsByForum(id);
            for (int i = 0; i < returnedList.Count; i++)
            {
                returnedList[i].User = _userContext.GetById(returnedList[i].User.Id);
            }
            return returnedList;
        }
    }
}
